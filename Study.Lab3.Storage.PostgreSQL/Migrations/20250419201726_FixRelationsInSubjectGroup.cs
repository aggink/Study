using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
//Корректировка FK в SubjectsGroups для PostgreSQL
namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationsInSubjectGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectsGroups_Groups_IsnSubject",
                table: "SubjectsGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectsGroups_Subjects_IsnGroup",
                table: "SubjectsGroups");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectsGroups_Groups_IsnGroup",
                table: "SubjectsGroups",
                column: "IsnGroup",
                principalTable: "Groups",
                principalColumn: "IsnGroup",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectsGroups_Subjects_IsnSubject",
                table: "SubjectsGroups",
                column: "IsnSubject",
                principalTable: "Subjects",
                principalColumn: "IsnSubject",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectsGroups_Groups_IsnGroup",
                table: "SubjectsGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectsGroups_Subjects_IsnSubject",
                table: "SubjectsGroups");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectsGroups_Groups_IsnSubject",
                table: "SubjectsGroups",
                column: "IsnSubject",
                principalTable: "Groups",
                principalColumn: "IsnGroup",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectsGroups_Subjects_IsnGroup",
                table: "SubjectsGroups",
                column: "IsnGroup",
                principalTable: "Subjects",
                principalColumn: "IsnSubject",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
