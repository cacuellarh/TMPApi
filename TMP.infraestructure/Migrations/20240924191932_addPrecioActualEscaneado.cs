using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMP.infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class addPrecioActualEscaneado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecioActualEscaneado",
                table: "Products",
                type: "decimal(65,30)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioActualEscaneado",
                table: "Products");
        }
    }
}
