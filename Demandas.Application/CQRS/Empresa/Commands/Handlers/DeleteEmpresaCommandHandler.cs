using Demandas.Application.Interfaces;
using Demandas.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Empresa.Commands.Handlers
{
    internal class DeleteEmpresaCommandHandler : IRequestHandler<DeleteEmpresaCommand>
    {
        private readonly IEmpresaService service;

        public DeleteEmpresaCommandHandler(IEmpresaService service)
        {
            this.service = service;
        }
        public async Task Handle(DeleteEmpresaCommand request, CancellationToken cancellationToken)
        {
            await service.Remover(request.Id);            
        }
    }
}
