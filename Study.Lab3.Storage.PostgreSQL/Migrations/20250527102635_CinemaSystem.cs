using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class CinemaSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IsnCustomer = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IsnCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    IsnGenre = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.IsnGenre);
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    IsnHall = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    RowsCount = table.Column<int>(type: "integer", nullable: false),
                    SeatsPerRow = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.IsnHall);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    IsnMovie = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AgeRating = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.IsnMovie);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    IsnSeat = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnHall = table.Column<Guid>(type: "uuid", nullable: false),
                    Row = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.IsnSeat);
                    table.ForeignKey(
                        name: "FK_Seats_Halls_IsnHall",
                        column: x => x.IsnHall,
                        principalTable: "Halls",
                        principalColumn: "IsnHall",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    IsnMovie = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnGenre = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.IsnMovie, x.IsnGenre });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_IsnGenre",
                        column: x => x.IsnGenre,
                        principalTable: "Genres",
                        principalColumn: "IsnGenre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_IsnMovie",
                        column: x => x.IsnMovie,
                        principalTable: "Movies",
                        principalColumn: "IsnMovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    IsnSession = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnMovie = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnHall = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BasePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.IsnSession);
                    table.ForeignKey(
                        name: "FK_Sessions_Halls_IsnHall",
                        column: x => x.IsnHall,
                        principalTable: "Halls",
                        principalColumn: "IsnHall",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Movies_IsnMovie",
                        column: x => x.IsnMovie,
                        principalTable: "Movies",
                        principalColumn: "IsnMovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    IsnTicket = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSession = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSeat = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnCustomer = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TicketCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.IsnTicket);
                    table.ForeignKey(
                        name: "FK_Tickets_Customers_IsnCustomer",
                        column: x => x.IsnCustomer,
                        principalTable: "Customers",
                        principalColumn: "IsnCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_IsnSeat",
                        column: x => x.IsnSeat,
                        principalTable: "Seats",
                        principalColumn: "IsnSeat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Sessions_IsnSession",
                        column: x => x.IsnSession,
                        principalTable: "Sessions",
                        principalColumn: "IsnSession",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_IsnGenre",
                table: "MovieGenres",
                column: "IsnGenre");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_IsnHall",
                table: "Seats",
                column: "IsnHall");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_IsnHall",
                table: "Sessions",
                column: "IsnHall");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_IsnMovie",
                table: "Sessions",
                column: "IsnMovie");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IsnCustomer",
                table: "Tickets",
                column: "IsnCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IsnSeat",
                table: "Tickets",
                column: "IsnSeat");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IsnSession",
                table: "Tickets",
                column: "IsnSession");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
