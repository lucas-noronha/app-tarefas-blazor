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
    internal class EntityBaseConfiguration
    {
        public static void Configure<T>(EntityTypeBuilder<T> builder, string tabela, string schema)
            where T : EntityBase
        {
            builder
                .ToTable(tabela, schema);

            builder
                .HasKey(x => x.Id);


            builder
                .Property(x => x.Id)
                .HasColumnOrder(1)
                .HasColumnName("cd_codigo")
                .UseSerialColumn();

            builder
                .Property(x => x.EmpresaId)
                .HasColumnName("cd_empresa")
                .HasColumnOrder(2)
                .IsRequired();


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
                .Ignore(x => x.UsuarioCriacao);

            builder
                .Ignore(x => x.UsuarioUltimaEdicao);


        }
    }
}
