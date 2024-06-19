using Demandas.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Usuario.Commands.Handlers
{
    public class ChangeUsuarioPasswordCommandHandler : IRequestHandler<ChangeUsuarioPasswordCommand, bool>
    {
        private readonly IUsuarioService service;

        public ChangeUsuarioPasswordCommandHandler(IUsuarioService service)
        {
            this.service = service;
        }
        public async Task<bool> Handle(ChangeUsuarioPasswordCommand request, CancellationToken cancellationToken)
        {
            if(request.AlterarSenhaInfo == null)
            {
               throw new ArgumentNullException("Todas as informações de alteração precisam ser informadas!");
            }
            
            else if(!await service.ValidarSenha(request.AlterarSenhaInfo.Login, request.AlterarSenhaInfo.Senha))
            {
                throw new ArgumentException("A Senha informada não condiz com a senha atual!");
            }
            else if(request.AlterarSenhaInfo.NovaSenha != request.AlterarSenhaInfo.ConfirmacaoNovaSenha)
            {
                throw new InvalidDataException("A nova senha e a confirmação da nova senha não são iguais!");
            }

            var usuario = await service.BuscaPorLogin(request.AlterarSenhaInfo.Login);

            return await service.AtualizarSenha(usuario.Id, request.AlterarSenhaInfo.NovaSenha);



            
        }
    }
}
