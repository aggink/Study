using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectActivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TheProjectActivities",
                columns: table => new
                {
                    IsnProjectActivities = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerformancesCount = table.Column<int>(type: "int", nullable: false),
                    ProjectActivitiesDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheProjectActivities", x => x.IsnProjectActivities);
                    table.ForeignKey(
                        name: "FK_TheProjectActivities_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TheProjectActivities_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TheProjectActivities_IsnStudent",
                table: "TheProjectActivities",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_TheProjectActivities_IsnSubject",
                table: "TheProjectActivities",
                column: "IsnSubject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TheProjectActivities");
        }
    }
}
