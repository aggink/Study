using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddMuseum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MuseumExhibits",
                columns: table => new
                {
                    IsnMuseumExhibit = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AcquisitionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstimatedValue = table.Column<double>(type: "double precision", nullable: false),
                    Location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuseumExhibits", x => x.IsnMuseumExhibit);
                });

            migrationBuilder.CreateTable(
                name: "MuseumVisitors",
                columns: table => new
                {
                    IsnMuseumVisitor = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TicketType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TicketPrice = table.Column<double>(type: "double precision", nullable: false),
                    IsMember = table.Column<bool>(type: "boolean", nullable: false),
                    MembershipNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuseumVisitors", x => x.IsnMuseumVisitor);
                });

            migrationBuilder.CreateTable(
                name: "MuseumExhibitDetails",
                columns: table => new
                {
                    IsnMuseumExhibitDetails = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnMuseumExhibit = table.Column<Guid>(type: "uuid", nullable: false),
                    Origin = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Creator = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreationYear = table.Column<int>(type: "integer", nullable: true),
                    Material = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Dimensions = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: true),
                    HistoricalPeriod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Condition = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuseumExhibitDetails", x => x.IsnMuseumExhibitDetails);
                    table.ForeignKey(
                        name: "FK_MuseumExhibitDetails_MuseumExhibits_IsnMuseumExhibit",
                        column: x => x.IsnMuseumExhibit,
                        principalTable: "MuseumExhibits",
                        principalColumn: "IsnMuseumExhibit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MuseumExhibitDetails_IsnMuseumExhibit",
                table: "MuseumExhibitDetails",
                column: "IsnMuseumExhibit",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuseumExhibitDetails");

            migrationBuilder.DropTable(
                name: "MuseumVisitors");

            migrationBuilder.DropTable(
                name: "MuseumExhibits");
        }
    }
}
