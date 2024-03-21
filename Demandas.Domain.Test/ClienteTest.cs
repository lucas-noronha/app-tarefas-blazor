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

    public class ClienteTest
    {

        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Clientes")]
        [Fact(DisplayName = "Criando Cliente Com Parâmetros Validos")]
        public void CriarCliente_ComDadosValidos_RetornaClienteCriado()
        {

            Action action = () =>
            {
                var dto = new ClienteDto("Cliente Teste", "88999247303", 1, 1);

                var empresa = new Cliente(dto);
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
                var dto = new ClienteDto("Te", "", 0, 0);

                var empresa = new Cliente(dto);
            };

            action
                .Should()
                .Throw<DomainValidationException>();
        }

        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Clientes")]
        [Fact(DisplayName = "Atualizar Cliente Com Parâmetros Validos")]
        public void AtualizarCliente_ComDadosValidos_RetornaClienteAtualizado()
        {

            var dto = new ClienteDto("teste 1", "999999999", 1, 1);
            var empresa = new Cliente(dto);

            dto.Nome = "Teste 2";
            dto.Contato = "88888888888";
            dto.EmpresaId = 2;
            dto.UsuarioUltimaEdicaoId = 2;

            empresa.AtualizarEntidade(dto);

            Assert.True(dto.Nome == empresa.Nome);
            Assert.True(dto.Contato== empresa.Contato);
            Assert.True(dto.EmpresaId== empresa.EmpresaId);
            Assert.True(dto.UsuarioUltimaEdicaoId== empresa.UsuarioUltimaEdicaoId);

        }
        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Clientes")]
        [Fact(DisplayName = "Atualizar Cliente Com Parâmetros Inválidos")]
        public void AtualizarCliente_ComDadosInvalidos_RetornaDomainInvalidException()
        {

            var dto = new ClienteDto("teste 1", "999999999", 1, 1);
            var empresa = new Cliente(dto);

            dto.Nome = "cl";
            dto.Contato = "";
            dto.EmpresaId = 0;
            dto.UsuarioUltimaEdicaoId = 0;

            Assert.Throws<DomainValidationException>(() => empresa.AtualizarEntidade(dto));

        }
    }
}
