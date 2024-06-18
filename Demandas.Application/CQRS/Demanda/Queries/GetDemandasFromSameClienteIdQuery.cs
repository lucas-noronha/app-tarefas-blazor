using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Demanda.Queries
{
    public class GetDemandasFromSameClienteIdQuery : IRequest<List<DemandaDto>>
    {
        public int ClienteId { get; }

        public GetDemandasFromSameClienteIdQuery(int clienteId)
        {
            ClienteId = clienteId;
        }

        public static GetDemandasFromSameClienteIdQuery CriarPorClienteId(int clienteId) => new GetDemandasFromSameClienteIdQuery(clienteId);
    }
}
