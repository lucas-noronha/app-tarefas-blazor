using Demandas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Entities
{
    public sealed class Usuario : EntityBase
    {
        public Usuario(string nome, string login, string senha, string email, bool dev, bool adm, int usuarioUltimaEdicaoId, int empresaId) : base(usuarioUltimaEdicaoId,empresaId)
        {
            AtualizarEntidade(nome, login,senha,email,dev,adm,usuarioUltimaEdicaoId,empresaId);
        }

        public string Nome { get; private set; }

        public string Login { get; private set; }

        public string Senha { get; private set; }

        public string? Email { get; private set; }

        public bool Administrador { get; private set; }

        public bool Desenvolvedor { get; private set; }

        public void AtualizarEntidade(string nome, string login,string senha, string email, bool dev, bool adm, int usuarioUltimaEdicaoId, int empresaId)
        {
            DateTime dataUltimaEdicao = DateTime.UtcNow;
            ValidarEntidade(usuarioUltimaEdicaoId);

            Nome = nome;
            Login = login;
            Senha= senha;
            Email= email;
            Administrador= adm;
            Desenvolvedor = dev;
        }

        private void ValidarEntidade(string nome, string login, string senha, string email, bool dev, bool adm, int usuarioUltimaEdicaoId, int empresaId)
        {
            List<DomainValidationException> erros = new List<DomainValidationException>();

            if (string.IsNullOrWhiteSpace(nome)) erros.Add(new DomainValidationException("O Nome do usuário é uma informação obrigatória"));
            if (string.IsNullOrWhiteSpace(login)) erros.Add(new DomainValidationException("O Login do usuário é uma informação obrigatória"));
            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 6) erros.Add(new DomainValidationException("A Senha do usuário precisa ter no mínimo 6 caracteres"));

            var errosBase = base.ValidarEntidade(usuarioUltimaEdicaoId);
            if (errosBase != null) erros.AddRange(errosBase);

            if (erros.Any()) throw new DomainValidationException("Houveram erros na validação do Usuário", erros);
        }
    }
}
