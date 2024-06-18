using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Usuario.Commands
{
    internal class UpdateUsuarioCommand : IRequest<UsuarioDto>
    {
        public UsuarioDto UsuarioInfos { get; set; }
        public UpdateUsuarioCommand(UsuarioDto infos)
        {
            UsuarioInfos = infos;
        }

        public static UpdateUsuarioCommand CriarPorDto(UsuarioDto dto) => new UpdateUsuarioCommand(dto);
    }
}
