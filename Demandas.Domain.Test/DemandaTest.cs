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
                var demanda = new Demanda("Demanda Teste",
                    "Demanda para testar dominio da demanda",
                    Enums.EnumStatusDemanda.Adicionada,
                    Enums.EnumTipoDemanda.NovoRecurso,
                    1,
                    false,
                    false,
                    1,
                    1);
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
                var demanda = new Demanda("",
                    "",
                    Enums.EnumStatusDemanda.Adicionada,
                    Enums.EnumTipoDemanda.NovoRecurso,
                    0,
                    false,
                    false,
                    0,
                    0);
            };

            action
                .Should()
                .Throw<DomainValidationException>();
        }

        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Demandas")]
        [Fact(DisplayName = "Atualizar Demanda Com Parâmetros Validos")]
        public void AtualizarDemanda_ComDadosValidos_RetornaDemandaAtualizada()
        {

            string titulo = "Demanda Teste testestsets";
            string descricao = "Demanda para testar dominio da demanda tetetstsete";
            int clienteId = 2;
            bool importante = false;
            bool urgente = true;
            int empresaId = 2;
            int usuarioEdicaoId = 2;
            DateTime dataFinalizacao = DateTime.UtcNow;

            var demanda = new Demanda("Demanda Teste",
                    "Demanda para testar dominio da demanda",
                    Enums.EnumStatusDemanda.Adicionada,
                    Enums.EnumTipoDemanda.NovoRecurso,
                    1,
                    false,
                    false,
                    1,
                    1);



            demanda.AtualizarEntidade(titulo, descricao, dataFinalizacao, Enums.EnumStatusDemanda.EmAndamento, Enums.EnumTipoDemanda.Bug, urgente, importante,usuarioEdicaoId,usuarioEdicaoId,clienteId,empresaId) ;

            Assert.True(demanda.Titulo == titulo);
            Assert.True(demanda.Descricao == descricao);
            Assert.True(demanda.DataFinalizacao == dataFinalizacao);
            Assert.True(demanda.Status == Enums.EnumStatusDemanda.EmAndamento);
            Assert.True(demanda.TipoDemanda == Enums.EnumTipoDemanda.Bug);
            Assert.True(demanda.Importante == importante);
            Assert.True(demanda.Urgente == urgente);
            Assert.True(demanda.EmpresaId == empresaId);
            Assert.True(demanda.ClienteId == clienteId);
            Assert.True(demanda.UsuarioUltimaEdicaoId == usuarioEdicaoId);



        }
        [Trait("Cliente", "Teste de Validação da Criação E Atualização de Demandas")]
        [Fact(DisplayName = "Atualizar Demanda Com Parâmetros Inválidos")]
        public void AtualizarDemanda_ComDadosInvalidos_RetornaDomainInvalidException()
        {

            string titulo = "De";
            string descricao = "de";
            int clienteId = 0;
            bool importante = false;
            bool urgente = true;
            int empresaId = 0;
            int usuarioEdicaoId = 0;

            var demanda = new Demanda("Demanda Teste",
                    "Demanda para testar dominio da demanda",
                    Enums.EnumStatusDemanda.Adicionada,
                    Enums.EnumTipoDemanda.NovoRecurso,
                    1,
                    false,
                    false,
                    1,
                    1);




            Assert.Throws<DomainValidationException>(() => demanda.AtualizarEntidade(titulo, descricao, null, Enums.EnumStatusDemanda.Recusada, Enums.EnumTipoDemanda.ModificacaoDeDados,urgente,importante,usuarioEdicaoId,usuarioEdicaoId,clienteId,empresaId)) ;

        }
    }
}
