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
    internal class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IUsuarioService service;

        public CreateUsuarioCommandHandler(IUsuarioService service)
        {
            this.service = service;
        }
        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            return (await service.Adicionar(request.UsuarioInfo)).Id;
        }
    }
}
