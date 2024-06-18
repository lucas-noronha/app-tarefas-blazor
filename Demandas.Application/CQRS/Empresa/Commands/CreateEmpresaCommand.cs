using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Empresa.Commands
{
    public class CreateEmpresaCommand : IRequest<int>
    {
        public EmpresaDto EmpresaInfos { get; set; }

        public CreateEmpresaCommand(EmpresaDto infos)
        {
            EmpresaInfos = infos;
        }

        public static CreateEmpresaCommand CriarPorDto(EmpresaDto dto)
        {
            return new CreateEmpresaCommand(dto);
        }
    }
}
