﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Usuario.Commands
{
    public class DeleteUsuarioCommand : IRequest
    {
        public DeleteUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public static DeleteUsuarioCommand CriarPorId(int id) => new DeleteUsuarioCommand(id);
    }
}
