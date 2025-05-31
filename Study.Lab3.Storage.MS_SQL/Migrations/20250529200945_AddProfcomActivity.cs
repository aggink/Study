using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class AddProfcomActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TheProfcom",
                columns: table => new
                {
                    IsnProfcom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantsCount = table.Column<int>(type: "int", nullable: false),
                    ProfcomDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheProfcom", x => x.IsnProfcom);
                    table.ForeignKey(
                        name: "FK_TheProfcom_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheProfcom_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TheProfcom_IsnStudent",
                table: "TheProfcom",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_TheProfcom_IsnSubject",
                table: "TheProfcom",
                column: "IsnSubject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TheProfcom");
        }
    }
}
