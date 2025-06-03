using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddBeautySalon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeautyClient",
                columns: table => new
                {
                    IsnClient = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    EmailAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeautyClient", x => x.IsnClient);
                });

            migrationBuilder.CreateTable(
                name: "BeautyService",
                columns: table => new
                {
                    IsnService = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeautyService", x => x.IsnService);
                });

            migrationBuilder.CreateTable(
                name: "BeautyAppointment",
                columns: table => new
                {
                    IsnAppointment = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnBeautyClient = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnBeautyService = table.Column<Guid>(type: "uuid", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    Hour = table.Column<int>(type: "integer", nullable: false),
                    Minutes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeautyAppointment", x => x.IsnAppointment);
                    table.ForeignKey(
                        name: "FK_BeautyAppointment_BeautyClient_IsnBeautyClient",
                        column: x => x.IsnBeautyClient,
                        principalTable: "BeautyClient",
                        principalColumn: "IsnClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeautyAppointment_BeautyService_IsnBeautyService",
                        column: x => x.IsnBeautyService,
                        principalTable: "BeautyService",
                        principalColumn: "IsnService",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeautyAppointment_IsnBeautyClient",
                table: "BeautyAppointment",
                column: "IsnBeautyClient");

            migrationBuilder.CreateIndex(
                name: "IX_BeautyAppointment_IsnBeautyService",
                table: "BeautyAppointment",
                column: "IsnBeautyService");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeautyAppointment");

            migrationBuilder.DropTable(
                name: "BeautyClient");

            migrationBuilder.DropTable(
                name: "BeautyService");
        }
    }
}
