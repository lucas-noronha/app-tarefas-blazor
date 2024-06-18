using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Empresa.Queries
{
    public class GetEmpresaByIdQuery : IRequest<EmpresaDto>
    {
        public GetEmpresaByIdQuery(int id)        
        {
            Id = id;
        }

        public int Id { get; }

        public static GetEmpresaByIdQuery CriarPorId(int id)
        {
            return new GetEmpresaByIdQuery(id);
        }
    }
}
