using Demandas.Domain.DTOs;
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
            UsuarioUltimaEdicaoId = usuarioCriacao;
            EmpresaId = empresaId;
        }
        public int Id { get; }

        public DateTime DataCriacao { get; protected set; }

        public DateTime DataUltimaEdicao { get; protected set; }

        public int UsuarioCriacaoId { get; protected set; }
        public Usuario UsuarioCriacao { get; protected set; }

        public int UsuarioUltimaEdicaoId { get; protected set; }
        public Usuario UsuarioUltimaEdicao { get; protected set; }

        public int EmpresaId { get; private set; }
        public Empresa? Empresa { get; private set; }

        protected void AtualizarEntidadeBase(DateTime dataUltimaEdicao, int usuarioEdicaoId, int empresaId)
        {
            DataUltimaEdicao = dataUltimaEdicao;
            UsuarioUltimaEdicaoId = usuarioEdicaoId;
            EmpresaId = empresaId;
        }

        protected List<DomainValidationException> ValidarEntidade(DateTime dataUltimaEdicao, int usuarioUltimaEdicaoId)
        {
            List<DomainValidationException> erros = new List<DomainValidationException>();

            if (dataUltimaEdicao.Date < DateTime.UtcNow.Date) erros.Add(new DomainValidationException("A data da ultima edição é menor que a data atual."));
            if (usuarioUltimaEdicaoId <= 0) erros.Add(new DomainValidationException("O ID do usuário da ultima edição é inválido."));
            if (EmpresaId <= 0) erros.Add(new DomainValidationException("A empresa da entidade precisa ser informada"));

            return erros;
        }
    }
}
