using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.DTOs
{
    public class EmpresaDto : DtoBase
    {
        public EmpresaDto(string nome, string logo, int usuarioEdicaoId) : base(usuarioEdicaoId)
        { 
            Nome = nome;
            Logo = logo;
        }

        public string Nome { get; set; }

        public string Logo { get; set; }
    }
}
