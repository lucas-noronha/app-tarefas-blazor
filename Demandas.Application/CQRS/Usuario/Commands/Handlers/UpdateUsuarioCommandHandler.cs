using Demandas.Application.DTOs;
using Demandas.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Usuario.Commands.Handlers
{
    internal class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, UsuarioDto>
    {
        private readonly UsuarioService service;

        public UpdateUsuarioCommandHandler(UsuarioService service)
        {
            this.service = service;
        }
        public async Task<UsuarioDto> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            return await service.Atualizar(request.UsuarioInfos);
        }
    }
}
