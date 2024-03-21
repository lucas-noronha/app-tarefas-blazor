using Demandas.Domain.DTOs;
using Demandas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario(UsuarioDto dto) : base(dto.UsuarioUltimaEdicaoId, dto.EmpresaId)
        {
            AtualizarEntidade(dto);
        }

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Login { get; private set; }

        public string Senha { get; private set; }

        public string? Email { get; private set; }

        public bool Administrador { get; private set; }

        public bool Desenvolvedor { get; private set; }

        public void AtualizarEntidade(UsuarioDto dto)
        {
            DateTime dataUltimaEdicao = DateTime.UtcNow;
            dto.DataUltimaEdicao = dataUltimaEdicao;
            ValidarEntidade(dto);

            Nome = dto.Nome;
            Login = dto.Login;
            Senha= dto.Senha;
            Email= dto.Email;
            Administrador= dto.Administrador;
            Desenvolvedor = dto.Desenvolvedor;
        }

        private void ValidarEntidade(UsuarioDto dto)
        {
            List<DomainValidationException> erros = new List<DomainValidationException>();

            if (dto == null) throw new ArgumentNullException("Os dados para validação da entidade não foram fornecidos.");

            if (string.IsNullOrWhiteSpace(dto.Nome)) erros.Add(new DomainValidationException("O Nome do usuário é uma informação obrigatória"));
            if (string.IsNullOrWhiteSpace(dto.Login)) erros.Add(new DomainValidationException("O Login do usuário é uma informação obrigatória"));
            if (string.IsNullOrWhiteSpace(dto.Senha) || dto.Senha.Length < 6) erros.Add(new DomainValidationException("A Senha do usuário precisa ter no mínimo 6 caracteres"));

            var errosBase = base.ValidarEntidade(dto.DataUltimaEdicao, dto.UsuarioUltimaEdicaoId);
            if (errosBase != null) erros.AddRange(errosBase);

            if (erros.Any()) throw new DomainValidationException("Houveram erros na validação do Usuário", erros);
        }
    }
}
