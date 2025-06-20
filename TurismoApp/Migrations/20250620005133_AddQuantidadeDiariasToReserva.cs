using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurismoApp.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantidadeDiariasToReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDiarias",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeDiarias",
                table: "Reservas");
        }
    }
}
