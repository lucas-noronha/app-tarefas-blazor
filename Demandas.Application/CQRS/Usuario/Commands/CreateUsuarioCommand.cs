using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Usuario.Commands
{
    public class CreateUsuarioCommand : IRequest<int>
    {
        public CreateUsuarioCommand(UsuarioDto UsuarioInfo)
        {
            this.UsuarioInfo = UsuarioInfo;
        }

        public UsuarioDto UsuarioInfo { get; }

        public static CreateUsuarioCommand CriarPorDto(UsuarioDto dto) => new CreateUsuarioCommand(dto);
    }
}
