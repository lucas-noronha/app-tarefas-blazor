using Demandas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demandas.Domain.Entities
{
    sealed class Cliente
    {

        public Cliente(string nome, string contato, int empresaId, EmpresaCliente empresa)
        {
            Nome = nome;
            Contato = contato;
            Empresa = empresa;
            if (empresa != null) DomainValidationException.ThrowWhen(empresaId != empresa.Id, "O ID da empresa é inconsistente.");
            ValidarEntidade(Nome, EmpresaId);
        }
        public int Id { get; }

        public string Nome { get; private set; }

        public string? Contato { get; private set; }

        public int EmpresaId { get; private set; }
        public EmpresaCliente? Empresa { get; private set; }

        public void SetNome(string nome)
        {
            ValidarNome(nome);
            Nome = nome;
        }

        public void SetEmpresaId(int empresaId)
        {
            ValidarEmpresa(empresaId);
            EmpresaId = empresaId;
        }

        private void ValidarEntidade(string nome, int empresaId)
        {
            List<DomainValidationException> erros = new List<DomainValidationException>();

            ValidarNome(nome, erros);
            ValidarEmpresa(empresaId, erros);
            

            if (erros.Any())
            {
                throw new AggregateException("Ocorreram erros na validação do Cliene, por favor, corrija e tente novamente", erros);
            }
        }

        private void ValidarNome(string nome, List<DomainValidationException> listaErros = null)
        {
            List<DomainValidationException> erros = listaErros ?? new List<DomainValidationException>();
            
            if (nome.Length < 3) erros.Add(new DomainValidationException("O Nome do Cliente é muito curto."));
            else if (string.IsNullOrWhiteSpace(nome)) erros.Add(new DomainValidationException("O Nome do Cliente precisa ser informado"));

            if (listaErros == null && erros.Any()) throw new AggregateException("Erros ao validar nome.", erros);
        }

        private void ValidarEmpresa(int empresaId, List<DomainValidationException> listaErros = null)
        {
            List<DomainValidationException> erros = listaErros ?? new List<DomainValidationException>();

            if (empresaId < 0) erros.Add(new DomainValidationException("O ID da empresa do Cliente deve ser válido."));

            if (listaErros == null && erros.Any()) throw new AggregateException("Erros ao validar ID da empresa do Cliente.", erros);

        }

    }
}
