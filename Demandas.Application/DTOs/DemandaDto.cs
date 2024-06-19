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
    /// <summary>
    /// Representa uma demanda dentro do sistema, contendo todas as informações necessárias para o gerenciamento da mesma.
    /// </summary>
    public class DemandaDto
    {
        /// <summary>
        /// Identificador único da demanda.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título da demanda.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descrição detalhada da demanda.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Data de finalização da demanda, se aplicável.
        /// </summary>
        public DateTime? DataFinalizacao { get; set; }

        /// <summary>
        /// Identificador do usuário responsável pela demanda.
        /// </summary>
        public int UsuarioResponsavelId { get; set; }

        /// <summary>
        /// Status atual da demanda.
        /// Valores possíveis:
        /// 0 - Aberta: A demanda foi criada e está aguardando atendimento.
        /// 1 - EmAndamento: A demanda está sendo atendida.
        /// 2 - Concluida: A demanda foi concluída.
        /// 3 - Cancelada: A demanda foi cancelada.
        /// </summary>
        public EnumStatusDemanda Status { get; set; }

        /// <summary>
        /// Tipo da demanda.
        /// Valores possíveis:
        /// 1 - Interna: A demanda é interna à organização.
        /// 2 - Externa: A demanda é externa, vinda de um cliente ou parceiro.
        /// </summary>
        public EnumTipoDemanda TipoDemanda { get; set; }

        /// <summary>
        /// Indica se a demanda é considerada urgente.
        /// </summary>
        public bool? Urgente { get; set; }

        /// <summary>
        /// Indica se a demanda é considerada importante.
        /// </summary>
        public bool? Importante { get; set; }

        /// <summary>
        /// Identificador da empresa associada à demanda.
        /// </summary>
        public int EmpresaId { get; set; }

        /// <summary>
        /// Identificador do cliente associado à demanda.
        /// </summary>
        public int ClienteId { get; set; }

        /// <summary>
        /// Identificador do usuário que realizou a última edição na demanda.
        /// </summary>
        public int UsuarioUltimaEdicaoId { get; set; }
    }
}
