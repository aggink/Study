using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Restaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    IsnRestaurant = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    WorkingHours = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.IsnRestaurant);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    IsnMenu = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnRestaurant = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.IsnMenu);
                    table.ForeignKey(
                        name: "FK_Menus_Restaurants_IsnRestaurant",
                        column: x => x.IsnRestaurant,
                        principalTable: "Restaurants",
                        principalColumn: "IsnRestaurant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantOrders",
                columns: table => new
                {
                    IsnOrder = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnRestaurant = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CustomerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CustomerPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    TableNumber = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TotalAmount = table.Column<double>(type: "double precision", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantOrders", x => x.IsnOrder);
                    table.ForeignKey(
                        name: "FK_RestaurantOrders_Restaurants_IsnRestaurant",
                        column: x => x.IsnRestaurant,
                        principalTable: "Restaurants",
                        principalColumn: "IsnRestaurant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    IsnMenuItem = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnMenu = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    CookingTimeMinutes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.IsnMenuItem);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_IsnMenu",
                        column: x => x.IsnMenu,
                        principalTable: "Menus",
                        principalColumn: "IsnMenu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    IsnOrderItem = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnOrder = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnMenuItem = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: false),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false),
                    SpecialRequests = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.IsnOrderItem);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_IsnMenuItem",
                        column: x => x.IsnMenuItem,
                        principalTable: "MenuItems",
                        principalColumn: "IsnMenuItem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_RestaurantOrders_IsnOrder",
                        column: x => x.IsnOrder,
                        principalTable: "RestaurantOrders",
                        principalColumn: "IsnOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_IsnMenu",
                table: "MenuItems",
                column: "IsnMenu");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_IsnRestaurant",
                table: "Menus",
                column: "IsnRestaurant");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IsnMenuItem",
                table: "OrderItems",
                column: "IsnMenuItem");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IsnOrder",
                table: "OrderItems",
                column: "IsnOrder");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrders_IsnRestaurant",
                table: "RestaurantOrders",
                column: "IsnRestaurant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "RestaurantOrders");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
