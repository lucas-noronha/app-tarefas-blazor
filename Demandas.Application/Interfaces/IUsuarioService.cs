using Demandas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Interfaces
{
    public interface IUsuarioService : IServiceBase<UsuarioDto>
    {
        public Task<bool> AtualizarSenha(int usuarioId, string novaSenha);
        public Task<UsuarioDto> BuscaPorLogin(string login);
        public Task<bool> ValidarSenha(string login, string senhaFornecida);
    }
}
