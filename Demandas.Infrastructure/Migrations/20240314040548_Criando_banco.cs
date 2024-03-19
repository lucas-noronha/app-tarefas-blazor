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
            migrationBuilder.CreateTable(
                name: "empresa_cliente",
                columns: table => new
                {
                    ds_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ds_nome = table.Column<string>(type: "text", nullable: false),
                    ds_logo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa_cliente", x => x.ds_codigo);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    cd_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ds_nome = table.Column<string>(type: "text", nullable: false),
                    ds_login = table.Column<string>(type: "text", nullable: false),
                    ds_senha = table.Column<string>(type: "text", nullable: false),
                    ds_email = table.Column<string>(type: "text", nullable: true),
                    st_adm = table.Column<bool>(type: "boolean", nullable: false),
                    st_dev = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.cd_codigo);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    cd_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ds_nome = table.Column<string>(type: "text", nullable: false),
                    ds_contato = table.Column<string>(type: "text", nullable: false),
                    cd_empresa = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.cd_codigo);
                    table.ForeignKey(
                        name: "FK_clientes_empresa_cliente_cd_empresa",
                        column: x => x.cd_empresa,
                        principalTable: "empresa_cliente",
                        principalColumn: "ds_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "demanda",
                columns: table => new
                {
                    cd_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ds_titulo = table.Column<string>(type: "text", nullable: false),
                    ds_descricao = table.Column<string>(type: "text", nullable: false),
                    dt_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_finalizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cd_usuario_cadastro = table.Column<int>(type: "integer", nullable: false),
                    cd_responsavel = table.Column<int>(type: "integer", nullable: true),
                    cd_status = table.Column<int>(type: "integer", nullable: false),
                    cd_tipo = table.Column<int>(type: "integer", nullable: false),
                    st_urgente = table.Column<bool>(type: "boolean", nullable: true),
                    st_importante = table.Column<bool>(type: "boolean", nullable: true),
                    cd_empresa = table.Column<int>(type: "integer", nullable: false),
                    cd_cliene = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demanda", x => x.cd_codigo);
                    table.ForeignKey(
                        name: "FK_demanda_clientes_cd_cliene",
                        column: x => x.cd_cliene,
                        principalTable: "clientes",
                        principalColumn: "cd_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_demanda_empresa_cliente_cd_empresa",
                        column: x => x.cd_empresa,
                        principalTable: "empresa_cliente",
                        principalColumn: "ds_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_demanda_usuario_cd_responsavel",
                        column: x => x.cd_responsavel,
                        principalTable: "usuario",
                        principalColumn: "cd_codigo");
                    table.ForeignKey(
                        name: "FK_demanda_usuario_cd_usuario_cadastro",
                        column: x => x.cd_usuario_cadastro,
                        principalTable: "usuario",
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
                        name: "FK_AnexosDemanda_demanda_DemandaId",
                        column: x => x.DemandaId,
                        principalTable: "demanda",
                        principalColumn: "cd_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnexosDemanda_DemandaId",
                table: "AnexosDemanda",
                column: "DemandaId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_cd_empresa",
                table: "clientes",
                column: "cd_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_demanda_cd_cliene",
                table: "demanda",
                column: "cd_cliene");

            migrationBuilder.CreateIndex(
                name: "IX_demanda_cd_empresa",
                table: "demanda",
                column: "cd_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_demanda_cd_responsavel",
                table: "demanda",
                column: "cd_responsavel");

            migrationBuilder.CreateIndex(
                name: "IX_demanda_cd_usuario_cadastro",
                table: "demanda",
                column: "cd_usuario_cadastro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnexosDemanda");

            migrationBuilder.DropTable(
                name: "demanda");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "empresa_cliente");
        }
    }
}
