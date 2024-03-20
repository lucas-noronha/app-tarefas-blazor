using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.DTOs
{
    public class EmpresaDto : DtoBase
    {
        public EmpresaDto(string nome, string logo, int usuarioEdicaoId) 
        { 
            Nome = nome;
            Logo = logo;
            UsuarioUltimaEdicaoId = usuarioEdicaoId;
        }

        public string Nome { get; set; }

        public string Logo { get; set; }
    }
}
