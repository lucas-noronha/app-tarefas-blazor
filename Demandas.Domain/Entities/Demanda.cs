using Demandas.Domain.Enums;
using Demandas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Entities
{
    public sealed class Demanda : EntityBase
    {
        public Demanda(
            string titulo, 
            string descricao, 
            EnumStatusDemanda statusDemanda, 
            EnumTipoDemanda tipoDemanda, 
            int clienteId,
            bool? urgente,
            bool? importante, 
            int usuarioUltimaEdicaoId, 
            int empresaId) 
            : base(usuarioUltimaEdicaoId, empresaId)
        {
            UsuarioResponsavelId = usuarioUltimaEdicaoId;
            AtualizarEntidade(titulo,descricao,null,statusDemanda,tipoDemanda,urgente,importante,usuarioUltimaEdicaoId,usuarioUltimaEdicaoId,clienteId,empresaId);
        }

        public string Titulo { get; private set;}

        public string Descricao { get; private set; }

        public DateTime? DataFinalizacao { get; private set; }
        
        public EnumStatusDemanda Status { get; private set; }

        public EnumTipoDemanda TipoDemanda { get; private set;}

        public bool? Urgente { get; private set; }

        public bool? Importante { get; private set; }

        public void AtualizarEntidade(string titulo,
            string descricao,
            DateTime? dataFinalizacao,
            EnumStatusDemanda statusDemanda,
            EnumTipoDemanda tipoDemanda,
            bool? urgente,
            bool? importante,
            int usuarioResponsavelId,
            int usuarioUltimaEdicaoId,
            int clienteId,
            int empresaId)
        {
            var dataUltimaEdicao = DateTime.UtcNow;

            ValidarEntidade(titulo,descricao,dataFinalizacao,usuarioUltimaEdicaoId,clienteId);

            Titulo = titulo;
            Descricao = descricao;
            DataFinalizacao = dataFinalizacao;
            UsuarioResponsavelId = usuarioResponsavelId;
            Status = statusDemanda;
            TipoDemanda = tipoDemanda;
            Urgente = urgente;
            Importante = importante;
            ClienteId = clienteId;

            base.AtualizarEntidadeBase(dataUltimaEdicao,usuarioUltimaEdicaoId,empresaId);
        }


        void ValidarEntidade(
            string titulo,
            string descricao,
            DateTime? dataFinalizacao,
            int usuarioUltimaEdicaoId,
            int clienteId)
        {
            List<DomainValidationException> erros = new List<DomainValidationException>();

            if (string.IsNullOrWhiteSpace(titulo)) erros.Add(new DomainValidationException("O título da demanda é obrigatório."));
            else if (titulo.Length < 10) erros.Add(new DomainValidationException("O título precisa ter pelo menos 10 caracteres."));
            if (string.IsNullOrWhiteSpace(descricao)) erros.Add(new DomainValidationException("A descrição precisa ser informada."));
            else if (descricao.Length < 5) erros.Add(new DomainValidationException("A descrição precisa ter pelo menos 10 caracteres."));
            if (dataFinalizacao != null && dataFinalizacao > DateTime.UtcNow) erros.Add(new DomainValidationException("A data de finalização não pode ser maior que a data atual."));
            if (clienteId <= 0) erros.Add(new DomainValidationException("O ID do Cliente informado é inválido."));
            
            var retornos = base.ValidarEntidade(usuarioUltimaEdicaoId);
            erros.AddRange(retornos);

            if (erros.Any()) throw new DomainValidationException("Houveram erros na validação das informações.",erros);
            
        }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<AnexosDemanda> Anexos { get; set; } = new List<AnexosDemanda>();
        public int UsuarioResponsavelId { get; set; }
        public Usuario UsuarioResponsavel { get; set; }


    }
}
