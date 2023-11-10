using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class aftermerge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThreatName_Value",
                table: "Threats",
                newName: "Nombre");

            migrationBuilder.RenameIndex(
                name: "IX_Threats_ThreatName_Value",
                table: "Threats",
                newName: "IX_Threats_Nombre");

            migrationBuilder.RenameColumn(
                name: "SpeciesName_Value",
                table: "Species",
                newName: "Nombre");

            migrationBuilder.RenameIndex(
                name: "IX_Species_SpeciesName_Value",
                table: "Species",
                newName: "IX_Species_Nombre");

            migrationBuilder.RenameColumn(
                name: "EcosystemName_Value",
                table: "Ecosystems",
                newName: "Nombre");

            migrationBuilder.RenameIndex(
                name: "IX_Ecosystems_EcosystemName_Value",
                table: "Ecosystems",
                newName: "IX_Ecosystems_Nombre");

            migrationBuilder.RenameColumn(
                name: "CountryName_Value",
                table: "Countries",
                newName: "Nombre");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_CountryName_Value",
                table: "Countries",
                newName: "IX_Countries_Nombre");

            migrationBuilder.RenameColumn(
                name: "Rango de conservación mínimo",
                table: "Conservations",
                newName: "Rango de seguridad mínimo");

            migrationBuilder.RenameColumn(
                name: "Rango de conservación máximo",
                table: "Conservations",
                newName: "Rango de seguridad máximo");

            migrationBuilder.RenameColumn(
                name: "ConservationName_Value",
                table: "Conservations",
                newName: "Nombre");

            migrationBuilder.RenameIndex(
                name: "IX_Conservations_ConservationName_Value",
                table: "Conservations",
                newName: "IX_Conservations_Nombre");

            migrationBuilder.AddColumn<int>(
                name: "Seguridad",
                table: "Conservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seguridad",
                table: "Conservations");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Threats",
                newName: "ThreatName_Value");

            migrationBuilder.RenameIndex(
                name: "IX_Threats_Nombre",
                table: "Threats",
                newName: "IX_Threats_ThreatName_Value");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Species",
                newName: "SpeciesName_Value");

            migrationBuilder.RenameIndex(
                name: "IX_Species_Nombre",
                table: "Species",
                newName: "IX_Species_SpeciesName_Value");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Ecosystems",
                newName: "EcosystemName_Value");

            migrationBuilder.RenameIndex(
                name: "IX_Ecosystems_Nombre",
                table: "Ecosystems",
                newName: "IX_Ecosystems_EcosystemName_Value");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Countries",
                newName: "CountryName_Value");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_Nombre",
                table: "Countries",
                newName: "IX_Countries_CountryName_Value");

            migrationBuilder.RenameColumn(
                name: "Rango de seguridad mínimo",
                table: "Conservations",
                newName: "Rango de conservación mínimo");

            migrationBuilder.RenameColumn(
                name: "Rango de seguridad máximo",
                table: "Conservations",
                newName: "Rango de conservación máximo");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Conservations",
                newName: "ConservationName_Value");

            migrationBuilder.RenameIndex(
                name: "IX_Conservations_Nombre",
                table: "Conservations",
                newName: "IX_Conservations_ConservationName_Value");
        }
    }
}
