using Demandas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Infrastructure.Context
{
    public class DemandasDb : DbContext
    {
        public DemandasDb(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.ApplyConfigurationsFromAssembly(typeof(DemandasDb).Assembly);
        }
        public DbSet<Demanda> Demandas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
