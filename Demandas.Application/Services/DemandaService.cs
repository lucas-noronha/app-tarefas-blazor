using AutoMapper;
using Demandas.Application.DTOs;
using Demandas.Domain.Entities;
using Demandas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Services
{
    public class DemandaService : ServiceBase<DemandaDto, Demanda>
    {
        public DemandaService(IMapper mapper, IDemandaRepository demandaRepository) : base(mapper, demandaRepository)
        {}
    }
}
