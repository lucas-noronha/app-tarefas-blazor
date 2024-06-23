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
        public virtual DbSet<Demanda> Demandas { get; set; }

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<Empresa> Empresas { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
