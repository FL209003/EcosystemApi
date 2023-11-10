using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class countriesecosystems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Ecosystems_EcosystemId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_EcosystemId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "EcosystemId",
                table: "Countries");

            migrationBuilder.CreateTable(
                name: "CountryEcosystem",
                columns: table => new
                {
                    CountriesId = table.Column<int>(type: "int", nullable: false),
                    EcosystemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryEcosystem", x => new { x.CountriesId, x.EcosystemsId });
                    table.ForeignKey(
                        name: "FK_CountryEcosystem_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryEcosystem_Ecosystems_EcosystemsId",
                        column: x => x.EcosystemsId,
                        principalTable: "Ecosystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryEcosystem_EcosystemsId",
                table: "CountryEcosystem",
                column: "EcosystemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryEcosystem");

            migrationBuilder.AddColumn<int>(
                name: "EcosystemId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_EcosystemId",
                table: "Countries",
                column: "EcosystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Ecosystems_EcosystemId",
                table: "Countries",
                column: "EcosystemId",
                principalTable: "Ecosystems",
                principalColumn: "Id");
        }
    }
}
