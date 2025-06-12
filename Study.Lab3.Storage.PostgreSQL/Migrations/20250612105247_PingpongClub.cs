using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class PingpongClub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pingpongclub",
                columns: table => new
                {
                    IsnPingpongclub = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipantsCount = table.Column<int>(type: "integer", nullable: false),
                    PingpongclubDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pingpongclub", x => x.IsnPingpongclub);
                    table.ForeignKey(
                        name: "FK_Pingpongclub_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pingpongclub_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pingpongclub_IsnStudent",
                table: "Pingpongclub",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Pingpongclub_IsnSubject",
                table: "Pingpongclub",
                column: "IsnSubject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pingpongclub");
        }
    }
}
