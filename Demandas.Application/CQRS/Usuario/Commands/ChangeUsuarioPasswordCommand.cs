using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Usuario.Commands
{
    public class ChangeUsuarioPasswordCommand : IRequest<bool>
    {
        public UsuarioAlterarSenhaDTO AlterarSenhaInfo { get; set; }

        public ChangeUsuarioPasswordCommand(UsuarioAlterarSenhaDTO alteracaoInfo)
        {
            
            AlterarSenhaInfo = alteracaoInfo;
        }
        public static ChangeUsuarioPasswordCommand CriarPorDto(UsuarioAlterarSenhaDTO dto) => new ChangeUsuarioPasswordCommand(dto);
    }
}
