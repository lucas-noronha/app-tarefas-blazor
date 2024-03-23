using Demandas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demandas.Domain.Entities
{
    public sealed class Cliente : EntityBase
    {
        private Cliente()
        {}
        public Cliente(string nome, string contato, int empresaId, int usuarioUltimaEdicaoId) : base(usuarioUltimaEdicaoId, empresaId)
        {
            AtualizarEntidade(nome, contato, empresaId, usuarioUltimaEdicaoId);
        }

        public string Nome { get; private set; }

        public string? Contato { get; private set; }

        public void AtualizarEntidade(string nome, string contato, int empresaId, int usuarioUltimaEdicaoId)
        {
            var dataUltimaEdicao = DateTime.UtcNow;
            ValidarEntidade(nome, contato, empresaId, usuarioUltimaEdicaoId);

            Nome = nome;
            Contato = contato;
            base.AtualizarEntidadeBase(dataUltimaEdicao, usuarioUltimaEdicaoId, empresaId);

        }
        
        public void ValidarEntidade(string nome, string contato, int empresaId, int usuarioUltimaEdicaoId)
        {
            List<DomainValidationException> errors = new List<DomainValidationException>();

            if (string.IsNullOrWhiteSpace(nome)) errors.Add(new DomainValidationException("O nome do Cliente precisa ser informado."));
            else if (nome.Length < 5) errors.Add(new DomainValidationException("O nome do Cliente informado é muito curto."));
            if (empresaId <= 0) errors.Add(new DomainValidationException("A empresa do Cliente precisa ser informada."));

            errors.AddRange(base.ValidarEntidade(usuarioUltimaEdicaoId));

            if (errors.Any()) throw new DomainValidationException("Houveram erros ao validar o Cliente", errors);
        }
    }
}
