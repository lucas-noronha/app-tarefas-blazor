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

                var usuario = new Usuario("Usuario Um", "login1", "senha123", "email@email", false, true, 1, 1);
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
                var usuario = new Usuario("", "", "", "", false, false, 0, 0);
            };

            action
                .Should()
                .Throw<DomainValidationException>();
        }

        [Trait("Usuário", "Teste de Validação da Criação E Atualização de Usuários")]
        [Fact(DisplayName = "Atualizar Usuários Com Parâmetros Validos")]
        public void AtualizarUsuario_ComDadosValidos_RetornaUsuarioCriado()
        {

            var usuario = new Usuario("Usuario Um", "login1", "senha123", "email@email", false, true, 1, 1);

            string nome = "Usuario 2";
            string login = "login2";
            string senha = "senha321";
            string email = "email1@email1";
            bool desenvolvedor = true;
            bool administrador = true;
            int usuarioUltimaEdicaoId = 2;
            int empresaId = 1;

            usuario.AtualizarEntidade(nome,login,senha,email,desenvolvedor,administrador,usuarioUltimaEdicaoId,empresaId);

            Assert.True(usuario.Nome == "Usuario 2");
            Assert.True(usuario.Login == "login2");
            Assert.True(usuario.Senha == "senha321");
            Assert.True(usuario.Email == "email1@email1");
            Assert.True(usuario.Desenvolvedor == true);
            Assert.True(usuario.Administrador == true);
            Assert.True(usuario.UsuarioUltimaEdicaoId == 2);
            Assert.True(usuario.EmpresaId == 1);


        }
        [Trait("Usuário", "Teste de Validação da Criação E Atualização de Usuários")]
        [Fact(DisplayName = "Atualizar Usuários Com Parâmetros Inválidos")]
        public void AtualizarUsuario_ComDadosInvalidos_RetornaDomainValidationException()
        {
            var usuario = new Usuario("Usuario Um", "login1", "senha123", "email@email", false, true, 1, 1);

            string nome = "";
            string login = "";
            string senha = "";
            string email = "";
            bool desenvolvedor = true;
            bool administrador = true;
            int usuarioUltimaEdicaoId = 0;
            int empresaId = 0;

            Assert.Throws<DomainValidationException>(() => usuario.AtualizarEntidade(nome, login,senha,email,desenvolvedor,administrador,usuarioUltimaEdicaoId,empresaId));

        }
    }
}
