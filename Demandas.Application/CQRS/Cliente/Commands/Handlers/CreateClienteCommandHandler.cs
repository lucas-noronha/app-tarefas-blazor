using Demandas.Application.Interfaces;
using Demandas.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Cliente.Commands.Handlers
{
    internal class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
    {
        public readonly IClienteService _service;
        public CreateClienteCommandHandler(IClienteService service)
        {
            _service = service ?? throw new ArgumentNullException("O Service fornecido estava nulo!");
        }
        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var response = await _service.Adicionar(request.ClienteInfos);
            return response.Id;
        }
    }
}
