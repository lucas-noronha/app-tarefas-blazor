using Demandas.Domain.DTOs;
using Demandas.Domain.Entities;
using Demandas.Domain.Exceptions;
using FluentAssertions;

namespace Demandas.Domain.Test
{
    
    public class EmpresaTest
    {
        [Trait("Empresa", "Teste de Validação da Criação E Atualização de Empresas")]
        [Fact(DisplayName ="Criando Empresa Com Parâmetros Validos")]
        public void CriarEmpresa_ComDadosValidos_RetornaEmpresaCriada()
        {

            Action action = () =>
            {
                var dto = new EmpresaDto("Empresa Teste", "", 1);

                var empresa = new Empresa(dto);
            };

            action
                .Should()
                .NotThrow<AggregateException>();
        }

        [Trait("Empresa", "Teste de Validação da Criação E Atualização de Empresas")]
        [Fact(DisplayName = "Criando Empresa Com Nome Inválido")]
        public void CriarEmpresa_ComNomeInvalido_RetornaDomainValidationException()
        {

            Action action = () =>
            {
                var dto = new EmpresaDto("Em", "", 1);

                var empresa = new Empresa(dto);
            };

            action
                .Should()
                .Throw<DomainValidationException>();
        }

        [Trait("Empresa", "Teste de Validação da Criação E Atualização de Empresas")]
        [Fact(DisplayName = "Criando Empresa Com ID de Usuário Edição Inválido")]
        public void CriarEmpresa_ComUsuarioEdicaoInvalido_RetornaDomainValidationException()
        {

            Action action = () =>
            {
                var dto = new EmpresaDto("Empresa Teste", "", 0);

                var empresa = new Empresa(dto);
            };

            action
                .Should()
                .Throw<DomainValidationException>();
        }

        [Trait("Empresa", "Teste de Validação da Criação E Atualização de Empresas")]
        [Fact(DisplayName = "Atualizando Empresa Com Dados Válidos")]
        public void AtualizarEmpresa_ComDadosValidos_RetornarEmpresaPreenchida()
        {
            var dto = new EmpresaDto("Empresa Teste", "logopath", 1);
            var empresa = new Empresa(dto);

            //Act
            dto.Nome = "Empresa Teste Atualizada";
            dto.UsuarioUltimaEdicaoId = 2;
            empresa.AtualizarEntidade(dto);

            //Assert
            Assert.True(dto.Nome == empresa.Nome);
            Assert.True(dto.Logo == empresa.Logo);
            Assert.True(dto.UsuarioUltimaEdicaoId == empresa.UsuarioUltimaEdicaoId);
            Assert.True(empresa.UsuarioUltimaEdicaoId != empresa.UsuarioCriacaoId);

        }

        [Trait("Empresa", "Teste de Validação da Criação E Atualização de Empresas")]
        [Fact(DisplayName = "Atualizando Empresa Com Dados Invalidos")]
        public void AtualizarEmpresa_ComDadosInvalidos_RetornarDomainValidationException()
        {
            var dto = new EmpresaDto("Empresa Teste", "logopath", 1);
            var empresa = new Empresa(dto);

            dto.Nome = "Em";
            dto.UsuarioUltimaEdicaoId = 0;
           
            Assert.Throws<DomainValidationException>(() => empresa.AtualizarEntidade(dto));

        }
    }
}