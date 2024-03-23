using AutoMapper;
using AutoMapper.Execution;
using AutoMapper.Extensions.ExpressionMapping;
using Demandas.Application.Interfaces;
using Demandas.Application.Mappings;
using Demandas.Application.Services;
using Demandas.Domain.Interfaces;
using Demandas.Infrastructure.Context;
using Demandas.Infrastructure.Repositories;
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


            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IDemandaRepository, DemandaRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IDemandaService, DemandaService>();


            services.AddAutoMapper(cfg =>
            {
                cfg.AddExpressionMapping();

            },typeof(DomainToDTOMap));




            return services;
        }
    }
}
