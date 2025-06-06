using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class Shelter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    IsnCat = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsVaccinated = table.Column<bool>(type: "bit", nullable: false),
                    IsSterilized = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MedicalHistory = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailableForAdoption = table.Column<bool>(type: "bit", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.IsnCat);
                });

            migrationBuilder.CreateTable(
                name: "ShelterCustomers",
                columns: table => new
                {
                    IsnCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterCustomers", x => x.IsnCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Adoptions",
                columns: table => new
                {
                    IsnAdoption = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnCat = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    AdoptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptions", x => x.IsnAdoption);
                    table.ForeignKey(
                        name: "FK_Adoptions_Cats_IsnCat",
                        column: x => x.IsnCat,
                        principalTable: "Cats",
                        principalColumn: "IsnCat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adoptions_ShelterCustomers_IsnCustomer",
                        column: x => x.IsnCustomer,
                        principalTable: "ShelterCustomers",
                        principalColumn: "IsnCustomer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_IsnCat",
                table: "Adoptions",
                column: "IsnCat");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_IsnCustomer",
                table: "Adoptions",
                column: "IsnCustomer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoptions");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "ShelterCustomers");
        }
    }
}
