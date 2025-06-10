using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentNotes",
                columns: table => new
                {
                    IsnNote = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNotes", x => x.IsnNote);
                    table.ForeignKey(
                        name: "FK_StudentNotes_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentNotes_IsnStudent",
                table: "StudentNotes",
                column: "IsnStudent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentNotes");
        }
    }
}
