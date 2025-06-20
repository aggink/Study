using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddPharmacy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PharmacyCustomers",
                columns: table => new
                {
                    IsnCustomer = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HasInsurance = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyCustomers", x => x.IsnCustomer);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyMedications",
                columns: table => new
                {
                    IsnMedication = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Manufacturer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    QuantityInStock = table.Column<int>(type: "integer", nullable: false),
                    RequiresPrescription = table.Column<bool>(type: "boolean", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyMedications", x => x.IsnMedication);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IsnPrescription = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnCustomer = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnMedication = table.Column<Guid>(type: "uuid", nullable: false),
                    PrescriptionNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DoctorName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Dosage = table.Column<int>(type: "integer", nullable: false),
                    Instructions = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IsnPrescription);
                    table.ForeignKey(
                        name: "FK_Prescriptions_PharmacyCustomers_IsnCustomer",
                        column: x => x.IsnCustomer,
                        principalTable: "PharmacyCustomers",
                        principalColumn: "IsnCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescriptions_PharmacyMedications_IsnMedication",
                        column: x => x.IsnMedication,
                        principalTable: "PharmacyMedications",
                        principalColumn: "IsnMedication",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IsnCustomer",
                table: "Prescriptions",
                column: "IsnCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IsnMedication",
                table: "Prescriptions",
                column: "IsnMedication");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "PharmacyCustomers");

            migrationBuilder.DropTable(
                name: "PharmacyMedications");
        }
    }
}
