namespace Demandas.Domain.DTOs
{
    public class ClienteDto : DtoBase
    {
        public string Nome { get; set; }

        public string? Contato { get; set; }

        public int EmpresaId { get; set; }
    }
}