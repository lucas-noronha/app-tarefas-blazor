using Demandas.Domain.DTOs;
using Demandas.Domain.Exceptions;

namespace Demandas.Domain.Entities
{
    public sealed class Empresa
    {
        public Empresa()
        {}
        public Empresa(EmpresaDto dto)
        {

            DataCriacao = DateTime.UtcNow;
            UsuarioCriacaoId = dto.UsuarioUltimaEdicaoId;

            AtualizarEntidade(dto);
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

        public void AtualizarEntidade(EmpresaDto dto)
        {
            dto.DataUltimaEdicao = DateTime.UtcNow;
            ValidarEntidade(dto);

            Nome = dto.Nome;
            Logo = dto.Logo;
            DataUltimaEdicao = dto.DataUltimaEdicao;
            UsuarioUltimaEdicaoId = dto.UsuarioUltimaEdicaoId;
            
            
        }

        private void ValidarEntidade(EmpresaDto dto)
        {
            List<DomainValidationException> erros = new List<DomainValidationException>();

            if (dto == null) throw new ArgumentNullException("Os dados para validação da entidade não foram fornecidos.");
            if (string.IsNullOrWhiteSpace(dto.Nome) || dto.Nome.Length < 3) erros.Add(new DomainValidationException("O nome da empresa precisa ser válido."));
            if (dto.DataUltimaEdicao.Date < DateTime.UtcNow.Date) erros.Add(new DomainValidationException("A data da ultima edição é menor que a data atual."));
            if (dto.UsuarioUltimaEdicaoId <= 0) erros.Add(new DomainValidationException("O ID do usuário da ultima edição é inválido."));

            if (erros.Any()) throw new DomainValidationException("Houveram erros ao validar informações da Empresa", erros);

        }
    }
}
