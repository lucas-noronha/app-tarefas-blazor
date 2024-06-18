using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Demanda.Queries
{
    public class GetDemandasFromSameResponsavelIdQuery : IRequest<List<DemandaDto>>
    {
        public int ResponsavelId { get; set; }

        public GetDemandasFromSameResponsavelIdQuery(int responsavelId)
        {
            ResponsavelId = responsavelId;
        }

        public static GetDemandasFromSameResponsavelIdQuery CriarPorId(int responsavelId) => new GetDemandasFromSameResponsavelIdQuery(responsavelId);
    }
}
