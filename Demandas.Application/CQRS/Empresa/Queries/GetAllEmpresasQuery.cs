using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Empresa.Queries
{
    public class GetAllEmpresasQuery : IRequest<List<EmpresaDto>>
    {
    }
}
