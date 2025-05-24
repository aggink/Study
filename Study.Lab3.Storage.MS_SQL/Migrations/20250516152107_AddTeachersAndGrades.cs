using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class AddTeachersAndGrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Сначала создаем таблицу Teachers
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    IsnTeacher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatronymicName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.IsnTeacher);
                });

            // 2. Затем TeacherSubjects
            migrationBuilder.CreateTable(
                name: "TeacherSubjects",
                columns: table => new
                {
                    IsnTeacher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => new { x.IsnTeacher, x.IsnSubject });
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Teachers_IsnTeacher",
                        column: x => x.IsnTeacher,
                        principalTable: "Teachers",
                        principalColumn: "IsnTeacher",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            // 3. И наконец Grades
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    IsnGrade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    GradeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.IsnGrade);
                    table.ForeignKey(
                        name: "FK_Grades_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            // Индексы
            migrationBuilder.CreateIndex(
                name: "IX_Grades_IsnStudent",
                table: "Grades",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_IsnSubject",
                table: "Grades",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_IsnSubject",
                table: "TeacherSubjects",
                column: "IsnSubject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "TeacherSubjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
