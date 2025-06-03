using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class AddBeautySalon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeautyAppointments",
                columns: table => new
                {
                    IsnAppointment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnService = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", maxLength: 31, nullable: false),
                    Month = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    Hour = table.Column<int>(type: "int", maxLength: 24, nullable: false),
                    Minutes = table.Column<int>(type: "int", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeautyAppointments", x => x.IsnAppointment);
                });

            migrationBuilder.CreateTable(
                name: "BeautyClients",
                columns: table => new
                {
                    IsnClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnAppointment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeautyClients", x => x.IsnClient);
                });

            migrationBuilder.CreateTable(
                name: "BeautyServices",
                columns: table => new
                {
                    IsnService = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", maxLength: 600, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeautyServices", x => x.IsnService);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeautyAppointments");

            migrationBuilder.DropTable(
                name: "BeautyClients");

            migrationBuilder.DropTable(
                name: "BeautyServices");
        }
    }
}
