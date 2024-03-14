using Demandas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Entities
{
    public class Demanda
    {

        private int _id;
        private string _titulo;
        private string _descricao;
        private DateTime _dataCriacao;
        private DateTime? _dataFinalizacao;
        private int _usuarioCadastranteId;
        private Usuario _usuarioCadastrante;
        private int? _usuarioResponsavelId;
        private Usuario _usuarioResponsavel;
        private int _status;
        private int _tipoDemanda;
        private bool? _urgente;
        private bool? _importante;

        private int _empresaId;
        private EmpresaCliente _empresa;

        private int _clienteId;
        private Cliente _cliente;
        public int Id { get => _id; }

        
        public string Titulo { get
            {
                return _titulo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _titulo = value;
            }
        }

        public string Descricao { get => _descricao; set { _descricao = value; } }

        public DateTime DataCriacao { get => _dataCriacao; set { _dataCriacao = value; } }

        public DateTime? DataFinalizacao { get => _dataFinalizacao; private set { _dataFinalizacao = value; } }

        public int UsuarioCadastranteId { get => _usuarioCadastranteId; set { _usuarioCadastranteId = value; } }
        public Usuario UsuarioCadastrante { get => _usuarioCadastrante; set { if (value == null) return; else { _usuarioCadastrante = value; } } }

        public int? UsuarioResponsavelId { get => _usuarioResponsavelId; set { _usuarioResponsavelId = value; } }
        public Usuario? UsuarioResponsavel { get => _usuarioCadastrante; set { _usuarioResponsavel = value; } }

        public EnumStatusDemanda Status { get => (EnumStatusDemanda)_status; set { _status = (int)value; } }

        public EnumTipoDemanda TipoDemanda { get => (EnumTipoDemanda)_tipoDemanda; set { _tipoDemanda = (int)value; } }

        public bool? Urgente { get => _urgente; set { _urgente = value; } }

        public bool? Importante { get => _importante; set { _importante = value; } }


        public int EmpresaId { get => _empresaId;
            set
            {
                if (value == 0) throw new ArgumentException("O ID da empresa solicitante precisa válido");
            }    
        }
        public EmpresaCliente Empresa { get; set; }

        public int ClienteId { 
            get => _clienteId;
            set 
            {
                if (_clienteId == 0) throw new InvalidDataException("O ID cliente precisa ser válido");
            }
        }
        public Cliente Cliente { 
            get => _cliente; 
            set 
            {
                if (value == null) return;

                _cliente = value;
            } 
        }
        public ICollection<AnexosDemanda> Anexos { get; set; } = new List<AnexosDemanda>();

    }
}
