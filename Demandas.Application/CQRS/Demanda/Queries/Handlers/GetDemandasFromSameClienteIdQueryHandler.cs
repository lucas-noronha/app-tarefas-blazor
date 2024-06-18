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
    internal class GetDemandasFromSameClienteIdQueryHandler : IRequestHandler<GetDemandasFromSameClienteIdQuery, List<DemandaDto>>
    {
        private readonly IDemandaService service;

        public GetDemandasFromSameClienteIdQueryHandler(IDemandaService service)
        {
            this.service = service;
        }
        public async Task<List<DemandaDto>> Handle(GetDemandasFromSameClienteIdQuery request, CancellationToken cancellationToken)
        {
            return (await service.BuscarListaComQueryAsync(d => d.ClienteId == request.ClienteId)).ToList();
        }
    }
}
