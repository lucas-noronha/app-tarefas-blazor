using Demandas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase(int usuarioCriacao, int empresaId)
        {
            DataCriacao = DateTime.Now;
            DataUltimaEdicao = DateTime.Now;
            UsuarioCriacaoId = usuarioCriacao;
        }
        public int Id { get; }

        public DateTime DataCriacao { get; protected set; }

        public DateTime DataUltimaEdicao { get; protected set; }

       

        protected void AtualizarEntidadeBase(DateTime dataUltimaEdicao, int usuarioEdicaoId, int empresaId)
        {
            DataUltimaEdicao = dataUltimaEdicao;
            UsuarioUltimaEdicaoId = usuarioEdicaoId;
            EmpresaId = empresaId;
        }

        protected List<DomainValidationException> ValidarEntidade(int usuarioUltimaEdicaoId)
        {
            List<DomainValidationException> erros = new List<DomainValidationException>();

            if (usuarioUltimaEdicaoId <= 0) erros.Add(new DomainValidationException("O ID do usuário da ultima edição é inválido."));
            if (EmpresaId <= 0) erros.Add(new DomainValidationException("A empresa da entidade precisa ser informada"));

            return erros;
        }
        public int UsuarioCriacaoId { get; set; }
        public Usuario UsuarioCriacao { get; set; }

        public int UsuarioUltimaEdicaoId { get; set; }
        public Usuario UsuarioUltimaEdicao { get; set; }

        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
    }
}
