using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Demanda.Commands
{
    
    public class CreateDemandaCommand : IRequest<int>
    {
        public CreateDemandaCommand(DemandaDto demandaInfo)
        {
            DemandaInfo = demandaInfo;
        }
        public DemandaDto DemandaInfo { get; }

        public static CreateDemandaCommand CriarPorId(DemandaDto dto) => new CreateDemandaCommand(dto);

    }
}
