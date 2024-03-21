using Demandas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Infrastructure.EntityConfiguration
{
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            EntityBaseConfiguration.Configure(builder, "clientes", "public");
            
            builder
                .Property(x => x.Nome)
                .HasColumnOrder(3)
                .HasColumnName("ds_nome");

            builder
                .Property(x => x.Contato)
                .HasColumnOrder(3)
                .HasColumnName("ds_contato");

        }
    }

    
}
