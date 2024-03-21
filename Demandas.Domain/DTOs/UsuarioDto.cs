using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.DTOs
{
    public class UsuarioDto : DtoBase
    {
        public UsuarioDto(string nome, string login, string senha, string email, bool adm, bool dev,int usuarioUltimaEdicao, int empresaId) 
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Email = email;
            Administrador = adm;
            Desenvolvedor = dev;
            UsuarioUltimaEdicaoId = usuarioUltimaEdicao;
            EmpresaId = empresaId;
        }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string? Email { get; set; }

        public bool Administrador { get; set; }

        public bool Desenvolvedor { get; set; }

        public int EmpresaId { get; set; }
    }
}
