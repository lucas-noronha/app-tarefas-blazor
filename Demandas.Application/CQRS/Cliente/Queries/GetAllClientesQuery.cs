﻿using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Cliente.Queries
{
    internal class GetAllClientesQuery : IRequest<List<ClienteDto>>
    {
    }
}