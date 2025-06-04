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
            migrationBuilder.DropForeignKey(
                name: "FK_Adoptions_Cats_CatIsn",
                table: "Adoptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Adoptions_ShelterCustomers_CustomerIsn",
                table: "Adoptions");

            migrationBuilder.RenameColumn(
                name: "CustomerIsn",
                table: "Adoptions",
                newName: "IsnCustomer");

            migrationBuilder.RenameColumn(
                name: "CatIsn",
                table: "Adoptions",
                newName: "IsnCat");

            migrationBuilder.RenameIndex(
                name: "IX_Adoptions_CustomerIsn",
                table: "Adoptions",
                newName: "IX_Adoptions_IsnCustomer");

            migrationBuilder.RenameIndex(
                name: "IX_Adoptions_CatIsn",
                table: "Adoptions",
                newName: "IX_Adoptions_IsnCat");

            migrationBuilder.AddForeignKey(
                name: "FK_Adoptions_Cats_IsnCat",
                table: "Adoptions",
                column: "IsnCat",
                principalTable: "Cats",
                principalColumn: "IsnCat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adoptions_ShelterCustomers_IsnCustomer",
                table: "Adoptions",
                column: "IsnCustomer",
                principalTable: "ShelterCustomers",
                principalColumn: "IsnCustomer",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adoptions_Cats_IsnCat",
                table: "Adoptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Adoptions_ShelterCustomers_IsnCustomer",
                table: "Adoptions");

            migrationBuilder.RenameColumn(
                name: "IsnCustomer",
                table: "Adoptions",
                newName: "CustomerIsn");

            migrationBuilder.RenameColumn(
                name: "IsnCat",
                table: "Adoptions",
                newName: "CatIsn");

            migrationBuilder.RenameIndex(
                name: "IX_Adoptions_IsnCustomer",
                table: "Adoptions",
                newName: "IX_Adoptions_CustomerIsn");

            migrationBuilder.RenameIndex(
                name: "IX_Adoptions_IsnCat",
                table: "Adoptions",
                newName: "IX_Adoptions_CatIsn");

            migrationBuilder.AddForeignKey(
                name: "FK_Adoptions_Cats_CatIsn",
                table: "Adoptions",
                column: "CatIsn",
                principalTable: "Cats",
                principalColumn: "IsnCat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adoptions_ShelterCustomers_CustomerIsn",
                table: "Adoptions",
                column: "CustomerIsn",
                principalTable: "ShelterCustomers",
                principalColumn: "IsnCustomer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
