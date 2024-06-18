using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Cliente.Commands
{
    public class CreateClienteCommand : IRequest<int>
    {
        public ClienteDto ClienteInfos { get; set; }

        public CreateClienteCommand(ClienteDto infos)
        {
            ClienteInfos = infos;
        }

        public static CreateClienteCommand CriarPorDto(ClienteDto dto)
        {
            return new CreateClienteCommand(dto);
        }
    }
}
