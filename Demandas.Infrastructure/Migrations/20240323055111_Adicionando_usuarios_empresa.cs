using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demandas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adicionando_usuarios_empresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_empresas_cd_usuario_criacao",
                table: "empresas",
                column: "cd_usuario_criacao");

            migrationBuilder.CreateIndex(
                name: "IX_empresas_cd_usuario_edicao",
                table: "empresas",
                column: "cd_usuario_edicao");

            migrationBuilder.AddForeignKey(
                name: "FK_empresas_usuarios_cd_usuario_criacao",
                table: "empresas",
                column: "cd_usuario_criacao",
                principalSchema: "public",
                principalTable: "usuarios",
                principalColumn: "cd_codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_empresas_usuarios_cd_usuario_edicao",
                table: "empresas",
                column: "cd_usuario_edicao",
                principalSchema: "public",
                principalTable: "usuarios",
                principalColumn: "cd_codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empresas_usuarios_cd_usuario_criacao",
                table: "empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_empresas_usuarios_cd_usuario_edicao",
                table: "empresas");

            migrationBuilder.DropIndex(
                name: "IX_empresas_cd_usuario_criacao",
                table: "empresas");

            migrationBuilder.DropIndex(
                name: "IX_empresas_cd_usuario_edicao",
                table: "empresas");
        }
    }
}
