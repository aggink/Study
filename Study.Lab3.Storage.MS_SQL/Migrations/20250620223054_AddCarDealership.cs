﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class AddCarDealership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarDealershipCustomers",
                columns: table => new
                {
                    IsnCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDealershipCustomers", x => x.IsnCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    IsnVehicle = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VinNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.IsnVehicle);
                });

            migrationBuilder.CreateTable(
                name: "CarDealershipSales",
                columns: table => new
                {
                    IsnSale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnVehicle = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    FinalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDealershipSales", x => x.IsnSale);
                    table.ForeignKey(
                        name: "FK_CarDealershipSales_CarDealershipCustomers_IsnCustomer",
                        column: x => x.IsnCustomer,
                        principalTable: "CarDealershipCustomers",
                        principalColumn: "IsnCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarDealershipSales_Vehicles_IsnVehicle",
                        column: x => x.IsnVehicle,
                        principalTable: "Vehicles",
                        principalColumn: "IsnVehicle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarDealershipSales_IsnCustomer",
                table: "CarDealershipSales",
                column: "IsnCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_CarDealershipSales_IsnVehicle",
                table: "CarDealershipSales",
                column: "IsnVehicle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDealershipSales");

            migrationBuilder.DropTable(
                name: "CarDealershipCustomers");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
