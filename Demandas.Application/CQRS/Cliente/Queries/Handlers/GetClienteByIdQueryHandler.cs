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
    internal class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, ClienteDto>
    {
        private readonly ClienteService service;

        public GetClienteByIdQueryHandler(ClienteService service)
        {
            this.service = service;
        }
        public async Task<ClienteDto> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            return await service.BuscarPorIdAsync(request.Id);
        }
    }
}
