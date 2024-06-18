﻿using Demandas.Application.DTOs;
using Demandas.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Demanda.Queries.Handlers
{
    internal class GetAllDemandasQueryHandler : IRequestHandler<GetAllDemandasQuery, List<DemandaDto>>
    {
        private readonly DemandaService service;

        public GetAllDemandasQueryHandler(DemandaService service)
        {
            this.service = service;
        }

        public async Task<List<DemandaDto>> Handle(GetAllDemandasQuery request, CancellationToken cancellationToken)
        {
            return (await service.BuscarListaAsync()).ToList();
        }
    }
}
