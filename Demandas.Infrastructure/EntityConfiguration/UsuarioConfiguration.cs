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
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .ToTable("usuario");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("cd_codigo")
                .UseSerialColumn();

            builder
                .Property(x => x.Nome)
                .HasColumnName("ds_nome");

            builder
                .Property(x => x.Login)
                .HasColumnName("ds_login");

            builder
                .Property(x => x.Senha)
                .HasColumnName("ds_senha");

            builder
                .Property(x => x.Email)
                .HasColumnName("ds_email");

            builder
                .Property(x => x.Administrador)
                .HasColumnName("st_adm");

            builder
                .Property(x => x.Desenvolvedor)
                .HasColumnName("st_dev");
        }
    }
}
