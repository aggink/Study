using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Photography : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotographyClients",
                columns: table => new
                {
                    IsnPhotographyClient = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographyClients", x => x.IsnPhotographyClient);
                });

            migrationBuilder.CreateTable(
                name: "PhotographyEquipments",
                columns: table => new
                {
                    IsnPhotographyEquipment = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SerialNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographyEquipments", x => x.IsnPhotographyEquipment);
                });

            migrationBuilder.CreateTable(
                name: "PhotographySessions",
                columns: table => new
                {
                    IsnPhotographySession = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SessionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    PhotographerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhotographySessionType = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PhotoCount = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographySessions", x => x.IsnPhotographySession);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotographyClients");

            migrationBuilder.DropTable(
                name: "PhotographyEquipments");

            migrationBuilder.DropTable(
                name: "PhotographySessions");
        }
    }
}
