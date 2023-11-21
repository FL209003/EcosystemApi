using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class conservationnamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Conservations_Nombre",
                table: "Conservations");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Conservations");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Conservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Conservations");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Conservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Conservations_Nombre",
                table: "Conservations",
                column: "Nombre",
                unique: true);
        }
    }
}
