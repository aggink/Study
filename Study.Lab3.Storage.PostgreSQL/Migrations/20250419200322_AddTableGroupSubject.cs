using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
//Создание новой таблицы SubjectsGroups с аналогичной структурой
namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddTableGroupSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectGroup");

            migrationBuilder.CreateTable(
                name: "SubjectsGroups",
                columns: table => new
                {
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnGroup = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsGroups", x => new { x.IsnSubject, x.IsnGroup });
                    table.ForeignKey(
                        name: "FK_SubjectsGroups_Groups_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Groups",
                        principalColumn: "IsnGroup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsGroups_Subjects_IsnGroup",
                        column: x => x.IsnGroup,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsGroups_IsnGroup",
                table: "SubjectsGroups",
                column: "IsnGroup");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsGroups_IsnSubject_IsnGroup",
                table: "SubjectsGroups",
                columns: new[] { "IsnSubject", "IsnGroup" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectsGroups");

            migrationBuilder.CreateTable(
                name: "SubjectGroup",
                columns: table => new
                {
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnGroup = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectGroup", x => new { x.IsnSubject, x.IsnGroup });
                    table.ForeignKey(
                        name: "FK_SubjectGroup_Groups_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Groups",
                        principalColumn: "IsnGroup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectGroup_Subjects_IsnGroup",
                        column: x => x.IsnGroup,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGroup_IsnGroup",
                table: "SubjectGroup",
                column: "IsnGroup");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGroup_IsnSubject_IsnGroup",
                table: "SubjectGroup",
                columns: new[] { "IsnSubject", "IsnGroup" });
        }
    }
}