using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    IsnGroup = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.IsnGroup);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.IsnSubject);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnGroup = table.Column<Guid>(type: "uuid", nullable: false),
                    SurName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PatronymicName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IsnStudent);
                    table.ForeignKey(
                        name: "FK_Students_Groups_IsnGroup",
                        column: x => x.IsnGroup,
                        principalTable: "Groups",
                        principalColumn: "IsnGroup",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Students_IsnGroup",
                table: "Students",
                column: "IsnGroup");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGroup_IsnGroup",
                table: "SubjectGroup",
                column: "IsnGroup");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGroup_IsnSubject_IsnGroup",
                table: "SubjectGroup",
                columns: new[] { "IsnSubject", "IsnGroup" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SubjectGroup");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
