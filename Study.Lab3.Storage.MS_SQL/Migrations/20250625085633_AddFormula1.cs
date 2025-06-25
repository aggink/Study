using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class AddFormula1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrandPrixes",
                columns: table => new
                {
                    IsnGrandPrix = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Winner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Circuit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrixes", x => x.IsnGrandPrix);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    IsnTeam = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearOfCreation = table.Column<int>(type: "int", nullable: false),
                    EngineSupplier = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.IsnTeam);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    IsnDriver = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnTeam = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GrandPrixIsnGrandPrix = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.IsnDriver);
                    table.ForeignKey(
                        name: "FK_Drivers_GrandPrixes_GrandPrixIsnGrandPrix",
                        column: x => x.GrandPrixIsnGrandPrix,
                        principalTable: "GrandPrixes",
                        principalColumn: "IsnGrandPrix");
                    table.ForeignKey(
                        name: "FK_Drivers_Teams_IsnTeam",
                        column: x => x.IsnTeam,
                        principalTable: "Teams",
                        principalColumn: "IsnTeam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RaceResults",
                columns: table => new
                {
                    IsnDriver = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnGrandPrix = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartPosition = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    PointsEarned = table.Column<int>(type: "int", nullable: false),
                    DidNotFinish = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceResults", x => new { x.IsnDriver, x.IsnGrandPrix });
                    table.ForeignKey(
                        name: "FK_RaceResults_Drivers_IsnGrandPrix",
                        column: x => x.IsnGrandPrix,
                        principalTable: "Drivers",
                        principalColumn: "IsnDriver",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaceResults_GrandPrixes_IsnDriver",
                        column: x => x.IsnDriver,
                        principalTable: "GrandPrixes",
                        principalColumn: "IsnGrandPrix",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_GrandPrixIsnGrandPrix",
                table: "Drivers",
                column: "GrandPrixIsnGrandPrix");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_IsnTeam",
                table: "Drivers",
                column: "IsnTeam");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_IsnDriver_IsnGrandPrix",
                table: "RaceResults",
                columns: new[] { "IsnDriver", "IsnGrandPrix" });

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_IsnGrandPrix",
                table: "RaceResults",
                column: "IsnGrandPrix",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceResults");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "GrandPrixes");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
