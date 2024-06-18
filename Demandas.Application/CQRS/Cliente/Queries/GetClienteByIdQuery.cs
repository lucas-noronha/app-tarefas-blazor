using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Cliente.Queries
{
    public class GetClienteByIdQuery : IRequest<ClienteDto>
    {
        public GetClienteByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public static GetClienteByIdQuery CriarPorId(int id)
        {
            return new GetClienteByIdQuery(id);
        }
    }
}
