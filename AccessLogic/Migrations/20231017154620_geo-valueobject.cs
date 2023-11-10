using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class geovalueobject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ubicación",
                table: "Ecosystems",
                newName: "GeoDetails_GeoDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "GeoDetails_Latitude",
                table: "Ecosystems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GeoDetails_Longitude",
                table: "Ecosystems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeoDetails_Latitude",
                table: "Ecosystems");

            migrationBuilder.DropColumn(
                name: "GeoDetails_Longitude",
                table: "Ecosystems");

            migrationBuilder.RenameColumn(
                name: "GeoDetails_GeoDetails",
                table: "Ecosystems",
                newName: "Ubicación");
        }
    }
}
