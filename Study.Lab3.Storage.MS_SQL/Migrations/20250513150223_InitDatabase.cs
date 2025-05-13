using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations
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
                    IsnGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.IsnGroup);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    IsnSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.IsnSubject);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IsnStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatronymicName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
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
                name: "SubjectsGroups",
                columns: table => new
                {
                    IsnSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SubjectsGroups");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
