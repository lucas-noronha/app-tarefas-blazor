using AutoMapper;
using Demandas.Application.DTOs;
using Demandas.Application.Services;
using Demandas.Domain.Entities;
using Demandas.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Test.ServiceTests
{
    public class EmpresaServiceTest
    {

        private readonly EmpresaService _empresaService;
        private readonly Mock<IEmpresaRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        public EmpresaServiceTest()
        {
            _mockRepository = new Mock<IEmpresaRepository>();
            _mockMapper = new Mock<IMapper>();
            _empresaService = new EmpresaService(_mockMapper.Object, _mockRepository.Object);
        }


        [Fact]
        [Trait("Empresa", "Buscar empresa por ID")]
        public async Task BuscarPorId_DeveRetornarEmpresa_QuandoEmpresaExiste()
        {
            // Arrange
            var empresa = new Empresa("Empresa 1", "logo1", 1);
            var empresaDto = new EmpresaDto { Nome = empresa.Nome, Logo = empresa.Logo, UsuarioUltimaEdicaoId = empresa.UsuarioUltimaEdicaoId, Id = empresa.Id };
            _mockRepository.Setup(repo => repo.BuscarPorIdAsync(1)).ReturnsAsync(empresa);
            _mockMapper.Setup(mapper => mapper.Map<EmpresaDto>(empresa)).Returns(empresaDto);

            // Act
            var result = await _empresaService.BuscarPorIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(empresa.Nome, result.Nome);
        }

        [Fact]
        [Trait("Empresa", "Testando buscar todas as empresas")]
        public async Task BuscarTodos_DeveRetornarTodasEmpresas()
        {
            // Arrange
            var empresas = new List<Empresa>
            {
                new Empresa("Empresa 1", "logo1", 1),
                new Empresa("Empresa 2", "logo2", 1)
            };

            List<EmpresaDto> empresaDtos = empresas.Select(e => new EmpresaDto { Nome = e.Nome, Logo = e.Logo, UsuarioUltimaEdicaoId = e.UsuarioUltimaEdicaoId, Id = e.Id }).ToList();

            _mockRepository.Setup(repo => repo.ListarQueryAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Empresa, bool>>>())).ReturnsAsync(empresas);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<EmpresaDto>>(It.IsAny<IEnumerable<Empresa>>())).Returns(empresaDtos);

            // Act
            var result = await _empresaService.BuscarListaAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(empresas.Count, result.Count());

        }

        [Fact]
        [Trait("Empresa", "Testando adicionar empresa")]
        public async Task Adicionar_DeveAdicionarEmpresa()
        {
            // Arrange
            var empresaDto = new EmpresaDto { Nome = "Nova Empresa", Logo = "logo", UsuarioUltimaEdicaoId = 1 };
            var empresa = new Empresa(empresaDto.Nome, empresaDto.Logo, empresaDto.UsuarioUltimaEdicaoId);
            _mockMapper.Setup(mapper => mapper.Map<Empresa>(It.IsAny<EmpresaDto>())).Returns(empresa);
            _mockMapper.Setup(mapper => mapper.Map<EmpresaDto>(It.IsAny<Empresa>())).Returns(empresaDto);
            _mockRepository.Setup(repo => repo.SalvarAsync(It.IsAny<Empresa>())).ReturnsAsync(empresa);

            // Act
            var result = await _empresaService.Adicionar(empresaDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(empresaDto.Nome, result.Nome);
            _mockRepository.Verify(repo => repo.SalvarAsync(It.IsAny<Empresa>()), Times.Once);
        }

        [Fact]
        [Trait("Empresa", "Testando atualizar empresa")]
        public async Task Atualizar_DeveAtualizarEmpresa()
        {
            // Arrange
            var empresaDto = new EmpresaDto { Nome = "Empresa Atualizada", Logo = "logo", UsuarioUltimaEdicaoId = 1 };
            var empresa = new Empresa(empresaDto.Nome, empresaDto.Logo, empresaDto.UsuarioUltimaEdicaoId);
            _mockMapper.Setup(mapper => mapper.Map<Empresa>(It.IsAny<EmpresaDto>())).Returns(empresa);
            _mockMapper.Setup(mapper => mapper.Map<EmpresaDto>(It.IsAny<Empresa>())).Returns(empresaDto);
            _mockRepository.Setup(repo => repo.AtualizarAsync(It.IsAny<Empresa>())).ReturnsAsync(empresa);

            // Act
            var result = await _empresaService.Atualizar(empresaDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(empresaDto.Nome, result.Nome);
            _mockRepository.Verify(repo => repo.AtualizarAsync(It.IsAny<Empresa>()), Times.Once);
        }

        [Fact]
        [Trait("Empresa", "Testando buscar empresas com query")]
        public async Task BuscarComQuery_DeveRetornarEmpresas_QuandoEmpresasExistem()
        {
            // Arrange
            var empresas = new List<Empresa>
            {
                new Empresa("Empresa 1", "logo1", 1),
                new Empresa("Empresa 2", "logo2", 1)
            };

            List<EmpresaDto> empresaDtos = empresas.Select(e => new EmpresaDto { Nome = e.Nome, Logo = e.Logo, UsuarioUltimaEdicaoId = e.UsuarioUltimaEdicaoId, Id = e.Id }).ToList();

            _mockRepository.Setup(repo => repo.ListarQueryAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Empresa, bool>>>())).ReturnsAsync(empresas);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<EmpresaDto>>(It.IsAny<IEnumerable<Empresa>>())).Returns(empresaDtos);

            // Act
            var result = await _empresaService.BuscarListaComQueryAsync(x => true);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(empresas.Count, result.Count());
        }

        [Fact]
        [Trait("Empresa", "Testando remover empresa")]
        public async Task Remover_DeveRemoverEmpresa()
        {
            // Arrange
            var empresa = new Empresa("Empresa 1", "logo1", 1);
            _mockRepository.Setup(repo => repo.BuscarPorIdAsync(1)).ReturnsAsync(empresa);
            _mockRepository.Setup(repo => repo.Deletar(It.IsAny<int>()));

            // Act
            await _empresaService.Remover(1);

            // Assert
            _mockRepository.Verify(repo => repo.Deletar(It.IsAny<int>()), Times.Once);
        }

    }
}
