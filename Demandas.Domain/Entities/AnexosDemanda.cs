using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Entities
{
    public class AnexosDemanda
    {

        public int Id { get; set; }

        public int DemandaId { get; set; }
        public Demanda Demanda { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

    }

}
