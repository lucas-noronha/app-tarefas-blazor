using System;

namespace Demandas.Application.DTOs
{
    /// <summary>
    /// Representa uma empresa no sistema.
    /// </summary>
    public class EmpresaDto
    {
        /// <summary>
        /// Identificador único da empresa.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da empresa.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Caminho do arquivo de logo da empresa.
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Identificador do usuário que realizou a última edição nos dados da empresa.
        /// </summary>
        public int UsuarioUltimaEdicaoId { get; set; }
    }
}
