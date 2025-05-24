using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddExaminationSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    IsnExam = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ExamDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    MaxScore = table.Column<int>(type: "integer", nullable: false),
                    PassingScore = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.IsnExam);
                    table.ForeignKey(
                        name: "FK_Exams_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamRegistrations",
                columns: table => new
                {
                    IsnExamRegistration = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnExam = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamRegistrations", x => x.IsnExamRegistration);
                    table.ForeignKey(
                        name: "FK_ExamRegistrations_Exams_IsnExam",
                        column: x => x.IsnExam,
                        principalTable: "Exams",
                        principalColumn: "IsnExam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamRegistrations_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamResults",
                columns: table => new
                {
                    IsnExamResult = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnExamRegistration = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    IsPassed = table.Column<bool>(type: "boolean", nullable: false),
                    Comments = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResults", x => x.IsnExamResult);
                    table.ForeignKey(
                        name: "FK_ExamResults_ExamRegistrations_IsnExamRegistration",
                        column: x => x.IsnExamRegistration,
                        principalTable: "ExamRegistrations",
                        principalColumn: "IsnExamRegistration",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamRegistrations_IsnExam",
                table: "ExamRegistrations",
                column: "IsnExam");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRegistrations_IsnStudent",
                table: "ExamRegistrations",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_IsnExamRegistration",
                table: "ExamResults",
                column: "IsnExamRegistration",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_IsnSubject",
                table: "Exams",
                column: "IsnSubject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamResults");

            migrationBuilder.DropTable(
                name: "ExamRegistrations");

            migrationBuilder.DropTable(
                name: "Exams");
        }
    }
}
