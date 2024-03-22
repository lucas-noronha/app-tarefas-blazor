using Demandas.Domain.Exceptions;
using System.Data;

namespace Demandas.Domain.Entities
{
    public sealed class Empresa
    {
        public Empresa(string nome, string logo, int usuarioCriacao)
        {

            DataCriacao = DateTime.UtcNow;
            UsuarioCriacaoId = usuarioCriacao;

            AtualizarEntidade(nome, logo,usuarioCriacao);
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Logo { get; set; }

        public DateTime DataCriacao { get; protected set; }

        public DateTime DataUltimaEdicao { get; protected set; }

        public int UsuarioCriacaoId { get; protected set; }
        public Usuario UsuarioCriacao { get; protected set; }

        public int UsuarioUltimaEdicaoId { get; protected set; }
        public Usuario UsuarioUltimaEdicao { get; protected set; }

        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

        public void AtualizarEntidade(string nome, string logo, int usuarioUltimaEdicaoId)
        {
            var dataUltimaAtualizacao = DateTime.UtcNow;
            ValidarEntidade(nome,dataUltimaAtualizacao,usuarioUltimaEdicaoId);

            Nome = nome;
            Logo = logo;
            DataUltimaEdicao = dataUltimaAtualizacao;
            UsuarioUltimaEdicaoId = usuarioUltimaEdicaoId;
            
            
        }

        private void ValidarEntidade(string nome, DateTime dataUltimaEdicao, int usuarioUltimaEdicaoId)
        {
            List<DomainValidationException> erros = new List<DomainValidationException>();

            
            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 3) erros.Add(new DomainValidationException("O nome da empresa precisa ser válido."));
            if (dataUltimaEdicao.Date < DateTime.UtcNow.Date) erros.Add(new DomainValidationException("A data da ultima edição é menor que a data atual."));
            if (usuarioUltimaEdicaoId <= 0) erros.Add(new DomainValidationException("O ID do usuário da ultima edição é inválido."));

            if (erros.Any()) throw new DomainValidationException("Houveram erros ao validar informações da Empresa", erros);

        }
    }
}
