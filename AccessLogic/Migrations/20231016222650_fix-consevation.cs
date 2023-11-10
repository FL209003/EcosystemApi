using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class fixconsevation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seguridad",
                table: "Conservations");

            migrationBuilder.AddColumn<int>(
                name: "Seguridad",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seguridad",
                table: "Ecosystems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seguridad",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Seguridad",
                table: "Ecosystems");

            migrationBuilder.AddColumn<int>(
                name: "Seguridad",
                table: "Conservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
