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
                name: "FK_Adoptions_Cats_CatId",
                table: "Adoptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Adoptions_ShelterCustomers_CustomerId",
                table: "Adoptions");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Adoptions",
                newName: "CustomerIsn");

            migrationBuilder.RenameColumn(
                name: "CatId",
                table: "Adoptions",
                newName: "CatIsn");

            migrationBuilder.RenameIndex(
                name: "IX_Adoptions_CustomerId",
                table: "Adoptions",
                newName: "IX_Adoptions_CustomerIsn");

            migrationBuilder.RenameIndex(
                name: "IX_Adoptions_CatId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "CatIsn",
                table: "Adoptions",
                newName: "CatId");

            migrationBuilder.RenameIndex(
                name: "IX_Adoptions_CustomerIsn",
                table: "Adoptions",
                newName: "IX_Adoptions_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Adoptions_CatIsn",
                table: "Adoptions",
                newName: "IX_Adoptions_CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adoptions_Cats_CatId",
                table: "Adoptions",
                column: "CatId",
                principalTable: "Cats",
                principalColumn: "IsnCat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adoptions_ShelterCustomers_CustomerId",
                table: "Adoptions",
                column: "CustomerId",
                principalTable: "ShelterCustomers",
                principalColumn: "IsnCustomer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
