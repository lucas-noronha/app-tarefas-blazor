using Demandas.Domain.DTOs;
using Demandas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demandas.Domain.Entities
{
    public class Cliente : EntityBase
    {

        public Cliente(ClienteDto dto) : base(dto.UsuarioUltimaEdicaoId, dto.EmpresaId)
        {
            AtualizarEntidade(dto);
        }

        public string Nome { get; private set; }

        public string? Contato { get; private set; }

        public void AtualizarEntidade(ClienteDto dto)
        {
            dto.DataUltimaEdicao = DateTime.Now;
            ValidarEntidade(dto);

            Nome = dto.Nome;
            Contato = dto.Contato;
            base.AtualizarEntidadeBase(dto.DataUltimaEdicao, dto.UsuarioUltimaEdicaoId);

        }
        
        public void ValidarEntidade(ClienteDto dto)
        {
            List<DomainValidationException> errors = new List<DomainValidationException>();

            if (dto == null) throw new ArgumentNullException("Os dados para validação da entidade não foram fornecidos.");

            if (string.IsNullOrWhiteSpace(dto.Nome)) errors.Add(new DomainValidationException("O nome do Cliente precisa ser informado."));
            if (dto.Nome.Length < 5) errors.Add(new DomainValidationException("O nome do Cliente informado é muito curto."));
            if (dto.EmpresaId <= 0) errors.Add(new DomainValidationException("A empresa do Cliente precisa ser informada."));

            errors.AddRange(base.ValidarEntidade(dto.DataUltimaEdicao, dto.UsuarioUltimaEdicaoId));
        }
    }
}
