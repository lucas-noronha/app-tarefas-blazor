using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Demandas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Criando_banco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "empresas",
                columns: table => new
                {
                    cd_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ds_nome = table.Column<string>(type: "text", nullable: false),
                    ds_logo = table.Column<string>(type: "text", nullable: false),
                    dt_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_ultima_edicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cd_usuario_criacao = table.Column<int>(type: "integer", nullable: false),
                    cd_usuario_edicao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresas", x => x.cd_codigo);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                schema: "public",
                columns: table => new
                {
                    cd_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cd_empresa = table.Column<int>(type: "integer", nullable: false),
                    ds_nome = table.Column<string>(type: "text", nullable: false),
                    ds_contato = table.Column<string>(type: "text", nullable: true),
                    dt_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_ultima_edicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cd_usuario_criacao = table.Column<int>(type: "integer", nullable: false),
                    cd_usuario_edicao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.cd_codigo);
                    table.ForeignKey(
                        name: "FK_clientes_empresas_cd_empresa",
                        column: x => x.cd_empresa,
                        principalTable: "empresas",
                        principalColumn: "cd_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "public",
                columns: table => new
                {
                    cd_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cd_empresa = table.Column<int>(type: "integer", nullable: false),
                    ds_nome = table.Column<string>(type: "text", nullable: false),
                    ds_login = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ds_senha = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    ds_email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    st_adm = table.Column<bool>(type: "boolean", nullable: false),
                    st_dev = table.Column<bool>(type: "boolean", nullable: false),
                    dt_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_ultima_edicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cd_usuario_criacao = table.Column<int>(type: "integer", nullable: false),
                    cd_usuario_edicao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.cd_codigo);
                    table.ForeignKey(
                        name: "FK_usuarios_empresas_cd_empresa",
                        column: x => x.cd_empresa,
                        principalTable: "empresas",
                        principalColumn: "cd_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "demandas",
                schema: "public",
                columns: table => new
                {
                    cd_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cd_empresa = table.Column<int>(type: "integer", nullable: false),
                    ds_titulo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ds_descricao = table.Column<string>(type: "character varying(2500)", maxLength: 2500, nullable: false),
                    dt_finalizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cd_status = table.Column<int>(type: "integer", nullable: false),
                    cd_tipo = table.Column<int>(type: "integer", nullable: false),
                    st_urgente = table.Column<bool>(type: "boolean", nullable: true),
                    st_importante = table.Column<bool>(type: "boolean", nullable: true),
                    cd_cliene = table.Column<int>(type: "integer", nullable: false),
                    cd_responsavel = table.Column<int>(type: "integer", nullable: false),
                    dt_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_ultima_edicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cd_usuario_criacao = table.Column<int>(type: "integer", nullable: false),
                    cd_usuario_edicao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demandas", x => x.cd_codigo);
                    table.ForeignKey(
                        name: "FK_demandas_clientes_cd_cliene",
                        column: x => x.cd_cliene,
                        principalSchema: "public",
                        principalTable: "clientes",
                        principalColumn: "cd_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_demandas_empresas_cd_empresa",
                        column: x => x.cd_empresa,
                        principalTable: "empresas",
                        principalColumn: "cd_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_demandas_usuarios_cd_responsavel",
                        column: x => x.cd_responsavel,
                        principalSchema: "public",
                        principalTable: "usuarios",
                        principalColumn: "cd_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnexosDemanda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DemandaId = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnexosDemanda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnexosDemanda_demandas_DemandaId",
                        column: x => x.DemandaId,
                        principalSchema: "public",
                        principalTable: "demandas",
                        principalColumn: "cd_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnexosDemanda_DemandaId",
                table: "AnexosDemanda",
                column: "DemandaId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_cd_empresa",
                schema: "public",
                table: "clientes",
                column: "cd_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_demandas_cd_cliene",
                schema: "public",
                table: "demandas",
                column: "cd_cliene");

            migrationBuilder.CreateIndex(
                name: "IX_demandas_cd_empresa",
                schema: "public",
                table: "demandas",
                column: "cd_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_demandas_cd_responsavel",
                schema: "public",
                table: "demandas",
                column: "cd_responsavel");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_cd_empresa",
                schema: "public",
                table: "usuarios",
                column: "cd_empresa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnexosDemanda");

            migrationBuilder.DropTable(
                name: "demandas",
                schema: "public");

            migrationBuilder.DropTable(
                name: "clientes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "public");

            migrationBuilder.DropTable(
                name: "empresas");
        }
    }
}
