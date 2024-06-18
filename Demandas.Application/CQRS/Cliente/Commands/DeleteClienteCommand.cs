using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Cliente.Commands
{
    public class DeleteClienteCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteClienteCommand(int id) 
        {
            Id = id;
        }

        public static DeleteClienteCommand CriarPorId(int id)
        {
            return new DeleteClienteCommand(id);
        }
    }
}
