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
                name: "DormitoryBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FloorsCount = table.Column<int>(type: "int", nullable: false),
                    TotalRooms = table.Column<int>(type: "int", nullable: false),
                    BuildYear = table.Column<int>(type: "int", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ManagerPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryBuildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryResidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StudentGroup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedCheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualCheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryResidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    MaxOccupants = table.Column<int>(type: "int", nullable: false),
                    CurrentOccupants = table.Column<int>(type: "int", nullable: false),
                    MonthlyRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HasBalcony = table.Column<bool>(type: "bit", nullable: false),
                    HasPrivateBathroom = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryRooms", x => x.Id);
                });

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
                name: "ScientificWorks",
                columns: table => new
                {
                    IsnScientificWork = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificWorks", x => x.IsnScientificWork);
                    table.ForeignKey(
                        name: "FK_ScientificWorks_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScientificWorks_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
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
                name: "WorkReferences",
                columns: table => new
                {
                    IsnReference = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferencedWorkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceWorkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkReferences", x => x.IsnReference);
                    table.ForeignKey(
                        name: "FK_WorkReferences_ScientificWorks_ReferencedWorkId",
                        column: x => x.ReferencedWorkId,
                        principalTable: "ScientificWorks",
                        principalColumn: "IsnScientificWork",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkReferences_ScientificWorks_SourceWorkId",
                        column: x => x.SourceWorkId,
                        principalTable: "ScientificWorks",
                        principalColumn: "IsnScientificWork",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_ScientificWorks_IsnStudent",
                table: "ScientificWorks",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificWorks_IsnSubject",
                table: "ScientificWorks",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_WorkReferences_ReferencedWorkId",
                table: "WorkReferences",
                column: "ReferencedWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkReferences_SourceWorkId",
                table: "WorkReferences",
                column: "SourceWorkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DormitoryBuildings");

            migrationBuilder.DropTable(
                name: "DormitoryResidents");

            migrationBuilder.DropTable(
                name: "DormitoryRooms");

            migrationBuilder.DropTable(
                name: "RaceResults");

            migrationBuilder.DropTable(
                name: "WorkReferences");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "ScientificWorks");

            migrationBuilder.DropTable(
                name: "GrandPrixes");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
