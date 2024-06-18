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
    internal class GetEmpresaByIdQueryHandler : IRequestHandler<GetEmpresaByIdQuery, EmpresaDto>
    {
        private readonly IEmpresaService service;

        public GetEmpresaByIdQueryHandler(IEmpresaService service)
        {
            this.service = service;
        }
        public async Task<EmpresaDto> Handle(GetEmpresaByIdQuery request, CancellationToken cancellationToken)
        {
            return await service.BuscarPorIdAsync(request.Id);
        }
    }
}
