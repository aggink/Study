using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Library : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    IsnAuthor = table.Column<Guid>(type: "uuid", nullable: false),
                    SurName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PatronymicName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    IsnTeacher = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.IsnAuthor);
                    table.ForeignKey(
                        name: "FK_Authors_Teachers_IsnTeacher",
                        column: x => x.IsnTeacher,
                        principalTable: "Teachers",
                        principalColumn: "IsnTeacher");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    IsnBook = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PublicationYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.IsnBook);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    IsnAuthor = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnBook = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => new { x.IsnAuthor, x.IsnBook });
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Authors_IsnAuthor",
                        column: x => x.IsnAuthor,
                        principalTable: "Authors",
                        principalColumn: "IsnAuthor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Books_IsnBook",
                        column: x => x.IsnBook,
                        principalTable: "Books",
                        principalColumn: "IsnBook",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_IsnAuthor_IsnBook",
                table: "AuthorBooks",
                columns: new[] { "IsnAuthor", "IsnBook" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_IsnBook",
                table: "AuthorBooks",
                column: "IsnBook");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_IsnTeacher",
                table: "Authors",
                column: "IsnTeacher",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
