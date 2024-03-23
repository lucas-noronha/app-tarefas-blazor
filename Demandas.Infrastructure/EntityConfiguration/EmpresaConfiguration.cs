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
                .ToTable("empresas");

            builder.HasKey(e => e.Id);
            builder
                .Property(x => x.Id)
                .HasColumnName("cd_codigo")
                .UseSerialColumn();

            builder
                .Property(x => x.Nome)
                .HasColumnName("ds_nome");

            builder
                .Property(x => x.Logo)
                .HasColumnName("ds_logo");

            builder
                .Property(x => x.DataCriacao)
                .HasColumnName("dt_criacao")
                .IsRequired();

            builder
                .Property(x => x.DataUltimaEdicao)
                .HasColumnName("dt_ultima_edicao")
                .IsRequired();

            builder
                .Property(x => x.UsuarioCriacaoId)
                .HasColumnName("cd_usuario_criacao")
                .IsRequired();

            builder
                .Property(x => x.UsuarioUltimaEdicaoId)
                .HasColumnName("cd_usuario_edicao")
                .IsRequired();


            builder
                .HasOne(r => r.UsuarioCriacao)
                .WithMany();

            builder
                .HasOne(x => x.UsuarioUltimaEdicao)
                .WithMany();

            

        }
    }
}
