using Demandas.Application.DTOs;
using Demandas.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Demanda.Commands.Handlers
{
    internal class UpdateDemandaCommandHandler : IRequestHandler<UpdateDemandaCommand, DemandaDto>
    {
        private readonly IDemandaService service;

        public UpdateDemandaCommandHandler(IDemandaService service)
        {
            this.service = service;
        }

        public async Task<DemandaDto> Handle(UpdateDemandaCommand request, CancellationToken cancellationToken)
        {
            return (await service.Atualizar(request.DemandaInfo));
        }
    }
    
}
