using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class ScientificWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SCIENTIFIC_WORKS",
                columns: table => new
                {
                    ISN_SCIENTIFIC_WORK = table.Column<Guid>(type: "uuid", nullable: false),
                    ISN_STUDENT = table.Column<Guid>(type: "uuid", nullable: false),
                    ISN_SUBJECT = table.Column<Guid>(type: "uuid", nullable: false),
                    TITLE = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PAGE_COUNT = table.Column<int>(type: "integer", nullable: false),
                    PUBLICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IS_PUBLISHED = table.Column<bool>(type: "boolean", nullable: false),
                    StudentIsnStudent = table.Column<Guid>(type: "uuid", nullable: true),
                    SubjectIsnSubject = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCIENTIFIC_WORKS", x => x.ISN_SCIENTIFIC_WORK);
                    table.ForeignKey(
                        name: "FK_SCIENTIFIC_WORKS_Students_StudentIsnStudent",
                        column: x => x.StudentIsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent");
                    table.ForeignKey(
                        name: "FK_SCIENTIFIC_WORKS_Subjects_SubjectIsnSubject",
                        column: x => x.SubjectIsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject");
                });

            migrationBuilder.CreateTable(
                name: "WORK_REFERENCES",
                columns: table => new
                {
                    ISN_REFERENCE = table.Column<Guid>(type: "uuid", nullable: false),
                    ISN_SCIENTIFIC_WORK = table.Column<Guid>(type: "uuid", nullable: false),
                    REFERENCED_WORK_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    REFERENCE_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ScientificWorkIsnScientificWork = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORK_REFERENCES", x => x.ISN_REFERENCE);
                    table.ForeignKey(
                        name: "FK_WORK_REFERENCES_SCIENTIFIC_WORKS_ScientificWorkIsnScientifi~",
                        column: x => x.ScientificWorkIsnScientificWork,
                        principalTable: "SCIENTIFIC_WORKS",
                        principalColumn: "ISN_SCIENTIFIC_WORK");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SCIENTIFIC_WORKS_StudentIsnStudent",
                table: "SCIENTIFIC_WORKS",
                column: "StudentIsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_SCIENTIFIC_WORKS_SubjectIsnSubject",
                table: "SCIENTIFIC_WORKS",
                column: "SubjectIsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_WORK_REFERENCES_ScientificWorkIsnScientificWork",
                table: "WORK_REFERENCES",
                column: "ScientificWorkIsnScientificWork");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WORK_REFERENCES");

            migrationBuilder.DropTable(
                name: "SCIENTIFIC_WORKS");
        }
    }
}
