﻿using Demandas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.CQRS.Demanda.Queries
{
    public class GetAllDemandasQuery : IRequest<List<DemandaDto>>
    {
    }
}
