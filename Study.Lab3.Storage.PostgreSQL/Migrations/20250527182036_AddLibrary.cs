using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddLibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    IsnBook = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PublicationYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.IsnBook);
                });

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
                name: "Teachers",
                columns: table => new
                {
                    IsnTeacher = table.Column<Guid>(type: "uuid", nullable: false),
                    SurName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PatronymicName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.IsnTeacher);
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
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false)
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
                name: "Assignments",
                columns: table => new
                {
                    IsnAssignment = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MaxScore = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.IsnAssignment);
                    table.ForeignKey(
                        name: "FK_Assignments_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Materials",
                columns: table => new
                {
                    IsnMaterial = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.IsnMaterial);
                    table.ForeignKey(
                        name: "FK_Materials_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_SubjectsGroups_Groups_IsnGroup",
                        column: x => x.IsnGroup,
                        principalTable: "Groups",
                        principalColumn: "IsnGroup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsGroups_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    IsnAnnouncement = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnTeacher = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsImportant = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.IsnAnnouncement);
                    table.ForeignKey(
                        name: "FK_Announcements_Teachers_IsnTeacher",
                        column: x => x.IsnTeacher,
                        principalTable: "Teachers",
                        principalColumn: "IsnTeacher",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    IsnAuthor = table.Column<Guid>(type: "uuid", nullable: false),
                    SurName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PatronymicName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    IsnTeacher = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.IsnAuthor);
                    table.ForeignKey(
                        name: "FK_Authors_Teachers_IsnTeacher",
                        column: x => x.IsnTeacher,
                        principalTable: "Teachers",
                        principalColumn: "IsnTeacher");
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubjects",
                columns: table => new
                {
                    IsnTeacher = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => new { x.IsnTeacher, x.IsnSubject });
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Teachers_IsnTeacher",
                        column: x => x.IsnTeacher,
                        principalTable: "Teachers",
                        principalColumn: "IsnTeacher",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    IsnGrade = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    GradeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                name: "AnnouncementGroups",
                columns: table => new
                {
                    IsnAnnouncement = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnGroup = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementGroups", x => new { x.IsnAnnouncement, x.IsnGroup });
                    table.ForeignKey(
                        name: "FK_AnnouncementGroups_Announcements_IsnAnnouncement",
                        column: x => x.IsnAnnouncement,
                        principalTable: "Announcements",
                        principalColumn: "IsnAnnouncement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnouncementGroups_Groups_IsnGroup",
                        column: x => x.IsnGroup,
                        principalTable: "Groups",
                        principalColumn: "IsnGroup",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    IsnAuthor = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnBook = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => new { x.IsnAuthor, x.IsnBook });
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Authors_IsnAuthor",
                        column: x => x.IsnAuthor,
                        principalTable: "Authors",
                        principalColumn: "IsnAuthor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Books_IsnBook",
                        column: x => x.IsnBook,
                        principalTable: "Books",
                        principalColumn: "IsnBook",
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
                name: "IX_AnnouncementGroups_IsnAnnouncement_IsnGroup",
                table: "AnnouncementGroups",
                columns: new[] { "IsnAnnouncement", "IsnGroup" });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementGroups_IsnGroup",
                table: "AnnouncementGroups",
                column: "IsnGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_IsnTeacher",
                table: "Announcements",
                column: "IsnTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_IsnSubject",
                table: "Assignments",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_IsnAuthor_IsnBook",
                table: "AuthorBooks",
                columns: new[] { "IsnAuthor", "IsnBook" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_IsnBook",
                table: "AuthorBooks",
                column: "IsnBook");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_IsnTeacher",
                table: "Authors",
                column: "IsnTeacher",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Grades_IsnStudent",
                table: "Grades",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_IsnSubject",
                table: "Grades",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_IsnSubject",
                table: "Materials",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IsnGroup",
                table: "Students",
                column: "IsnGroup");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsGroups_IsnGroup",
                table: "SubjectsGroups",
                column: "IsnGroup");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsGroups_IsnSubject_IsnGroup",
                table: "SubjectsGroups",
                columns: new[] { "IsnSubject", "IsnGroup" });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_IsnSubject",
                table: "TeacherSubjects",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_IsnTeacher_IsnSubject",
                table: "TeacherSubjects",
                columns: new[] { "IsnTeacher", "IsnSubject" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementGroups");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "ExamResults");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "SubjectsGroups");

            migrationBuilder.DropTable(
                name: "TeacherSubjects");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "ExamRegistrations");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
