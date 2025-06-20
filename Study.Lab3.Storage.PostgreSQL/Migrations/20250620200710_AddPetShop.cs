using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddPetShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetFoods",
                columns: table => new
                {
                    IsnPetFood = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    TargetSpecies = table.Column<int>(type: "integer", nullable: false),
                    WeightInGrams = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Ingredients = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetFoods", x => x.IsnPetFood);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    IsnPet = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Species = table.Column<int>(type: "integer", nullable: false),
                    Breed = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AgeInMonths = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.IsnPet);
                });

            migrationBuilder.CreateTable(
                name: "PetToys",
                columns: table => new
                {
                    IsnPetToy = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Material = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    TargetSpecies = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    AgeGroup = table.Column<int>(type: "integer", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false),
                    IsSafe = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetToys", x => x.IsnPetToy);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetFoods");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "PetToys");
        }
    }
}
