using Demandas.Application.Interfaces;
using Demandas.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Cliente.Commands.Handlers
{
    internal class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand>
    {
        private readonly IClienteService service;

        public DeleteClienteCommandHandler(IClienteService service)
        {
            this.service = service;
        }
        public async Task Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            await service.Remover(request.Id);
        }
    }
}
