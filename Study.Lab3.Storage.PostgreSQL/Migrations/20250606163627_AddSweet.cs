using System;
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
                    IsnSweetFactory = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Volume = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetFactories", x => x.IsnSweetFactory);
                });

            migrationBuilder.CreateTable(
                name: "SweetTypes",
                columns: table => new
                {
                    IsnSweetType = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetTypes", x => x.IsnSweetType);
                });

            migrationBuilder.CreateTable(
                name: "Sweets",
                columns: table => new
                {
                    IsnSweet = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSweetType = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Ingredients = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sweets", x => x.IsnSweet);
                    table.ForeignKey(
                        name: "FK_Sweets_SweetTypes_IsnSweetType",
                        column: x => x.IsnSweetType,
                        principalTable: "SweetTypes",
                        principalColumn: "IsnSweetType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SweetProductions",
                columns: table => new
                {
                    IsnSweetProduction = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSweet = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSweetFactory = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetProductions", x => x.IsnSweetProduction);
                    table.ForeignKey(
                        name: "FK_SweetProductions_SweetFactories_IsnSweetFactory",
                        column: x => x.IsnSweetFactory,
                        principalTable: "SweetFactories",
                        principalColumn: "IsnSweetFactory",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SweetProductions_Sweets_IsnSweet",
                        column: x => x.IsnSweet,
                        principalTable: "Sweets",
                        principalColumn: "IsnSweet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SweetProductions_IsnSweet",
                table: "SweetProductions",
                column: "IsnSweet");

            migrationBuilder.CreateIndex(
                name: "IX_SweetProductions_IsnSweetFactory",
                table: "SweetProductions",
                column: "IsnSweetFactory");

            migrationBuilder.CreateIndex(
                name: "IX_Sweets_IsnSweetType",
                table: "Sweets",
                column: "IsnSweetType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SweetProductions");

            migrationBuilder.DropTable(
                name: "SweetFactories");

            migrationBuilder.DropTable(
                name: "Sweets");

            migrationBuilder.DropTable(
                name: "SweetTypes");
        }
    }
}
