using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddSweet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SweetFactories",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Volume = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetFactories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SweetTypes",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sweets",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    SweetTypeID = table.Column<long>(type: "bigint", nullable: false),
                    Ingredients = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sweets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sweets_SweetTypes_SweetTypeID",
                        column: x => x.SweetTypeID,
                        principalTable: "SweetTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SweetProductions",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    SweetID = table.Column<long>(type: "bigint", nullable: false),
                    SweetFactoryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetProductions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SweetProductions_SweetFactories_SweetFactoryID",
                        column: x => x.SweetFactoryID,
                        principalTable: "SweetFactories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SweetProductions_Sweets_SweetID",
                        column: x => x.SweetID,
                        principalTable: "Sweets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SweetSweetFactory",
                columns: table => new
                {
                    SweetFactoriesID = table.Column<long>(type: "bigint", nullable: false),
                    SweetsID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetSweetFactory", x => new { x.SweetFactoriesID, x.SweetsID });
                    table.ForeignKey(
                        name: "FK_SweetSweetFactory_SweetFactories_SweetFactoriesID",
                        column: x => x.SweetFactoriesID,
                        principalTable: "SweetFactories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SweetSweetFactory_Sweets_SweetsID",
                        column: x => x.SweetsID,
                        principalTable: "Sweets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SweetProductions_SweetFactoryID",
                table: "SweetProductions",
                column: "SweetFactoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SweetProductions_SweetID",
                table: "SweetProductions",
                column: "SweetID");

            migrationBuilder.CreateIndex(
                name: "IX_Sweets_SweetTypeID",
                table: "Sweets",
                column: "SweetTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SweetSweetFactory_SweetsID",
                table: "SweetSweetFactory",
                column: "SweetsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SweetProductions");

            migrationBuilder.DropTable(
                name: "SweetSweetFactory");

            migrationBuilder.DropTable(
                name: "SweetFactories");

            migrationBuilder.DropTable(
                name: "Sweets");

            migrationBuilder.DropTable(
                name: "SweetTypes");
        }
    }
}
