using Demandas.Application.DTOs;
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
    internal class UpdateEmpresaCommandHandler : IRequestHandler<UpdateEmpresaCommand, EmpresaDto>
    {
        private readonly IEmpresaService service;

        public UpdateEmpresaCommandHandler(IEmpresaService service)
        {
            this.service = service;
        }
        public async Task<EmpresaDto> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
        {
            return (await service.Atualizar(request.EmpresaInfo));
        }
    }
}
