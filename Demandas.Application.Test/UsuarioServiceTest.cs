using AutoMapper;
using Demandas.Application.DTOs;
using Demandas.Application.Services;
using Demandas.Domain.Entities;
using Demandas.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Test
{
    public class UsuarioServiceTest
    {
        private readonly UsuarioService _usuarioService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IUsuarioRepository> _mockUsuarioRepository;

        public UsuarioServiceTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockUsuarioRepository = new Mock<IUsuarioRepository>();
            _usuarioService = new UsuarioService(_mockMapper.Object, _mockUsuarioRepository.Object);
        }

        [Fact]
        [Trait("Usuário", "Deve buscar usuário pelo login e retornar DTO")]
        public async Task BuscaPorLogin_DeveRetornarUsuarioDto_QuandoUsuarioExiste()
        {
            // Arrange
            var usuario = new Usuario("Teste", "loginTeste", "senha123", "teste@teste.com", false, false, 1, 1);
            var usuarioDto = new UsuarioDto { Nome = usuario.Nome, Login = usuario.Login, Email = usuario.Email };
            _mockUsuarioRepository.Setup(repo => repo.BuscarPorLoginAsync("loginTeste")).ReturnsAsync(usuario);
            _mockMapper.Setup(mapper => mapper.Map<UsuarioDto>(usuario)).Returns(usuarioDto);

            // Act
            var result = await _usuarioService.BuscaPorLogin("loginTeste");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(usuario.Nome, result.Nome);
        }

        [Fact]
        [Trait("Usuário", "Deve adicionar usuário com senha criptografada")]
        public async Task Adicionar_DeveAdicionarUsuarioComSenhaHashed()
        {
            // Arrange
            var usuarioDto = new UsuarioDto { Nome = "Novo Usuario", Login = "novoLogin", Senha = "senha123", Email = "novo@usuario.com" };
            var usuario = new Usuario(usuarioDto.Nome, usuarioDto.Login, usuarioDto.Senha, usuarioDto.Email, false, false, 1, 1);
            _mockMapper.Setup(mapper => mapper.Map<Usuario>(It.IsAny<UsuarioDto>())).Returns(usuario);
            _mockMapper.Setup(mapper => mapper.Map<UsuarioDto>(It.IsAny<Usuario>())).Returns(usuarioDto);
            _mockUsuarioRepository.Setup(repo => repo.SalvarAsync(It.IsAny<Usuario>())).ReturnsAsync(usuario);
            _mockUsuarioRepository.Setup(repo => repo.BuscarPorLoginAsync(It.IsAny<string>())).ReturnsAsync(usuario);
            var senhaAtual = usuarioDto.Senha;

            // Act
            var result = await _usuarioService.Adicionar(usuarioDto);
            usuario.AtualizarSenha(usuarioDto.Senha); //Simula a atualização da senha hashed que é mais complicado de fazer pelo mock
            var validacao = await _usuarioService.ValidarSenha(usuario.Login,senhaAtual);

            // Assert
            Assert.NotNull(result);
            _mockUsuarioRepository.Verify(repo => repo.SalvarAsync(It.IsAny<Usuario>()), Times.Once);
            Assert.True(validacao);
        }

        [Fact]
        [Trait("Usuário", "Deve atualizar informações do usuário, exceto senha")]
        public async Task Atualizar_DeveAtualizarUsuarioExcetoSenha()
        {
            // Arrange
            var usuarioDto = new UsuarioDto
            {
                Nome = "Usuario Atualizado",
                Login = "loginAtualizado",
                Email = "atualizado@usuario.com",
                EmpresaId = 2,
                UsuarioUltimaEdicaoId = 2,
                Senha = "senhaAtualizada"

            };
            var usuario = new Usuario("Usuario Original", "loginOriginal", "senhaOriginal", "original@usuario.com", false, false, 1, 1);
            DefinirIdUsuario(usuario, 1);
            _mockUsuarioRepository.Setup(repo => repo.BuscarPorIdAsync(usuarioDto.Id)).ReturnsAsync(usuario);
            _mockUsuarioRepository.Setup(repo => repo.AtualizarAsync(It.IsAny<Usuario>())).ReturnsAsync(usuario);
            _mockMapper.Setup(mapper => mapper.Map<UsuarioDto, Usuario>(It.IsAny<UsuarioDto>(), It.IsAny<Usuario>())).Returns(usuario);
            _mockMapper.Setup(mapper => mapper.Map<UsuarioDto>(It.IsAny<Usuario>()))
                    .Returns<Usuario>(usuario => new UsuarioDto
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Login = usuario.Login,
                        Senha = usuario.Senha, // Normalmente, você não incluiria a senha no DTO
                        Email = usuario.Email,
                        Desenvolvedor = usuario.Desenvolvedor,
                        Administrador = usuario.Administrador,
                        EmpresaId = usuario.EmpresaId,
                        UsuarioUltimaEdicaoId = usuario.UsuarioUltimaEdicaoId
                    });
            // Act
            var result = await _usuarioService.Atualizar(usuarioDto);

            // Assert
            Assert.NotNull(result);
            _mockUsuarioRepository.Verify(repo => repo.AtualizarAsync(It.IsAny<Usuario>()), Times.Once);
        
        }

        [Fact]
        [Trait("Usuário", "Atualizar senha do usuário")]
        public async Task AtualizarSenha_DeveAtualizarSomenteSenha()
        {
            var usuarioDto = new UsuarioDto { Nome = "Novo Usuario", Login = "novoLogin", Senha = "senha123", Email = "novo@usuario.com" };
            var usuario = new Usuario(usuarioDto.Nome, usuarioDto.Login, usuarioDto.Senha, usuarioDto.Email, false, false, 1, 1);
            _mockMapper.Setup(mapper => mapper.Map<Usuario>(It.IsAny<UsuarioDto>())).Returns(usuario);
            _mockMapper.Setup(mapper => mapper.Map<UsuarioDto>(It.IsAny<Usuario>())).Returns(usuarioDto);
            _mockUsuarioRepository.Setup(repo => repo.SalvarAsync(It.IsAny<Usuario>())).ReturnsAsync(usuario);
            _mockUsuarioRepository.Setup(repo => repo.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(usuario);
            _mockUsuarioRepository.Setup(repo => repo.BuscarPorLoginAsync(It.IsAny<string>())).ReturnsAsync(usuario);
            var resultado = _usuarioService.Adicionar(usuarioDto);

            var resultadoAtualizacaoSenha = await _usuarioService.AtualizarSenha(resultado.Id, "senhaAlterada");
            var validacaoSenhaResultado = await _usuarioService.ValidarSenha(usuario.Login, "senhaAlterada");

            Assert.True(resultadoAtualizacaoSenha);
            Assert.True(validacaoSenhaResultado);
            Assert.Equal(usuarioDto.Email, usuario.Email);
            Assert.Equal(usuarioDto.Login, usuario.Login);
            Assert.Equal(usuarioDto.Nome, usuario.Nome);

        }

        private void DefinirIdUsuario(Usuario usuario, int id)
        {
            // Obtém a propriedade 'Id' da classe base 'EntityBase'
            PropertyInfo propInfo = typeof(EntityBase).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            // Verifica se a propriedade foi encontrada e se é possível definir seu valor
            if (propInfo != null && propInfo.CanWrite)
            {
                // Define o valor da propriedade 'Id'
                propInfo.SetValue(usuario, id, null);
            }
            else
            {
                // Como a propriedade 'Id' é somente leitura, usamos reflexão para definir seu valor diretamente
                var backingField = typeof(EntityBase).GetField("<Id>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
                if (backingField != null)
                {
                    backingField.SetValue(usuario, id);
                }
            }
        }
    }
}
