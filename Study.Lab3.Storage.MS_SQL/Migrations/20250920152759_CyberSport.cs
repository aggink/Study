using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class CyberSport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CyberSport",
                columns: table => new
                {
                    IsnCyberSport = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointsCount = table.Column<int>(type: "int", nullable: false),
                    CyberSportDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyberSport", x => x.IsnCyberSport);
                    table.ForeignKey(
                        name: "FK_CyberSport_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CyberSport_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CyberSport_IsnStudent",
                table: "CyberSport",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_CyberSport_IsnSubject",
                table: "CyberSport",
                column: "IsnSubject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CyberSport");
        }
    }
}
