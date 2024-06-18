using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Demanda.Commands
{
    public class DeleteDemandaCommand : IRequest
    {
        public DeleteDemandaCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public static DeleteDemandaCommand CriarPorId(int id) => new DeleteDemandaCommand(id);
    }
}
