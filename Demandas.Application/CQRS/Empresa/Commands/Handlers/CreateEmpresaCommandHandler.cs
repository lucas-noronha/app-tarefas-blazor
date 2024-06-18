using Demandas.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Empresa.Commands.Handlers
{
    internal class CreateEmpresaCommandHandler : IRequestHandler<CreateEmpresaCommand, int>
    {
        private readonly EmpresaService service;

        public CreateEmpresaCommandHandler(EmpresaService service)
        {
            this.service = service;
        }
        public async Task<int> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
        {
            return (await service.Adicionar(request.EmpresaInfos)).Id;
        }
    }
}
