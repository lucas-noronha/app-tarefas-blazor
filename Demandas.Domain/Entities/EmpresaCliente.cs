namespace Demandas.Domain.Entities
{
    sealed class EmpresaCliente
    {
        public EmpresaCliente(string nome)
        {
            Nome = nome;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Logo { get; set; }

        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}
