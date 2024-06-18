using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Cliente.Commands
{
    public class UpdateClienteCommand : IRequest<ClienteDto>
    {
        public ClienteDto ClienteInfos { get; set; }
        public UpdateClienteCommand(ClienteDto clienteInfos)
        {
            ClienteInfos = clienteInfos;
        }

        public static UpdateClienteCommand CriarPorDto(ClienteDto dto)
        {
            return new UpdateClienteCommand(dto);
        }
    }
}
