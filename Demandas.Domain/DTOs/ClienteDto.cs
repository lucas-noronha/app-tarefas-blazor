namespace Demandas.Domain.DTOs
{
    public class ClienteDto : DtoBase
    {
        public ClienteDto(string nome, string? contato, int empresaId, int usuarioUltimaEdicaoId) 
        {
            Nome = nome;
            Contato = contato;
            EmpresaId = empresaId;
            UsuarioUltimaEdicaoId = usuarioUltimaEdicaoId;
        }
        public string Nome { get; set; }

        public string? Contato { get; set; }

        public int EmpresaId { get; set; }
    }
}