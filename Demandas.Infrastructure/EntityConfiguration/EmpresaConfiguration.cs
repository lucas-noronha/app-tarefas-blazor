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
    internal class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder
                .ToTable("empresa_cliente");

            builder.HasKey(e => e.Id);
            builder
                .Property(x => x.Id)
                .HasColumnName("ds_codigo")
                .UseSerialColumn();

            builder
                .Property(x => x.Nome)
                .HasColumnName("ds_nome");

            builder
                .Property(x => x.Logo)
                .HasColumnName("ds_logo");

            builder
                .HasMany(x => x.Clientes)
                .WithOne(x => x.Empresa);
        }
    }
}
