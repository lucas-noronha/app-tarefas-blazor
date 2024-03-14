using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Contato { get; set; }

        public int EmpresaId { get; set; }
        public EmpresaCliente Empresa { get; set; }



    }

    public class EmpresaCliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Logo { get; set; }

        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}
