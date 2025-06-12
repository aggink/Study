using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class StudentLab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Labs",
                columns: table => new
                {
                    IsnLab = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labs", x => x.IsnLab);
                });

            migrationBuilder.CreateTable(
                name: "StudentLab",
                columns: table => new
                {
                    IsnStudentLab = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnLab = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLab", x => x.IsnStudentLab);
                    table.ForeignKey(
                        name: "FK_StudentLab_Labs_IsnLab",
                        column: x => x.IsnLab,
                        principalTable: "Labs",
                        principalColumn: "IsnLab",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentLab_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentLab_IsnLab",
                table: "StudentLab",
                column: "IsnLab");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLab_IsnStudent",
                table: "StudentLab",
                column: "IsnStudent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentLab");

            migrationBuilder.DropTable(
                name: "Labs");
        }
    }
}
