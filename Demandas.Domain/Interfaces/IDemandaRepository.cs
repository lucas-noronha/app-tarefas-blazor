﻿using Demandas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Interfaces
{
    public interface IDemandaRepository : IRepositoryBase<Demanda>
    {
        void FinalizarDemanda(Demanda demanda);

    }
}
