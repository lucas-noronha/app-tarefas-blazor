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
    public class DemandaTest
    {
        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Demandas")]
        [Fact(DisplayName = "Criando Demanda Com Parâmetros Validos")]
        public void CriarDemanda_ComDadosValidos_RetornaDemandaCriada()
        {

            Action action = () =>
            {
                var dto = new DemandaDto(
                    "Demanda Teste",
                    "Demanda para testar dominio da demanda",
                    null,
                    1,
                    Enums.EnumStatusDemanda.Adicionada,
                    Enums.EnumTipoDemanda.NovoRecurso,
                    false,
                    false,
                    1,
                    1,
                    1);

                var demanda = new Demanda(dto);
            };

            action
                .Should()
                .NotThrow<DomainValidationException>();
        }

        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Demandas")]
        [Fact(DisplayName = "Criando Demanda Com Parâmetros Inválidos")]
        public void CriarDemanda_ComDadosInvalidos_RetornaDomainValidationException()
        {

            Action action = () =>
            {
                var dto = new DemandaDto(
                    "",
                    "",
                    null,
                    0,
                    Enums.EnumStatusDemanda.Adicionada,
                    Enums.EnumTipoDemanda.NovoRecurso,
                    false,
                    false,
                    0,
                    0,
                    0);

                var demanda = new Demanda(dto);
            };

            action
                .Should()
                .Throw<DomainValidationException>();
        }

        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Demandas")]
        [Fact(DisplayName = "Atualizar Demanda Com Parâmetros Validos")]
        public void AtualizarDemanda_ComDadosValidos_RetornaDemandaAtualizada()
        {
            var dto = new DemandaDto(
                    "Demanda Teste",
                    "Demanda para testar dominio da demanda",
                    null,
                    1,
                    Enums.EnumStatusDemanda.Adicionada,
                    Enums.EnumTipoDemanda.NovoRecurso,
                    false,
                    false,
                    1,
                    1,
                    1);

            var demanda = new Demanda(dto);


            
            var novoDto = new DemandaDto(
                    "Demanda Teste 2",
                    "Demanda para testar dominio da demanda 2",
                    DateTime.UtcNow,
                    2,
                    Enums.EnumStatusDemanda.Concluida,
                    Enums.EnumTipoDemanda.NovoRecurso,
                    false,
                    false,
                    2,
                    2,
                    2);


            demanda.AtualizarEntidade(novoDto);

            Assert.True(demanda.Titulo == novoDto.Titulo);
            Assert.True(demanda.Descricao == novoDto.Descricao);
            Assert.True(demanda.DataFinalizacao == novoDto.DataFinalizacao);
            Assert.True(demanda.Status == novoDto.Status);
            Assert.True(demanda.TipoDemanda == novoDto.TipoDemanda);
            Assert.True(demanda.Importante == novoDto.Importante);
            Assert.True(demanda.Urgente == novoDto.Urgente);
            Assert.True(demanda.EmpresaId ==  novoDto.EmpresaId);
            Assert.True(demanda.ClienteId == novoDto.ClienteId);
            Assert.True(demanda.UsuarioUltimaEdicaoId == novoDto.UsuarioUltimaEdicaoId);

            

        }
        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Demandas")]
        [Fact(DisplayName = "Atualizar Demanda Com Parâmetros Inválidos")]
        public void AtualizarDemanda_ComDadosInvalidos_RetornaDomainInvalidException()
        {

            var dto = new DemandaDto(
                    "Demanda Teste",
                    "Demanda para testar dominio da demanda",
                    null,
                    1,
                    Enums.EnumStatusDemanda.Adicionada,
                    Enums.EnumTipoDemanda.NovoRecurso,
                    false,
                    false,
                    1,
                    1,
                    1);

            var demanda = new Demanda(dto);

            var novoDto = new DemandaDto(
                    "",
                    "",
                    null,
                    0,
                    Enums.EnumStatusDemanda.Adicionada,
                    Enums.EnumTipoDemanda.NovoRecurso,
                    false,
                    false,
                    0,
                    0,
                    0);

            Assert.Throws<DomainValidationException>(() => demanda.AtualizarEntidade(novoDto));

        }
    }
}
