using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string? Email { get; set; }

        public bool Administrador { get; set; }

        public bool Desenvolvedor { get; set; }

        public int EmpresaId { get; set; }

        public int UsuarioUltimaEdicaoId { get; set; }
    }
}
