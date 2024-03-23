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

    public class ClienteTest
    {

        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Clientes")]
        [Fact(DisplayName = "Criando Cliente Com Parâmetros Validos")]
        public void CriarCliente_ComDadosValidos_RetornaClienteCriado()
        {

            Action action = () =>
            {
                var cliente = new Cliente("Cliente Premium", "", 1, 1);
            };

            action
                .Should()
                .NotThrow<DomainValidationException>();
        }

        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Clientes")]
        [Fact(DisplayName = "Criando Cliente Com Parâmetros Inválidos")]
        public void CriarCliente_ComDadosInvalidos_RetornaDomainValidationException()
        {

            Action action = () =>
            {
                var cliente = new Cliente("Cl", "", 0, 0);
            };

            action
                .Should()
                .Throw<DomainValidationException>();
        }

        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Clientes")]
        [Fact(DisplayName = "Atualizar Cliente Com Parâmetros Validos")]
        public void AtualizarCliente_ComDadosValidos_RetornaClienteAtualizado()
        {
            string nome = "Cliente Premium";
            string contato = "889999999";
            int empresa = 1;
            int usuarioEdicaoId = 1;

            var cliente = new Cliente(nome, contato, empresa, usuarioEdicaoId);

            nome = "Cliente";
            contato = "998888888";
            empresa = 2;
            usuarioEdicaoId = 2;

            cliente.AtualizarEntidade(nome, contato, empresa, usuarioEdicaoId);

            Assert.True(nome == cliente.Nome);
            Assert.True(contato== cliente.Contato);
            Assert.True(empresa== cliente.EmpresaId);
            Assert.True(usuarioEdicaoId== cliente.UsuarioUltimaEdicaoId);

        }
        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Clientes")]
        [Fact(DisplayName = "Atualizar Cliente Com Parâmetros Inválidos")]
        public void AtualizarCliente_ComDadosInvalidos_RetornaDomainInvalidException()
        {


            string nome = "Cliente Premium";
            string contato = "889999999";
            int empresa = 1;
            int usuarioEdicaoId = 1;

            var cliente = new Cliente(nome, contato, empresa, usuarioEdicaoId);


            nome = "Cl";
            contato = "";
            empresa = 0;
            usuarioEdicaoId = 0;

            Action action = () =>
            {
                cliente.AtualizarEntidade(nome, contato, empresa, usuarioEdicaoId);
            };

            action.Should().Throw<DomainValidationException>();

        }
    }
}
