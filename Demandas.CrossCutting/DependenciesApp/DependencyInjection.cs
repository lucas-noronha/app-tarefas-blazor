﻿using Demandas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.CrossCutting.DependenciesApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var conStr = configuration.GetConnectionString("demandasdb");
            
            services.AddDbContext<DemandasDb>(opt => opt.UseNpgsql(conStr));


            //services.AddScoped()

            return services;
        }
    }
}
