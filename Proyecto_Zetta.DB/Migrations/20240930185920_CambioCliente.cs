using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Zetta.DB.Migrations
{
    /// <inheritdoc />
    public partial class CambioCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Cliente_Apellido_Nombre",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Clientes",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "Cliente_Cod",
                table: "Clientes",
                column: "Codigo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Cliente_Cod",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Clientes");

            migrationBuilder.CreateIndex(
                name: "Cliente_Apellido_Nombre",
                table: "Clientes",
                columns: new[] { "Apellido", "Nombre" });
        }
    }
}
