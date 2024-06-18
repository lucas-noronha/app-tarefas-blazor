using Demandas.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Demanda.Commands.Handlers
{
    public class CreateDemandaCommandHandler : IRequestHandler<CreateDemandaCommand, int>
    {
        private readonly DemandaService service;

        public CreateDemandaCommandHandler(DemandaService service) 
        {
            this.service = service;
        }
        public async Task<int> Handle(CreateDemandaCommand request, CancellationToken cancellationToken)
        {
            return (await service.Adicionar(request.DemandaInfo)).Id;
        }
    }
}
