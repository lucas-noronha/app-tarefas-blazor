using Demandas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.DTOs
{
    public abstract class DtoBase
    {
        public DateTime DataUltimaEdicao { get; set; }
        public int UsuarioUltimaEdicaoId { get; set; }

    }
}
