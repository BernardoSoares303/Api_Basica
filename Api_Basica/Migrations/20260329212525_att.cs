using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Basica.Migrations
{
    /// <inheritdoc />
    public partial class att : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioResponsavelId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_UsuarioResponsavelId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "UsuarioResponsavelId",
                table: "Tarefas");

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Tarefas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_usuarioId",
                table: "Tarefas",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_usuarioId",
                table: "Tarefas",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_usuarioId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_usuarioId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Tarefas");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioResponsavelId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioResponsavelId",
                table: "Tarefas",
                column: "UsuarioResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioResponsavelId",
                table: "Tarefas",
                column: "UsuarioResponsavelId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
