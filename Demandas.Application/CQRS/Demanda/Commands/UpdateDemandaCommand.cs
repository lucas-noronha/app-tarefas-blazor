using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Demanda.Commands
{
    public class UpdateDemandaCommand : IRequest<DemandaDto>
    {
        public UpdateDemandaCommand(DemandaDto demandaInfo)
        {
            DemandaInfo = demandaInfo;
        }
        public DemandaDto DemandaInfo { get; }

        public static UpdateDemandaCommand CriarPorDto(DemandaDto dto) => new UpdateDemandaCommand(dto);
    }
}
