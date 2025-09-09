using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddFormula1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_GrandPrixes_GrandPrixIsnGrandPrix",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_GrandPrixIsnGrandPrix",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GrandPrixIsnGrandPrix",
                table: "Teams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GrandPrixIsnGrandPrix",
                table: "Teams",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GrandPrixIsnGrandPrix",
                table: "Teams",
                column: "GrandPrixIsnGrandPrix");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_GrandPrixes_GrandPrixIsnGrandPrix",
                table: "Teams",
                column: "GrandPrixIsnGrandPrix",
                principalTable: "GrandPrixes",
                principalColumn: "IsnGrandPrix");
        }
    }
}
