using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Demanda.Queries
{
    public class GetDemandaByIdQuery : IRequest<DemandaDto>
    {
        public int Id { get; }

        public GetDemandaByIdQuery(int id)
        {
            Id = id;
        }

        public static GetDemandaByIdQuery CriarPorId(int id) => new GetDemandaByIdQuery(id);

    }
}
