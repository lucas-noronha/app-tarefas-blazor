namespace Demandas.Domain.DTOs
{
    public class ClienteDto : DtoBase
    {
        public ClienteDto(string nome, string? contato, int empresaId, int usuarioUltimaEdicaoId) : base(usuarioUltimaEdicaoId)
        {
            Nome = nome;
            Contato = contato;
            EmpresaId = empresaId;
        }
        public string Nome { get; set; }

        public string? Contato { get; set; }

        public int EmpresaId { get; set; }
    }
}