using Demandas.Application.Interfaces;
using Demandas.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Usuario.Commands.Handlers
{
    internal class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand>
    {
        private readonly IUsuarioService service;

        public DeleteUsuarioCommandHandler(IUsuarioService service)
        {
            this.service = service;
        }
        public async Task Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            await service.Remover(request.Id);
        }
    }
}
