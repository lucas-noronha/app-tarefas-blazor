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
    internal class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioDto>
    {
        private readonly IUsuarioService service;

        public GetUsuarioByIdQueryHandler(IUsuarioService service)
        {
            this.service = service;
        }
        public async Task<UsuarioDto> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
               
            return await service.BuscarPorIdAsync(request.Id);   
        }
    }
}
