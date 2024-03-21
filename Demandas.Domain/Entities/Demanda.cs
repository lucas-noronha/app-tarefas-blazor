using Demandas.Domain.DTOs;
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
    public class Demanda : EntityBase
    {
        public Demanda(DemandaDto dto) : base(dto.UsuarioCadastranteId, dto.EmpresaId)
        {
            AtualizarEntidade(dto);
        }

        public string Titulo { get; private set;}

        public string Descricao { get; private set; }

        public DateTime? DataFinalizacao { get; private set; }
        
        public int UsuarioResponsavelId { get; private set; }
        public Usuario UsuarioResponsavel { get; private set; }

        public EnumStatusDemanda Status { get; private set; }

        public EnumTipoDemanda TipoDemanda { get; private set;}

        public bool? Urgente { get; private set; }

        public bool? Importante { get; private set; }


        public int EmpresaId { get; private set; }
        public Empresa Empresa { get; private set; }

        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set;}
        public ICollection<AnexosDemanda> Anexos { get; set; } = new List<AnexosDemanda>();

        public void AtualizarEntidade(DemandaDto dto)
        {
            var dataUltimaEdicao = DateTime.UtcNow;
            dto.DataUltimaEdicao = dataUltimaEdicao;

            ValidarEntidade(dto);

            Titulo = dto.Titulo;
            Descricao = dto.Descricao;
            DataFinalizacao = dto.DataFinalizacao;
            UsuarioResponsavelId = dto.UsuarioResponsavelId;
            Status = dto.Status;
            TipoDemanda = dto.TipoDemanda;
            Urgente = dto.Urgente;
            Importante = dto.Importante;
            EmpresaId = dto.EmpresaId;
            ClienteId = dto.ClienteId;

            base.AtualizarEntidadeBase(dto.DataUltimaEdicao, dto.UsuarioUltimaEdicaoId, dto.ClienteId);
        }


        void ValidarEntidade(DemandaDto dto)
        {
            List<DomainValidationException> erros = new List<DomainValidationException>();

            if (dto == null) throw new ArgumentNullException("Os dados para validação da entidade não foram fornecidos.");


            if (string.IsNullOrWhiteSpace(dto.Titulo)) erros.Add(new DomainValidationException("O título da demanda é obrigatório."));
            else if (dto.Titulo.Length < 10) erros.Add(new DomainValidationException("O título precisa ter pelo menos 10 caracteres."));
            if (string.IsNullOrWhiteSpace(dto.Descricao)) erros.Add(new DomainValidationException("A descrição precisa ser informada."));
            else if (dto.Descricao.Length < 5) erros.Add(new DomainValidationException("A descrição precisa ter pelo menos 10 caracteres."));
            if (dto.DataFinalizacao != null && dto.DataFinalizacao > DateTime.UtcNow) erros.Add(new DomainValidationException("A data de finalização não pode ser maior que a data atual."));
            if (dto.UsuarioResponsavelId <= 0) erros.Add(new DomainValidationException("O ID do usuário responsável precisa ser válido."));
            if (dto.EmpresaId <= 0) erros.Add(new DomainValidationException("A empresa do solicitante da demanda não é válida."));
            if (dto.ClienteId <= 0) erros.Add(new DomainValidationException("O ID do Cliente informado é inválido."));
            if (dto.UsuarioCadastranteId <= 0) erros.Add(new DomainValidationException("O ID do usuário cadastrante é inválido."));

            var retornos = base.ValidarEntidade(dto.DataUltimaEdicao, dto.UsuarioUltimaEdicaoId);
            erros.AddRange(retornos);

            if (erros.Any()) throw new DomainValidationException("Houveram erros na validação das informações.",erros);
            
        }

    }
}
