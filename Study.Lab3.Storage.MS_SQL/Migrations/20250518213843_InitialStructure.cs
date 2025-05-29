using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    IsnAnnouncement = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnTeacher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsImportant = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Assignments",
                columns: table => new
                {
                    IsnAssignment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaxScore = table.Column<int>(type: "int", nullable: false)
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
                name: "Materials",
                columns: table => new
                {
                    IsnMaterial = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "AnnouncementGroups",
                columns: table => new
                {
                    IsnAnnouncement = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "IX_Materials_IsnSubject",
                table: "Materials",
                column: "IsnSubject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementGroups");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Announcements");
        }
    }
}
