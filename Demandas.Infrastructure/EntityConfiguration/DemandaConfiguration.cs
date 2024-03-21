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
    internal class DemandaConfiguration : IEntityTypeConfiguration<Demanda>
    {
        public void Configure(EntityTypeBuilder<Demanda> builder)
        {

            EntityBaseConfiguration.Configure(builder, "demandas", "public");
            
            builder
                .Property(x => x.ClienteId)
                .HasColumnOrder(3)
                .HasColumnName("cd_cliene");

            builder
                .Property(x => x.Titulo)
                .HasColumnOrder(3)
                .HasColumnName("ds_titulo")
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(x => x.Descricao)
                .HasColumnOrder(3)
                .HasColumnName("ds_descricao")
                .HasMaxLength(2500)
                .IsRequired();

            builder
                .Property(x => x.DataFinalizacao)
                .HasColumnOrder(3)
                .HasColumnName("dt_finalizacao");

            builder
                .Property(x => x.UsuarioResponsavelId)
                .HasColumnOrder(3)
                .HasColumnName("cd_responsavel")
                .IsRequired();

            builder
                .Property(x => x.Status)
                .HasColumnOrder(3)
                .HasColumnName("cd_status")
                .IsRequired();

            builder
                .Property(x => x.TipoDemanda)
                .HasColumnOrder(3)
                .HasColumnName("cd_tipo")
                .IsRequired();

            builder
                .Property(x => x.Urgente)
                .HasColumnOrder(3)
                .HasColumnName("st_urgente");

            builder
                .Property(x => x.Importante)
                .HasColumnOrder(3)
                .HasColumnName("st_importante");
        }
    }
}
