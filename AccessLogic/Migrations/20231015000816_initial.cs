using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConservationName_Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rangodeconservaciónmínimo = table.Column<int>(name: "Rango de conservación mínimo", type: "int", nullable: false),
                    Rangodeconservaciónmáximo = table.Column<int>(name: "Rango de conservación máximo", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Limits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fechaderegistro = table.Column<DateTime>(name: "Fecha de registro", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ecosystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EcosystemName_Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ubicación = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Área = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EcoDescription_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EcoConservationId = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecosystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ecosystems_Conservations_EcoConservationId",
                        column: x => x.EcoConservationId,
                        principalTable: "Conservations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cientificname = table.Column<string>(name: "Cientific name", type: "nvarchar(max)", nullable: false),
                    SpeciesName_Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SpeciesDescription_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Minweight = table.Column<decimal>(name: "Min weight", type: "decimal(18,2)", nullable: false),
                    Maxweight = table.Column<decimal>(name: "Max weight", type: "decimal(18,2)", nullable: false),
                    Minlength = table.Column<decimal>(name: "Min length", type: "decimal(18,2)", nullable: false),
                    Maxlength = table.Column<decimal>(name: "Max length", type: "decimal(18,2)", nullable: false),
                    SpeciesConservationId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Conservations_SpeciesConservationId",
                        column: x => x.SpeciesConservationId,
                        principalTable: "Conservations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName_Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Códigoalfa3 = table.Column<string>(name: "Código alfa-3", type: "nvarchar(450)", nullable: false),
                    EcosystemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Ecosystems_EcosystemId",
                        column: x => x.EcosystemId,
                        principalTable: "Ecosystems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EcosystemSpecies",
                columns: table => new
                {
                    EcosystemsId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosystemSpecies", x => new { x.EcosystemsId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_EcosystemSpecies_Ecosystems_EcosystemsId",
                        column: x => x.EcosystemsId,
                        principalTable: "Ecosystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcosystemSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Threats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreatName_Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThreatDescription_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Niveldepeligrosidad = table.Column<int>(name: "Nivel de peligrosidad", type: "int", nullable: false),
                    EcosystemId = table.Column<int>(type: "int", nullable: true),
                    SpeciesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threats_Ecosystems_EcosystemId",
                        column: x => x.EcosystemId,
                        principalTable: "Ecosystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Threats_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conservations_ConservationName_Value",
                table: "Conservations",
                column: "ConservationName_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Código alfa-3",
                table: "Countries",
                column: "Código alfa-3",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryName_Value",
                table: "Countries",
                column: "CountryName_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_EcosystemId",
                table: "Countries",
                column: "EcosystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosystems_EcoConservationId",
                table: "Ecosystems",
                column: "EcoConservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosystems_EcosystemName_Value",
                table: "Ecosystems",
                column: "EcosystemName_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EcosystemSpecies_SpeciesId",
                table: "EcosystemSpecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Limits_Name",
                table: "Limits",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Species_SpeciesConservationId",
                table: "Species",
                column: "SpeciesConservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_SpeciesName_Value",
                table: "Species",
                column: "SpeciesName_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Threats_EcosystemId",
                table: "Threats",
                column: "EcosystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_SpeciesId",
                table: "Threats",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_ThreatName_Value",
                table: "Threats",
                column: "ThreatName_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "EcosystemSpecies");

            migrationBuilder.DropTable(
                name: "Limits");

            migrationBuilder.DropTable(
                name: "Threats");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ecosystems");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Conservations");
        }
    }
}
