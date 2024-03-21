using Demandas.Domain.Entities;
using Demandas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.DTOs
{
    public class DemandaDto : DtoBase
    {
        public DemandaDto(
            string titulo,
            string descricao,
            DateTime? finalizacao,
            int usuarioResponsavelId,
            EnumStatusDemanda status,
            EnumTipoDemanda tipoDemanda,
            bool urgente,
            bool importante,
            int empresaId,
            int clienteId,
            int usuarioUltimaEdicao
            ) : base(usuarioUltimaEdicao)
        {
            Titulo = titulo ;
            Descricao = descricao;
            DataFinalizacao = finalizacao;
            UsuarioResponsavelId = usuarioResponsavelId;
            Status = (EnumStatusDemanda)status;
            TipoDemanda = (EnumTipoDemanda)tipoDemanda;
            Urgente = urgente;
            Importante = importante;
            EmpresaId = empresaId;
            ClienteId = clienteId;
        }
        


        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataFinalizacao { get; set; }
        public int UsuarioResponsavelId { get; set; }

        public EnumStatusDemanda Status { get; set; }

        public EnumTipoDemanda TipoDemanda { get; set; }

        public bool? Urgente { get; set; }

        public bool? Importante { get; set; }

        public int EmpresaId { get; set; }

        public int ClienteId { get; set; }

        //public static DemandaDto CriarPorEntidade(Demanda demanda)
        //{
        //    return new DemandaDto(
        //        demanda.Titulo,
        //        demanda.Descricao,
        //        demanda.DataFinalizacao,
        //        demanda.UsuarioResponsavelId,
        //        (int)demanda.Status,
        //        (int)demanda.TipoDemanda,
        //        demanda.Urgente.GetValueOrDefault(),
        //        demanda.Importante.GetValueOrDefault(),
        //        demanda.EmpresaId,
        //        demanda.ClienteId);
        //}
    }
}
