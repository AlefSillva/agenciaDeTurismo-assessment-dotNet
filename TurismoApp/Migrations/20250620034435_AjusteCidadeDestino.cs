using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurismoApp.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCidadeDestino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CidadesDestino_PaisDestino_PaisDestinoId",
                table: "CidadesDestino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaisDestino",
                table: "PaisDestino");

            migrationBuilder.RenameTable(
                name: "PaisDestino",
                newName: "PaisesDestino");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaisesDestino",
                table: "PaisesDestino",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CidadesDestino_PaisesDestino_PaisDestinoId",
                table: "CidadesDestino",
                column: "PaisDestinoId",
                principalTable: "PaisesDestino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CidadesDestino_PaisesDestino_PaisDestinoId",
                table: "CidadesDestino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaisesDestino",
                table: "PaisesDestino");

            migrationBuilder.RenameTable(
                name: "PaisesDestino",
                newName: "PaisDestino");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaisDestino",
                table: "PaisDestino",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CidadesDestino_PaisDestino_PaisDestinoId",
                table: "CidadesDestino",
                column: "PaisDestinoId",
                principalTable: "PaisDestino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
