using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddBookshopKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookshopAuthors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    BirthYear = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookshopAuthors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BookshopGenres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookshopGenres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "BookshopBooks",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Pages = table.Column<int>(type: "integer", nullable: true),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookshopBooks", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_BookshopBooks_BookshopAuthors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "BookshopAuthors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookshopBooks_BookshopGenres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "BookshopGenres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookshopBooks_AuthorId",
                table: "BookshopBooks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookshopBooks_GenreId",
                table: "BookshopBooks",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookshopBooks");

            migrationBuilder.DropTable(
                name: "BookshopAuthors");

            migrationBuilder.DropTable(
                name: "BookshopGenres");
        }
    }
}
