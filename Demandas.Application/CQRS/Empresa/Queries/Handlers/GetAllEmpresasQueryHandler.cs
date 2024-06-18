using Demandas.Application.DTOs;
using Demandas.Application.Interfaces;
using Demandas.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Empresa.Queries.Handlers
{
    internal class GetAllEmpresasQueryHandler : IRequestHandler<GetAllEmpresasQuery, List<EmpresaDto>>
    {
        private readonly IEmpresaService service;

        public GetAllEmpresasQueryHandler(IEmpresaService service)
        {
            this.service = service;
        }
        public async Task<List<EmpresaDto>> Handle(GetAllEmpresasQuery request, CancellationToken cancellationToken)
        {
            return (await service.BuscarListaAsync()).ToList();
        }
    }
}
