using Demandas.Domain.Entities;
using Demandas.Domain.Exceptions;
using FluentAssertions;

namespace Demandas.Domain.Test
{
    
    public class EmpresaTest
    {
        [Trait("Empresa", "Teste de Valida��o da Cria��o E Atualiza��o de Empresas")]
        [Fact(DisplayName ="Criando Empresa Com Par�metros Validos")]
        public void CriarEmpresa_ComDadosValidos_RetornaEmpresaCriada()
        {

            Action action = () =>
            {
                var empresa = new Empresa("Empresa Teste", "", 1);
            };

            action
                .Should()
                .NotThrow<AggregateException>();
        }

        [Trait("Empresa", "Teste de Valida��o da Cria��o E Atualiza��o de Empresas")]
        [Fact(DisplayName = "Criando Empresa Com Nome Inv�lido")]
        public void CriarEmpresa_ComNomeInvalido_RetornaDomainValidationException()
        {

            Action action = () =>
            {
                

                var empresa = new Empresa("Em", "", 1);
            };

            action
                .Should()
                .Throw<DomainValidationException>();
        }

        [Trait("Empresa", "Teste de Valida��o da Cria��o E Atualiza��o de Empresas")]
        [Fact(DisplayName = "Criando Empresa Com ID de Usu�rio Edi��o Inv�lido")]
        public void CriarEmpresa_ComUsuarioEdicaoInvalido_RetornaDomainValidationException()
        {

            Action action = () =>
            {
                var empresa = new Empresa("Empresa Teste", "", 0);
            };

            action
                .Should()
                .Throw<DomainValidationException>();
        }

        [Trait("Empresa", "Teste de Valida��o da Cria��o E Atualiza��o de Empresas")]
        [Fact(DisplayName = "Atualizando Empresa Com Dados V�lidos")]
        public void AtualizarEmpresa_ComDadosValidos_RetornarEmpresaPreenchida()
        {
            var empresa = new Empresa("Empresa Teste", "logopath", 1);

            //Act
            string nome = "Empresa Teste Atualizada";
            int usuarioUltimaEdicaoId = 2;
            empresa.AtualizarEntidade(nome, "", usuarioUltimaEdicaoId);

            //Assert
            Assert.True(nome == empresa.Nome);
            Assert.True("" == empresa.Logo);
            Assert.True(usuarioUltimaEdicaoId == empresa.UsuarioUltimaEdicaoId);
            Assert.True(usuarioUltimaEdicaoId != empresa.UsuarioCriacaoId);

        }

        [Trait("Empresa", "Teste de Valida��o da Cria��o E Atualiza��o de Empresas")]
        [Fact(DisplayName = "Atualizando Empresa Com Dados Invalidos")]
        public void AtualizarEmpresa_ComDadosInvalidos_RetornarDomainValidationException()
        {
            var empresa = new Empresa("Empresa Teste", "logopath", 1);

            string nome = "Em";
            int usuarioUltimaEdicaoId = 0;
           
            Assert.Throws<DomainValidationException>(() => empresa.AtualizarEntidade(nome, "", usuarioUltimaEdicaoId));

        }
    }
}