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
            EntityBaseConfiguration.Configure(builder, "usuarios", "public");

            builder
                .Property(x => x.Nome)
                .HasColumnOrder(3)
                .HasColumnName("ds_nome");

            builder
                .Property(x => x.Login)
                .HasColumnOrder(3)
                .HasColumnName("ds_login")
                .HasMaxLength(30);

            builder
                .Property(x => x.Senha)
                .HasColumnOrder(3)
                .HasColumnName("ds_senha")
                .HasMaxLength(18);

            builder
                .Property(x => x.Email)
                .HasColumnOrder(3)
                .HasColumnName("ds_email")
                .HasMaxLength(150);

            builder
                .Property(x => x.Administrador)
                .HasColumnOrder(3)
                .HasColumnName("st_adm");

            builder
                .Property(x => x.Desenvolvedor)
                .HasColumnOrder(3)
                .HasColumnName("st_dev");
        }
    }
}
