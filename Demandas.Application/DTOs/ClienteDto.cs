namespace Demandas.Application.DTOs
{
    public class ClienteDto
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public string? Contato { get; set; }

        public int EmpresaId { get; set; }
        public int UsuarioUltimaEdicaoId { get; set; }
    }
}