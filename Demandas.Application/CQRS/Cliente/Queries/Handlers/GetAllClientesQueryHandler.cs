using Demandas.Application.DTOs;
using Demandas.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Cliente.Queries.Handlers
{
    internal class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, List<ClienteDto>>
    {
        private readonly ClienteService service;

        public GetAllClientesQueryHandler(ClienteService service)
        {
            this.service = service;
        }
        public async Task<List<ClienteDto>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            return (await service.BuscarListaAsync()).ToList();
        }
    }
}
