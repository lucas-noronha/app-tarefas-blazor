using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Login { get; private set; }

        public string Senha { get; private set; }

        public string? Email { get; private set; }

        public bool Administrador { get; private set; }

        public bool Desenvolvedor { get; private set; }
    }
}
