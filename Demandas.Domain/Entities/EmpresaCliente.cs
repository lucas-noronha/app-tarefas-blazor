namespace Demandas.Domain.Entities
{
    public class EmpresaCliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Logo { get; set; }

        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}
