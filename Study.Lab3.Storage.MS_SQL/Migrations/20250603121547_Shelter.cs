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
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShelterCustomers",
                newName: "IsnCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cats",
                newName: "IsnCat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Adoptions",
                newName: "IsnAdoption");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsnCustomer",
                table: "ShelterCustomers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IsnCat",
                table: "Cats",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IsnAdoption",
                table: "Adoptions",
                newName: "Id");
        }
    }
}
