using Demandas.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Demanda.Commands.Handlers
{
    internal class DeleteDemandaCommandHandler : IRequestHandler<DeleteDemandaCommand>
    {
        private readonly IDemandaService service;

        public DeleteDemandaCommandHandler(IDemandaService service)
        {
            this.service = service;
        }

        public async Task Handle(DeleteDemandaCommand request, CancellationToken cancellationToken)
        {
            await service.Remover(request.Id);
            
        }
    }
}
