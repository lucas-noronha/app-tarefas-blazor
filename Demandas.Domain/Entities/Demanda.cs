using Demandas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Entities
{
    sealed class Demanda
    {
        public int Id { get; }

        public string Titulo { get; private set;}

        public string Descricao { get; private set; }

        public DateTime DataCriacao { get ; private set;}

        public DateTime? DataFinalizacao { get; private set; }

        public int UsuarioCadastranteId { get; private set; }
        public Usuario UsuarioCadastrante { get; private set;}

        public int? UsuarioResponsavelId { get; private set; }
        public Usuario? UsuarioResponsavel { get; private set; }

        public EnumStatusDemanda Status { get; private set; }

        public EnumTipoDemanda TipoDemanda { get; private set;}

        public bool? Urgente { get; private set; }

        public bool? Importante { get; private set; }


        public int EmpresaId { get; private set; }
        public EmpresaCliente Empresa { get; private set; }

        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set;}
        public ICollection<AnexosDemanda> Anexos { get; set; } = new List<AnexosDemanda>();

    }
}
