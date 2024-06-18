using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Empresa.Commands
{
    public class UpdateEmpresaCommand : IRequest<EmpresaDto>
    {
        public EmpresaDto EmpresaInfo { get; set; }

        public UpdateEmpresaCommand(EmpresaDto empresaInfo)
        {
            EmpresaInfo = empresaInfo;
        }

        public static UpdateEmpresaCommand CriarPorDto(EmpresaDto dto)
        {
            return new UpdateEmpresaCommand(dto);
        }
    }
}
