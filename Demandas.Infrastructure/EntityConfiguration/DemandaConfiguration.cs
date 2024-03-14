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
            builder
                .ToTable("demanda");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("cd_codigo")
                .UseSerialColumn();

            builder
                .Property(x => x.EmpresaId)
                .HasColumnName("cd_empresa");

            builder
                .Property(x => x.ClienteId)
                .HasColumnName("cd_cliene");

            builder
                .Property(x => x.Titulo)
                .HasColumnName("ds_titulo");

            builder
                .Property(x => x.Descricao)
                .HasColumnName("ds_descricao");

            builder
                .Property(x => x.DataCriacao)
                .HasColumnName("dt_criacao");

            builder
                .Property(x => x.DataFinalizacao)
                .HasColumnName("dt_finalizacao");

            builder
                .Property(x => x.UsuarioCadastranteId)
                .HasColumnName("cd_usuario_cadastro");

            builder
                .Property(x => x.UsuarioResponsavelId)
                .HasColumnName("cd_responsavel");

            builder
                .Property(x => x.Status)
                .HasColumnName("cd_status");

            builder
                .Property(x => x.TipoDemanda)
                .HasColumnName("cd_tipo");

            builder
                .Property(x => x.Urgente)
                .HasColumnName("st_urgente");

            builder
                .Property(x => x.Importante)
                .HasColumnName("st_importante");
        }
    }
}
