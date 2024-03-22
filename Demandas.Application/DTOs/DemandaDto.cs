using Demandas.Domain.Entities;
using Demandas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.DTOs
{
    public class DemandaDto
    {
        public int Id { get; set; }
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

        public int UsuarioUltimaEdicaoId { get; set; }
    }
}
