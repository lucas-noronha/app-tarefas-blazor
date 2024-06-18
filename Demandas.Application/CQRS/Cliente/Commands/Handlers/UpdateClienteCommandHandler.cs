using Demandas.Application.DTOs;
using Demandas.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Cliente.Commands.Handlers
{
    internal class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, ClienteDto>
    {
        private readonly IClienteService service;

        public UpdateClienteCommandHandler(IClienteService service)
        {
            this.service = service;
        }
        public async Task<ClienteDto> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            return await service.Atualizar(request.ClienteInfos);
        }
    }
}
