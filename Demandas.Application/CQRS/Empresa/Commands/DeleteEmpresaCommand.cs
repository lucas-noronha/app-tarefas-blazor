using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Empresa.Commands
{
    internal class DeleteEmpresaCommand : IRequest
    {
        public DeleteEmpresaCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public static DeleteEmpresaCommand CriarPorId(int id)
        {
            return new DeleteEmpresaCommand(id);
        }
    }
}
