using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations;

/// <inheritdoc />
public partial class AddSportclub : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Sportclub",
            columns: table => new
            {
                IsnSportclub = table.Column<Guid>(type: "uuid", nullable: false),
                IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                ParticipantsCount = table.Column<int>(type: "integer", nullable: false),
                SportclubDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Sportclub", x => x.IsnSportclub);
                table.ForeignKey(
                    name: "FK_Sportclub_Students_IsnStudent",
                    column: x => x.IsnStudent,
                    principalTable: "Students",
                    principalColumn: "IsnStudent",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Sportclub_Subjects_IsnSubject",
                    column: x => x.IsnSubject,
                    principalTable: "Subjects",
                    principalColumn: "IsnSubject",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Sportclub_IsnStudent",
            table: "Sportclub",
            column: "IsnStudent");

        migrationBuilder.CreateIndex(
            name: "IX_Sportclub_IsnSubject",
            table: "Sportclub",
            column: "IsnSubject");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Sportclub");
    }
}
