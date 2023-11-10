using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class descripcionname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThreatDescription_Value",
                table: "Threats",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "SpeciesDescription_Value",
                table: "Species",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "EcoDescription_Value",
                table: "Ecosystems",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Threats",
                newName: "ThreatDescription_Value");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Species",
                newName: "SpeciesDescription_Value");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Ecosystems",
                newName: "EcoDescription_Value");
        }
    }
}
