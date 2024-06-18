using Demandas.Application.DTOs;
using Demandas.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Usuario.Queries.Handlers
{
    internal class GetAllUsuariosQueryHandler : IRequestHandler<GetAllUsuariosQuery, List<UsuarioDto>>
    {
        private readonly IUsuarioService service;

        public GetAllUsuariosQueryHandler(IUsuarioService service)
        {
            this.service = service;
        }
        public async Task<List<UsuarioDto>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            return (await service.BuscarListaAsync()).ToList();
        }
    }
}
