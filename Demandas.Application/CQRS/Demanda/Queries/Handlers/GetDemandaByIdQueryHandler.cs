using Demandas.Application.DTOs;
using Demandas.Application.Interfaces;
using Demandas.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Demanda.Queries.Handlers
{
    internal class GetDemandaByIdQueryHandler : IRequestHandler<GetDemandaByIdQuery, DemandaDto>
    {
        private readonly IDemandaService service;

        public GetDemandaByIdQueryHandler(IDemandaService service)
        {
            this.service = service;
        }

        public async Task<DemandaDto> Handle(GetDemandaByIdQuery request, CancellationToken cancellationToken)
        {
            return await service.BuscarPorIdAsync(request.Id);
        }
    }
}
