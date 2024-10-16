using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMP.infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class addCanScan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanScan",
                table: "ImageTracks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanScan",
                table: "ImageTracks");
        }
    }
}
