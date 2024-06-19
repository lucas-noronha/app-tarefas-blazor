namespace Demandas.Application.DTOs
{
    /// <summary>
    /// Representa um cliente dentro do sistema, contendo informações básicas para identificação e contato.
    /// </summary>
    public class ClienteDto
    {
        /// <summary>
        /// Identificador único do cliente.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do cliente.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Informação de contato do cliente. Pode incluir telefone ou e-mail.
        /// </summary>
        public string? Contato { get; set; }

        /// <summary>
        /// Identificador da empresa à qual o cliente está associado.
        /// </summary>
        public int EmpresaId { get; set; }

        /// <summary>
        /// Identificador do usuário que realizou a última edição neste registro de cliente.
        /// </summary>
        public int UsuarioUltimaEdicaoId { get; set; }
    }
}