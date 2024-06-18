using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Usuario.Queries
{
    public class GetUsuarioByIdQuery : IRequest<UsuarioDto>
    {
        public GetUsuarioByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public static GetUsuarioByIdQuery CriarPorId(int id) => new GetUsuarioByIdQuery(id);
    }
}
