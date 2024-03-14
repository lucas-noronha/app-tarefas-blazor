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
            builder
                .ToTable("clientes");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("cd_codigo")
                .UseSerialColumn();

            builder
                .Property(x => x.Nome)
                .HasColumnName("ds_nome");

            builder
                .Property(x => x.Contato)
                .HasColumnName("ds_contato");

            builder
                .Property(x => x.EmpresaId)
                .HasColumnName("cd_empresa");


        }
    }

    
}
