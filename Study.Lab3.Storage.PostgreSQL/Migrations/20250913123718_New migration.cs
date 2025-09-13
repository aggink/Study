using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IsnEmployee = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SurName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Work = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IsnEmployee);
                });

            migrationBuilder.CreateTable(
                name: "Interns",
                columns: table => new
                {
                    IsnIntern = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SurName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SkillLevel = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interns", x => x.IsnIntern);
                });

            migrationBuilder.CreateTable(
                name: "Officers",
                columns: table => new
                {
                    IsnOfficer = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SurName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Rank = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officers", x => x.IsnOfficer);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Interns");

            migrationBuilder.DropTable(
                name: "Officers");
        }
    }
}
