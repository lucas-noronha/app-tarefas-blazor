using Demandas.Domain.DTOs;
using Demandas.Domain.Entities;
using Demandas.Domain.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Test
{
    public class UsuarioTest
    {

        [Trait("Usuário", "Teste de Validação da Criação E Atualização de Usuários")]
        [Fact(DisplayName = "Criando Usuários Com Parâmetros Validos")]
        public void CriarUsuario_ComDadosValidos_RetornaUsuarioCriado()
        {

            Action action = () =>
            {
                var dto = new UsuarioDto("Usuario Um", "login1", "senha123", "email@email", false, true, 1, 1);

                var empresa = new Usuario(dto);
            };

            action
                .Should()
                .NotThrow<DomainValidationException>();
        }

        [Trait("Usuário", "Teste de Validação da Criação E Atualização de Usuários")]
        [Fact(DisplayName = "Criando Usuários Com Parâmetros Inválidos")]
        public void CriarUsuario_ComDadosInvalidos_RetornaDomainValidationException()
        {

            Action action = () =>
            {
                var dto = new UsuarioDto("","","","",false,false,0,0);

                var empresa = new Usuario(dto);
            };

            action
                .Should()
                .Throw<DomainValidationException>();
        }

        [Trait("Usuário", "Teste de Validação da Criação E Atualização de Usuários")]
        [Fact(DisplayName = "Atualizar Usuários Com Parâmetros Validos")]
        public void AtualizarUsuario_ComDadosValidos_RetornaUsuarioCriado()
        {

            var dto = new UsuarioDto("Usuario Um", "login1", "senha123", "email@email", false, true, 1, 1);
            var empresa = new Usuario(dto);

            dto.Nome = "Usuario 2";
            dto.Login = "login2";
            dto.Senha = "senha321";
            dto.Email = "email1@email1";
            dto.Desenvolvedor = true;
            dto.Administrador = true;
            dto.UsuarioUltimaEdicaoId = 2;
            dto.EmpresaId = 1;

            empresa.AtualizarEntidade(dto);

            Assert.True(dto.Nome == "Usuario 2");
            Assert.True(dto.Login == "login2");
            Assert.True(dto.Senha == "senha321");
            Assert.True(dto.Email == "email1@email1");
            Assert.True(dto.Desenvolvedor == true);
            Assert.True(dto.Administrador == true);
            Assert.True(dto.UsuarioUltimaEdicaoId == 2);
            Assert.True(dto.EmpresaId == 1);


        }
        [Trait("Usuário", "Teste de Validação da Criação E Atualização de Usuários")]
        [Fact(DisplayName = "Atualizar Usuários Com Parâmetros Inválidos")]
        public void AtualizarUsuario_ComDadosInvalidos_RetornaDomainValidationException()
        {

            var dto = new UsuarioDto("Usuario Um", "login1", "senha123", "email@email", false, true, 1, 1);
            var empresa = new Usuario(dto);

            dto.Nome = "";
            dto.Login = "";
            dto.Senha = "";
            dto.Email = "";
            dto.Desenvolvedor = true;
            dto.Administrador = true;
            dto.UsuarioUltimaEdicaoId = 0;
            dto.EmpresaId = 0;

            Assert.Throws<DomainValidationException>(() => empresa.AtualizarEntidade(dto));

        }
    }
}
