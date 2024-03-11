using Demandas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Entities
{
    public class Demanda
    {

        public int Id { get; private set; }

        private string _titulo;
        public string Titulo { get
            {
                return _titulo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _titulo = value;
            }
        }

        public string Descricao { get; private set; }

        public DateTime DataCriacao { get; private set; }

        public DateTime? DataFinalizacao { get; private set; }

        public int UsuarioCadastranteId { get; set; }
        public Usuario UsuarioCadastrante { get; private set; }

        public int? UsuarioResponsavelId { get; set; }
        public Usuario? UsuarioResponsavel { get; private set; }

        public EnumStatusDemanda Status { get; private set; }

        public EnumTipoDemanda TipoDemanda { get; set; }

        public bool? Urgente { get; private set; }

        public bool? Importante { get; private set; }


    }
}
