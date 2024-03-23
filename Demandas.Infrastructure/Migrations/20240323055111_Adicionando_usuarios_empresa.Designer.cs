﻿// <auto-generated />
using System;
using Demandas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Demandas.Infrastructure.Migrations
{
    [DbContext(typeof(DemandasDb))]
    [Migration("20240323055111_Adicionando_usuarios_empresa")]
    partial class Adicionando_usuarios_empresa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Demandas.Domain.Entities.AnexosDemanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DemandaId")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DemandaId");

                    b.ToTable("AnexosDemanda");
                });

            modelBuilder.Entity("Demandas.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cd_codigo")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Contato")
                        .HasColumnType("text")
                        .HasColumnName("ds_contato")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_criacao");

                    b.Property<DateTime>("DataUltimaEdicao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_ultima_edicao");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_empresa")
                        .HasColumnOrder(2);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ds_nome")
                        .HasColumnOrder(3);

                    b.Property<int>("UsuarioCriacaoId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_usuario_criacao");

                    b.Property<int>("UsuarioUltimaEdicaoId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_usuario_edicao");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("clientes", "public");
                });

            modelBuilder.Entity("Demandas.Domain.Entities.Demanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cd_codigo")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_cliene")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_criacao");

                    b.Property<DateTime?>("DataFinalizacao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_finalizacao")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("DataUltimaEdicao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_ultima_edicao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("character varying(2500)")
                        .HasColumnName("ds_descricao")
                        .HasColumnOrder(3);

                    b.Property<int>("EmpresaId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_empresa")
                        .HasColumnOrder(2);

                    b.Property<bool?>("Importante")
                        .HasColumnType("boolean")
                        .HasColumnName("st_importante")
                        .HasColumnOrder(3);

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("cd_status")
                        .HasColumnOrder(3);

                    b.Property<int>("TipoDemanda")
                        .HasColumnType("integer")
                        .HasColumnName("cd_tipo")
                        .HasColumnOrder(3);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("ds_titulo")
                        .HasColumnOrder(3);

                    b.Property<bool?>("Urgente")
                        .HasColumnType("boolean")
                        .HasColumnName("st_urgente")
                        .HasColumnOrder(3);

                    b.Property<int>("UsuarioCriacaoId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_usuario_criacao");

                    b.Property<int>("UsuarioResponsavelId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_responsavel")
                        .HasColumnOrder(3);

                    b.Property<int>("UsuarioUltimaEdicaoId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_usuario_edicao");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("UsuarioResponsavelId");

                    b.ToTable("demandas", "public");
                });

            modelBuilder.Entity("Demandas.Domain.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cd_codigo");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_criacao");

                    b.Property<DateTime>("DataUltimaEdicao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_ultima_edicao");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ds_logo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ds_nome");

                    b.Property<int>("UsuarioCriacaoId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_usuario_criacao");

                    b.Property<int>("UsuarioUltimaEdicaoId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_usuario_edicao");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioCriacaoId");

                    b.HasIndex("UsuarioUltimaEdicaoId");

                    b.ToTable("empresas", (string)null);
                });

            modelBuilder.Entity("Demandas.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cd_codigo")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<bool>("Administrador")
                        .HasColumnType("boolean")
                        .HasColumnName("st_adm")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_criacao");

                    b.Property<DateTime>("DataUltimaEdicao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_ultima_edicao");

                    b.Property<bool>("Desenvolvedor")
                        .HasColumnType("boolean")
                        .HasColumnName("st_dev")
                        .HasColumnOrder(3);

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("ds_email")
                        .HasColumnOrder(3);

                    b.Property<int>("EmpresaId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_empresa")
                        .HasColumnOrder(2);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("ds_login")
                        .HasColumnOrder(3);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ds_nome")
                        .HasColumnOrder(3);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)")
                        .HasColumnName("ds_senha")
                        .HasColumnOrder(3);

                    b.Property<int>("UsuarioCriacaoId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_usuario_criacao");

                    b.Property<int>("UsuarioUltimaEdicaoId")
                        .HasColumnType("integer")
                        .HasColumnName("cd_usuario_edicao");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("usuarios", "public");
                });

            modelBuilder.Entity("Demandas.Domain.Entities.AnexosDemanda", b =>
                {
                    b.HasOne("Demandas.Domain.Entities.Demanda", "Demanda")
                        .WithMany("Anexos")
                        .HasForeignKey("DemandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Demanda");
                });

            modelBuilder.Entity("Demandas.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("Demandas.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Clientes")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Demandas.Domain.Entities.Demanda", b =>
                {
                    b.HasOne("Demandas.Domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demandas.Domain.Entities.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demandas.Domain.Entities.Usuario", "UsuarioResponsavel")
                        .WithMany()
                        .HasForeignKey("UsuarioResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empresa");

                    b.Navigation("UsuarioResponsavel");
                });

            modelBuilder.Entity("Demandas.Domain.Entities.Empresa", b =>
                {
                    b.HasOne("Demandas.Domain.Entities.Usuario", "UsuarioCriacao")
                        .WithMany()
                        .HasForeignKey("UsuarioCriacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demandas.Domain.Entities.Usuario", "UsuarioUltimaEdicao")
                        .WithMany()
                        .HasForeignKey("UsuarioUltimaEdicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioCriacao");

                    b.Navigation("UsuarioUltimaEdicao");
                });

            modelBuilder.Entity("Demandas.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("Demandas.Domain.Entities.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Demandas.Domain.Entities.Demanda", b =>
                {
                    b.Navigation("Anexos");
                });

            modelBuilder.Entity("Demandas.Domain.Entities.Empresa", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
