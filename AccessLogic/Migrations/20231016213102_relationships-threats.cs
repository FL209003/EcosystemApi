using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class relationshipsthreats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Ecosystems_EcosystemId",
                table: "Threats");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Species_SpeciesId",
                table: "Threats");

            migrationBuilder.DropIndex(
                name: "IX_Threats_EcosystemId",
                table: "Threats");

            migrationBuilder.DropIndex(
                name: "IX_Threats_SpeciesId",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "EcosystemId",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "Threats");

            migrationBuilder.CreateTable(
                name: "EcosystemThreat",
                columns: table => new
                {
                    EcosystemsId = table.Column<int>(type: "int", nullable: false),
                    ThreatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosystemThreat", x => new { x.EcosystemsId, x.ThreatsId });
                    table.ForeignKey(
                        name: "FK_EcosystemThreat_Ecosystems_EcosystemsId",
                        column: x => x.EcosystemsId,
                        principalTable: "Ecosystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcosystemThreat_Threats_ThreatsId",
                        column: x => x.ThreatsId,
                        principalTable: "Threats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesThreat",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    ThreatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesThreat", x => new { x.SpeciesId, x.ThreatsId });
                    table.ForeignKey(
                        name: "FK_SpeciesThreat_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeciesThreat_Threats_ThreatsId",
                        column: x => x.ThreatsId,
                        principalTable: "Threats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcosystemThreat_ThreatsId",
                table: "EcosystemThreat",
                column: "ThreatsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesThreat_ThreatsId",
                table: "SpeciesThreat",
                column: "ThreatsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcosystemThreat");

            migrationBuilder.DropTable(
                name: "SpeciesThreat");

            migrationBuilder.AddColumn<int>(
                name: "EcosystemId",
                table: "Threats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesId",
                table: "Threats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Threats_EcosystemId",
                table: "Threats",
                column: "EcosystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_SpeciesId",
                table: "Threats",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Ecosystems_EcosystemId",
                table: "Threats",
                column: "EcosystemId",
                principalTable: "Ecosystems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Species_SpeciesId",
                table: "Threats",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id");
        }
    }
}
