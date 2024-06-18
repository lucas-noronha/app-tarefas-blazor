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
    internal class GetDemandasFromSameResponsavelIdQueryHandler : IRequestHandler<GetDemandasFromSameResponsavelIdQuery, List<DemandaDto>>
    {
        private readonly IDemandaService service;

        public GetDemandasFromSameResponsavelIdQueryHandler(IDemandaService service)
        {
            this.service = service;
        }

        public async Task<List<DemandaDto>> Handle(GetDemandasFromSameResponsavelIdQuery request, CancellationToken cancellationToken)
        {

            return (await service.BuscarListaComQueryAsync(d => d.UsuarioResponsavelId == request.ResponsavelId)).ToList();
        }
    }
}
