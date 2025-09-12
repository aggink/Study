using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Scientific : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baristas",
                columns: table => new
                {
                    IsnBarista = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Experience = table.Column<int>(type: "integer", nullable: false),
                    Specialization = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Salary = table.Column<double>(type: "double precision", nullable: true),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baristas", x => x.IsnBarista);
                });

            migrationBuilder.CreateTable(
                name: "BeautyClient",
                columns: table => new
                {
                    IsnClient = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    EmailAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeautyClient", x => x.IsnClient);
                });

            migrationBuilder.CreateTable(
                name: "BeautyService",
                columns: table => new
                {
                    IsnService = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeautyService", x => x.IsnService);
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
                name: "CarDealershipCustomers",
                columns: table => new
                {
                    IsnCustomer = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PassportNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDealershipCustomers", x => x.IsnCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    IsnCat = table.Column<Guid>(type: "uuid", nullable: false),
                    Nickname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Breed = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsVaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    IsSterilized = table.Column<bool>(type: "boolean", nullable: false),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    MedicalHistory = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PhotoUrl = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsAvailableForAdoption = table.Column<bool>(type: "boolean", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.IsnCat);
                });

            migrationBuilder.CreateTable(
                name: "Coffee",
                columns: table => new
                {
                    IsnCoffee = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    CaffeineContent = table.Column<int>(type: "integer", nullable: true),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffee", x => x.IsnCoffee);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeShops",
                columns: table => new
                {
                    IsnCoffeeShop = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    WorkingHours = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Rating = table.Column<double>(type: "double precision", nullable: true),
                    OpeningDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeShops", x => x.IsnCoffeeShop);
                });

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
                name: "Developers",
                columns: table => new
                {
                    IsnDeveloper = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FoundedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Website = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ContactEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.IsnDeveloper);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    FloorsCount = table.Column<int>(type: "integer", nullable: false),
                    TotalRooms = table.Column<int>(type: "integer", nullable: false),
                    BuildYear = table.Column<int>(type: "integer", nullable: false),
                    ManagerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ManagerPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryBuildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryResidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StudentId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    StudentGroup = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlannedCheckOutDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualCheckOutDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryResidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DormitoryRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    Area = table.Column<double>(type: "double precision", nullable: false),
                    MaxOccupants = table.Column<int>(type: "integer", nullable: false),
                    CurrentOccupants = table.Column<int>(type: "integer", nullable: false),
                    MonthlyRent = table.Column<decimal>(type: "numeric", nullable: false),
                    HasBalcony = table.Column<bool>(type: "boolean", nullable: false),
                    HasPrivateBathroom = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormitoryRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitnessEquipments",
                columns: table => new
                {
                    IsnEquipment = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Manufacturer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SerialNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    LastMaintenanceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessEquipments", x => x.IsnEquipment);
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
                name: "Groups",
                columns: table => new
                {
                    IsnGroup = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.IsnGroup);
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
                name: "Hotels",
                columns: table => new
                {
                    IsnHotel = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StarRating = table.Column<int>(type: "integer", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "numeric", nullable: false),
                    HasWiFi = table.Column<bool>(type: "boolean", nullable: false),
                    HasPool = table.Column<bool>(type: "boolean", nullable: false),
                    HasSpa = table.Column<bool>(type: "boolean", nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.IsnHotel);
                });

            migrationBuilder.CreateTable(
                name: "Labs",
                columns: table => new
                {
                    IsnLab = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labs", x => x.IsnLab);
                });

            migrationBuilder.CreateTable(
                name: "Manga",
                columns: table => new
                {
                    IsnBook = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PublicationYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga", x => x.IsnBook);
                });

            migrationBuilder.CreateTable(
                name: "Manhua",
                columns: table => new
                {
                    IsnBook = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PublicationYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manhua", x => x.IsnBook);
                });

            migrationBuilder.CreateTable(
                name: "Manhva",
                columns: table => new
                {
                    IsnBook = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PublicationYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manhva", x => x.IsnBook);
                });

            migrationBuilder.CreateTable(
                name: "Masters",
                columns: table => new
                {
                    IsnMaster = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Specialization = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masters", x => x.IsnMaster);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    IsnMember = table.Column<Guid>(type: "uuid", nullable: false),
                    SurName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PatronymicName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MembershipType = table.Column<int>(type: "integer", nullable: false),
                    MembershipStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MembershipEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.IsnMember);
                });

            migrationBuilder.CreateTable(
                name: "MiniPigs",
                columns: table => new
                {
                    IsnMiniPig = table.Column<Guid>(type: "uuid", nullable: false),
                    Nickname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Breed = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsVaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    IsSterilized = table.Column<bool>(type: "boolean", nullable: false),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    MedicalHistory = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PhotoUrl = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsAvailableForAdoption = table.Column<bool>(type: "boolean", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniPigs", x => x.IsnMiniPig);
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
                name: "MuseumExhibits",
                columns: table => new
                {
                    IsnMuseumExhibit = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AcquisitionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstimatedValue = table.Column<double>(type: "double precision", nullable: false),
                    Location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuseumExhibits", x => x.IsnMuseumExhibit);
                });

            migrationBuilder.CreateTable(
                name: "MuseumVisitors",
                columns: table => new
                {
                    IsnMuseumVisitor = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TicketType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TicketPrice = table.Column<double>(type: "double precision", nullable: false),
                    IsMember = table.Column<bool>(type: "boolean", nullable: false),
                    MembershipNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuseumVisitors", x => x.IsnMuseumVisitor);
                });

            migrationBuilder.CreateTable(
                name: "MusicAlbums",
                columns: table => new
                {
                    IsnAlbum = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Genre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ReleaseYear = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicAlbums", x => x.IsnAlbum);
                });

            migrationBuilder.CreateTable(
                name: "MusicArtists",
                columns: table => new
                {
                    IsnArtist = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthYear = table.Column<int>(type: "integer", nullable: true),
                    Genre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ArtistType = table.Column<int>(type: "integer", nullable: false),
                    Biography = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicArtists", x => x.IsnArtist);
                });

            migrationBuilder.CreateTable(
                name: "MusicCustomers",
                columns: table => new
                {
                    IsnCustomer = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PreferredGenre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicCustomers", x => x.IsnCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    IsnOwner = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.IsnOwner);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IsnPatient = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    MedicalCardId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IsnPatient);
                });

            migrationBuilder.CreateTable(
                name: "PetFoods",
                columns: table => new
                {
                    IsnPetFood = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    TargetSpecies = table.Column<int>(type: "integer", nullable: false),
                    WeightInGrams = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Ingredients = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetFoods", x => x.IsnPetFood);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    IsnPet = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Species = table.Column<int>(type: "integer", nullable: false),
                    Breed = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AgeInMonths = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.IsnPet);
                });

            migrationBuilder.CreateTable(
                name: "PetToys",
                columns: table => new
                {
                    IsnPetToy = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Material = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    TargetSpecies = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    AgeGroup = table.Column<int>(type: "integer", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false),
                    IsSafe = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetToys", x => x.IsnPetToy);
                });

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
                name: "PhotographyClients",
                columns: table => new
                {
                    IsnPhotographyClient = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographyClients", x => x.IsnPhotographyClient);
                });

            migrationBuilder.CreateTable(
                name: "PhotographyEquipments",
                columns: table => new
                {
                    IsnPhotographyEquipment = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SerialNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographyEquipments", x => x.IsnPhotographyEquipment);
                });

            migrationBuilder.CreateTable(
                name: "PhotographySessions",
                columns: table => new
                {
                    IsnPhotographySession = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SessionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    PhotographerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhotographySessionType = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PhotoCount = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographySessions", x => x.IsnPhotographySession);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    IsnPlatform = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Generation = table.Column<int>(type: "integer", nullable: true),
                    SupportsOnlineGaming = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.IsnPlatform);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IsnProduct = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IsnProduct);
                });

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
                name: "ServiceRecords",
                columns: table => new
                {
                    IsnServiceRecord = table.Column<Guid>(type: "uuid", nullable: false),
                    CarLicensePlate = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ServiceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ServiceType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    MechanicName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cost = table.Column<double>(type: "double precision", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecords", x => x.IsnServiceRecord);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    IsnService = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.IsnService);
                });

            migrationBuilder.CreateTable(
                name: "ShelterCustomers",
                columns: table => new
                {
                    IsnCustomer = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterCustomers", x => x.IsnCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.IsnSubject);
                });

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
                name: "Teachers",
                columns: table => new
                {
                    IsnTeacher = table.Column<Guid>(type: "uuid", nullable: false),
                    SurName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PatronymicName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.IsnTeacher);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    IsnTour = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaxParticipants = table.Column<int>(type: "integer", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.IsnTour);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    IsnTrainer = table.Column<Guid>(type: "uuid", nullable: false),
                    SurName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PatronymicName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Specialization = table.Column<int>(type: "integer", nullable: false),
                    ExperienceYears = table.Column<int>(type: "integer", nullable: false),
                    Certifications = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    HourlyRate = table.Column<decimal>(type: "numeric", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.IsnTrainer);
                });

            migrationBuilder.CreateTable(
                name: "TravelCustomers",
                columns: table => new
                {
                    IsnCustomer = table.Column<Guid>(type: "uuid", nullable: false),
                    SurName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PatronymicName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PassportNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsVip = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelCustomers", x => x.IsnCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    IsnVehicle = table.Column<Guid>(type: "uuid", nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    VinNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Mileage = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.IsnVehicle);
                });

            migrationBuilder.CreateTable(
                name: "BeautyAppointment",
                columns: table => new
                {
                    IsnAppointment = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnBeautyClient = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnBeautyService = table.Column<Guid>(type: "uuid", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    Hour = table.Column<int>(type: "integer", nullable: false),
                    Minutes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeautyAppointment", x => x.IsnAppointment);
                    table.ForeignKey(
                        name: "FK_BeautyAppointment_BeautyClient_IsnBeautyClient",
                        column: x => x.IsnBeautyClient,
                        principalTable: "BeautyClient",
                        principalColumn: "IsnClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeautyAppointment_BeautyService_IsnBeautyService",
                        column: x => x.IsnBeautyService,
                        principalTable: "BeautyService",
                        principalColumn: "IsnService",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    IsnGame = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnDeveloper = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Genre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AgeRating = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.IsnGame);
                    table.ForeignKey(
                        name: "FK_Games_Developers_IsnDeveloper",
                        column: x => x.IsnDeveloper,
                        principalTable: "Developers",
                        principalColumn: "IsnDeveloper");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnGroup = table.Column<Guid>(type: "uuid", nullable: false),
                    SurName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PatronymicName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IsnStudent);
                    table.ForeignKey(
                        name: "FK_Students_Groups_IsnGroup",
                        column: x => x.IsnGroup,
                        principalTable: "Groups",
                        principalColumn: "IsnGroup",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_IsnMovie",
                        column: x => x.IsnMovie,
                        principalTable: "Movies",
                        principalColumn: "IsnMovie",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Movies_IsnMovie",
                        column: x => x.IsnMovie,
                        principalTable: "Movies",
                        principalColumn: "IsnMovie",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MuseumExhibitDetails",
                columns: table => new
                {
                    IsnMuseumExhibitDetails = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnMuseumExhibit = table.Column<Guid>(type: "uuid", nullable: false),
                    Origin = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Creator = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreationYear = table.Column<int>(type: "integer", nullable: true),
                    Material = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Dimensions = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: true),
                    HistoricalPeriod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Condition = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuseumExhibitDetails", x => x.IsnMuseumExhibitDetails);
                    table.ForeignKey(
                        name: "FK_MuseumExhibitDetails_MuseumExhibits_IsnMuseumExhibit",
                        column: x => x.IsnMuseumExhibit,
                        principalTable: "MuseumExhibits",
                        principalColumn: "IsnMuseumExhibit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    IsnCar = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnOwner = table.Column<Guid>(type: "uuid", nullable: false),
                    Brand = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Mileage = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LicensePlate = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    VinNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.IsnCar);
                    table.ForeignKey(
                        name: "FK_Cars_Owners_IsnOwner",
                        column: x => x.IsnOwner,
                        principalTable: "Owners",
                        principalColumn: "IsnOwner",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IsnOrder = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnPatient = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnProduct = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IsnOrder);
                    table.ForeignKey(
                        name: "FK_Orders_Patients_IsnPatient",
                        column: x => x.IsnPatient,
                        principalTable: "Patients",
                        principalColumn: "IsnPatient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Products_IsnProduct",
                        column: x => x.IsnProduct,
                        principalTable: "Products",
                        principalColumn: "IsnProduct",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrders",
                columns: table => new
                {
                    IsnServiceOrder = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnMaster = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnService = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CustomerPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrders", x => x.IsnServiceOrder);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Masters_IsnMaster",
                        column: x => x.IsnMaster,
                        principalTable: "Masters",
                        principalColumn: "IsnMaster",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Services_IsnService",
                        column: x => x.IsnService,
                        principalTable: "Services",
                        principalColumn: "IsnService",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adoptions",
                columns: table => new
                {
                    IsnAdoption = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnCat = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnMiniPig = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnCustomer = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    AdoptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptions", x => x.IsnAdoption);
                    table.ForeignKey(
                        name: "FK_Adoptions_Cats_IsnCat",
                        column: x => x.IsnCat,
                        principalTable: "Cats",
                        principalColumn: "IsnCat",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adoptions_MiniPigs_IsnMiniPig",
                        column: x => x.IsnMiniPig,
                        principalTable: "MiniPigs",
                        principalColumn: "IsnMiniPig",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adoptions_ShelterCustomers_IsnCustomer",
                        column: x => x.IsnCustomer,
                        principalTable: "ShelterCustomers",
                        principalColumn: "IsnCustomer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    IsnAssignment = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MaxScore = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.IsnAssignment);
                    table.ForeignKey(
                        name: "FK_Assignments_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    IsnExam = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ExamDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    MaxScore = table.Column<int>(type: "integer", nullable: false),
                    PassingScore = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.IsnExam);
                    table.ForeignKey(
                        name: "FK_Exams_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    IsnMaterial = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.IsnMaterial);
                    table.ForeignKey(
                        name: "FK_Materials_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsGroups",
                columns: table => new
                {
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnGroup = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsGroups", x => new { x.IsnSubject, x.IsnGroup });
                    table.ForeignKey(
                        name: "FK_SubjectsGroups_Groups_IsnGroup",
                        column: x => x.IsnGroup,
                        principalTable: "Groups",
                        principalColumn: "IsnGroup",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectsGroups_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Announcements",
                columns: table => new
                {
                    IsnAnnouncement = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnTeacher = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsImportant = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.IsnAnnouncement);
                    table.ForeignKey(
                        name: "FK_Announcements_Teachers_IsnTeacher",
                        column: x => x.IsnTeacher,
                        principalTable: "Teachers",
                        principalColumn: "IsnTeacher",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "TeacherSubjects",
                columns: table => new
                {
                    IsnTeacher = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => new { x.IsnTeacher, x.IsnSubject });
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Teachers_IsnTeacher",
                        column: x => x.IsnTeacher,
                        principalTable: "Teachers",
                        principalColumn: "IsnTeacher",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarDealershipSales",
                columns: table => new
                {
                    IsnSale = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnCustomer = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnVehicle = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Discount = table.Column<double>(type: "double precision", nullable: false),
                    FinalPrice = table.Column<double>(type: "double precision", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Career",
                columns: table => new
                {
                    IsnCareer = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipantsCount = table.Column<int>(type: "integer", nullable: false),
                    CareerDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Career", x => x.IsnCareer);
                    table.ForeignKey(
                        name: "FK_Career_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Career_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    IsnGrade = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    GradeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.IsnGrade);
                    table.ForeignKey(
                        name: "FK_Grades_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kvns",
                columns: table => new
                {
                    IsnKvn = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipantsCount = table.Column<int>(type: "integer", nullable: false),
                    KvnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kvns", x => x.IsnKvn);
                    table.ForeignKey(
                        name: "FK_Kvns_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kvns_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pingpongclub",
                columns: table => new
                {
                    IsnPingpongclub = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipantsCount = table.Column<int>(type: "integer", nullable: false),
                    PingpongclubDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pingpongclub", x => x.IsnPingpongclub);
                    table.ForeignKey(
                        name: "FK_Pingpongclub_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pingpongclub_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profcoms",
                columns: table => new
                {
                    IsnProfcom = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipantsCount = table.Column<int>(type: "integer", nullable: false),
                    ProfcomDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profcoms", x => x.IsnProfcom);
                    table.ForeignKey(
                        name: "FK_Profcoms_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profcoms_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectActivities",
                columns: table => new
                {
                    IsnProjectActivities = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    PerformancesCount = table.Column<int>(type: "integer", nullable: false),
                    ProjectActivitiesDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectActivities", x => x.IsnProjectActivities);
                    table.ForeignKey(
                        name: "FK_ProjectActivities_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectActivities_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificWorks",
                columns: table => new
                {
                    IsnScientificWork = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PageCount = table.Column<int>(type: "integer", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificWorks", x => x.IsnScientificWork);
                    table.ForeignKey(
                        name: "FK_ScientificWorks_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScientificWorks_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sportclub_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentLab",
                columns: table => new
                {
                    IsnStudentLab = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnLab = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLab", x => x.IsnStudentLab);
                    table.ForeignKey(
                        name: "FK_StudentLab_Labs_IsnLab",
                        column: x => x.IsnLab,
                        principalTable: "Labs",
                        principalColumn: "IsnLab",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentLab_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentNotes",
                columns: table => new
                {
                    IsnNote = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNotes", x => x.IsnNote);
                    table.ForeignKey(
                        name: "FK_StudentNotes_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TheAttendanceLog",
                columns: table => new
                {
                    IsnAttendanceLog = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnSubject = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPresent = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheAttendanceLog", x => x.IsnAttendanceLog);
                    table.ForeignKey(
                        name: "FK_TheAttendanceLog_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TheAttendanceLog_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_IsnSeat",
                        column: x => x.IsnSeat,
                        principalTable: "Seats",
                        principalColumn: "IsnSeat",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Sessions_IsnSession",
                        column: x => x.IsnSession,
                        principalTable: "Sessions",
                        principalColumn: "IsnSession",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamRegistrations",
                columns: table => new
                {
                    IsnExamRegistration = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnExam = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnStudent = table.Column<Guid>(type: "uuid", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamRegistrations", x => x.IsnExamRegistration);
                    table.ForeignKey(
                        name: "FK_ExamRegistrations_Exams_IsnExam",
                        column: x => x.IsnExam,
                        principalTable: "Exams",
                        principalColumn: "IsnExam",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamRegistrations_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
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

            migrationBuilder.CreateTable(
                name: "AnnouncementGroups",
                columns: table => new
                {
                    IsnAnnouncement = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnGroup = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementGroups", x => new { x.IsnAnnouncement, x.IsnGroup });
                    table.ForeignKey(
                        name: "FK_AnnouncementGroups_Announcements_IsnAnnouncement",
                        column: x => x.IsnAnnouncement,
                        principalTable: "Announcements",
                        principalColumn: "IsnAnnouncement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnouncementGroups_Groups_IsnGroup",
                        column: x => x.IsnGroup,
                        principalTable: "Groups",
                        principalColumn: "IsnGroup",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Books_IsnBook",
                        column: x => x.IsnBook,
                        principalTable: "Books",
                        principalColumn: "IsnBook",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkReferences",
                columns: table => new
                {
                    IsnReference = table.Column<Guid>(type: "uuid", nullable: false),
                    ReferencedWorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceWorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReferenceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkReferences", x => x.IsnReference);
                    table.ForeignKey(
                        name: "FK_WorkReferences_ScientificWorks_ReferencedWorkId",
                        column: x => x.ReferencedWorkId,
                        principalTable: "ScientificWorks",
                        principalColumn: "IsnScientificWork",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkReferences_ScientificWorks_SourceWorkId",
                        column: x => x.SourceWorkId,
                        principalTable: "ScientificWorks",
                        principalColumn: "IsnScientificWork",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_RestaurantOrders_IsnOrder",
                        column: x => x.IsnOrder,
                        principalTable: "RestaurantOrders",
                        principalColumn: "IsnOrder",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamResults",
                columns: table => new
                {
                    IsnExamResult = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnExamRegistration = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    IsPassed = table.Column<bool>(type: "boolean", nullable: false),
                    Comments = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResults", x => x.IsnExamResult);
                    table.ForeignKey(
                        name: "FK_ExamResults_ExamRegistrations_IsnExamRegistration",
                        column: x => x.IsnExamRegistration,
                        principalTable: "ExamRegistrations",
                        principalColumn: "IsnExamRegistration",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageEmbeds",
                columns: table => new
                {
                    IsnImageEmbed = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnPost = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnImage = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEmbeds", x => x.IsnImageEmbed);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    IsnImage = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnUploader = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Data = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.IsnImage);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IsnUser = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnProfilePicture = table.Column<Guid>(type: "uuid", nullable: true),
                    Email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    Website = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AboutMe = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IsnUser);
                    table.ForeignKey(
                        name: "FK_Users_Images_IsnProfilePicture",
                        column: x => x.IsnProfilePicture,
                        principalTable: "Images",
                        principalColumn: "IsnImage");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    IsnPost = table.Column<Guid>(type: "uuid", nullable: false),
                    IsnUser = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.IsnPost);
                    table.ForeignKey(
                        name: "FK_Posts_Users_IsnUser",
                        column: x => x.IsnUser,
                        principalTable: "Users",
                        principalColumn: "IsnUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_IsnCat",
                table: "Adoptions",
                column: "IsnCat");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_IsnCustomer",
                table: "Adoptions",
                column: "IsnCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_IsnMiniPig",
                table: "Adoptions",
                column: "IsnMiniPig");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementGroups_IsnAnnouncement_IsnGroup",
                table: "AnnouncementGroups",
                columns: new[] { "IsnAnnouncement", "IsnGroup" });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementGroups_IsnGroup",
                table: "AnnouncementGroups",
                column: "IsnGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_IsnTeacher",
                table: "Announcements",
                column: "IsnTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_IsnSubject",
                table: "Assignments",
                column: "IsnSubject");

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

            migrationBuilder.CreateIndex(
                name: "IX_BeautyAppointment_IsnBeautyClient",
                table: "BeautyAppointment",
                column: "IsnBeautyClient");

            migrationBuilder.CreateIndex(
                name: "IX_BeautyAppointment_IsnBeautyService",
                table: "BeautyAppointment",
                column: "IsnBeautyService");

            migrationBuilder.CreateIndex(
                name: "IX_CarDealershipSales_IsnCustomer",
                table: "CarDealershipSales",
                column: "IsnCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_CarDealershipSales_IsnVehicle",
                table: "CarDealershipSales",
                column: "IsnVehicle");

            migrationBuilder.CreateIndex(
                name: "IX_Career_IsnStudent",
                table: "Career",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Career_IsnSubject",
                table: "Career",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IsnOwner",
                table: "Cars",
                column: "IsnOwner",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamRegistrations_IsnExam",
                table: "ExamRegistrations",
                column: "IsnExam");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRegistrations_IsnStudent",
                table: "ExamRegistrations",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_IsnExamRegistration",
                table: "ExamResults",
                column: "IsnExamRegistration",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_IsnSubject",
                table: "Exams",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Games_IsnDeveloper",
                table: "Games",
                column: "IsnDeveloper");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_IsnStudent",
                table: "Grades",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_IsnSubject",
                table: "Grades",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_ImageEmbeds_IsnImage",
                table: "ImageEmbeds",
                column: "IsnImage");

            migrationBuilder.CreateIndex(
                name: "IX_ImageEmbeds_IsnPost",
                table: "ImageEmbeds",
                column: "IsnPost");

            migrationBuilder.CreateIndex(
                name: "IX_Images_IsnUploader",
                table: "Images",
                column: "IsnUploader");

            migrationBuilder.CreateIndex(
                name: "IX_Kvns_IsnStudent",
                table: "Kvns",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Kvns_IsnSubject",
                table: "Kvns",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_IsnSubject",
                table: "Materials",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_IsnMenu",
                table: "MenuItems",
                column: "IsnMenu");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_IsnRestaurant",
                table: "Menus",
                column: "IsnRestaurant");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_IsnGenre",
                table: "MovieGenres",
                column: "IsnGenre");

            migrationBuilder.CreateIndex(
                name: "IX_MuseumExhibitDetails_IsnMuseumExhibit",
                table: "MuseumExhibitDetails",
                column: "IsnMuseumExhibit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IsnMenuItem",
                table: "OrderItems",
                column: "IsnMenuItem");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IsnOrder",
                table: "OrderItems",
                column: "IsnOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IsnPatient",
                table: "Orders",
                column: "IsnPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IsnProduct",
                table: "Orders",
                column: "IsnProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Pingpongclub_IsnStudent",
                table: "Pingpongclub",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Pingpongclub_IsnSubject",
                table: "Pingpongclub",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IsnUser",
                table: "Posts",
                column: "IsnUser");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IsnCustomer",
                table: "Prescriptions",
                column: "IsnCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IsnMedication",
                table: "Prescriptions",
                column: "IsnMedication");

            migrationBuilder.CreateIndex(
                name: "IX_Profcoms_IsnStudent",
                table: "Profcoms",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Profcoms_IsnSubject",
                table: "Profcoms",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectActivities_IsnStudent",
                table: "ProjectActivities",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectActivities_IsnSubject",
                table: "ProjectActivities",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrders_IsnRestaurant",
                table: "RestaurantOrders",
                column: "IsnRestaurant");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificWorks_IsnStudent",
                table: "ScientificWorks",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificWorks_IsnSubject",
                table: "ScientificWorks",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_IsnHall",
                table: "Seats",
                column: "IsnHall");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_IsnMaster",
                table: "ServiceOrders",
                column: "IsnMaster");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_IsnService",
                table: "ServiceOrders",
                column: "IsnService");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_IsnHall",
                table: "Sessions",
                column: "IsnHall");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_IsnMovie",
                table: "Sessions",
                column: "IsnMovie");

            migrationBuilder.CreateIndex(
                name: "IX_Sportclub_IsnStudent",
                table: "Sportclub",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Sportclub_IsnSubject",
                table: "Sportclub",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLab_IsnLab",
                table: "StudentLab",
                column: "IsnLab");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLab_IsnStudent",
                table: "StudentLab",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNotes_IsnStudent",
                table: "StudentNotes",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IsnGroup",
                table: "Students",
                column: "IsnGroup");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsGroups_IsnGroup",
                table: "SubjectsGroups",
                column: "IsnGroup");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsGroups_IsnSubject_IsnGroup",
                table: "SubjectsGroups",
                columns: new[] { "IsnSubject", "IsnGroup" });

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

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_IsnSubject",
                table: "TeacherSubjects",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_IsnTeacher_IsnSubject",
                table: "TeacherSubjects",
                columns: new[] { "IsnTeacher", "IsnSubject" });

            migrationBuilder.CreateIndex(
                name: "IX_TheAttendanceLog_IsnStudent",
                table: "TheAttendanceLog",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_TheAttendanceLog_IsnSubject",
                table: "TheAttendanceLog",
                column: "IsnSubject");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IsnProfilePicture",
                table: "Users",
                column: "IsnProfilePicture",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkReferences_ReferencedWorkId",
                table: "WorkReferences",
                column: "ReferencedWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkReferences_SourceWorkId",
                table: "WorkReferences",
                column: "SourceWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageEmbeds_Images_IsnImage",
                table: "ImageEmbeds",
                column: "IsnImage",
                principalTable: "Images",
                principalColumn: "IsnImage",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageEmbeds_Posts_IsnPost",
                table: "ImageEmbeds",
                column: "IsnPost",
                principalTable: "Posts",
                principalColumn: "IsnPost",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Users_IsnUploader",
                table: "Images",
                column: "IsnUploader",
                principalTable: "Users",
                principalColumn: "IsnUser",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Images_IsnProfilePicture",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Adoptions");

            migrationBuilder.DropTable(
                name: "AnnouncementGroups");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "Baristas");

            migrationBuilder.DropTable(
                name: "BeautyAppointment");

            migrationBuilder.DropTable(
                name: "CarDealershipSales");

            migrationBuilder.DropTable(
                name: "Career");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Coffee");

            migrationBuilder.DropTable(
                name: "CoffeeShops");

            migrationBuilder.DropTable(
                name: "DormitoryBuildings");

            migrationBuilder.DropTable(
                name: "DormitoryResidents");

            migrationBuilder.DropTable(
                name: "DormitoryRooms");

            migrationBuilder.DropTable(
                name: "ExamResults");

            migrationBuilder.DropTable(
                name: "FitnessEquipments");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "ImageEmbeds");

            migrationBuilder.DropTable(
                name: "Kvns");

            migrationBuilder.DropTable(
                name: "Manga");

            migrationBuilder.DropTable(
                name: "Manhua");

            migrationBuilder.DropTable(
                name: "Manhva");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "MuseumExhibitDetails");

            migrationBuilder.DropTable(
                name: "MuseumVisitors");

            migrationBuilder.DropTable(
                name: "MusicAlbums");

            migrationBuilder.DropTable(
                name: "MusicArtists");

            migrationBuilder.DropTable(
                name: "MusicCustomers");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PetFoods");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "PetToys");

            migrationBuilder.DropTable(
                name: "PhotographyClients");

            migrationBuilder.DropTable(
                name: "PhotographyEquipments");

            migrationBuilder.DropTable(
                name: "PhotographySessions");

            migrationBuilder.DropTable(
                name: "Pingpongclub");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Profcoms");

            migrationBuilder.DropTable(
                name: "ProjectActivities");

            migrationBuilder.DropTable(
                name: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "ServiceRecords");

            migrationBuilder.DropTable(
                name: "Sportclub");

            migrationBuilder.DropTable(
                name: "StudentLab");

            migrationBuilder.DropTable(
                name: "StudentNotes");

            migrationBuilder.DropTable(
                name: "SubjectsGroups");

            migrationBuilder.DropTable(
                name: "SweetProductions");

            migrationBuilder.DropTable(
                name: "TeacherSubjects");

            migrationBuilder.DropTable(
                name: "TheAttendanceLog");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "TravelCustomers");

            migrationBuilder.DropTable(
                name: "WorkReferences");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "MiniPigs");

            migrationBuilder.DropTable(
                name: "ShelterCustomers");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BeautyClient");

            migrationBuilder.DropTable(
                name: "BeautyService");

            migrationBuilder.DropTable(
                name: "CarDealershipCustomers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "ExamRegistrations");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MuseumExhibits");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "RestaurantOrders");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PharmacyCustomers");

            migrationBuilder.DropTable(
                name: "PharmacyMedications");

            migrationBuilder.DropTable(
                name: "Masters");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Labs");

            migrationBuilder.DropTable(
                name: "SweetFactories");

            migrationBuilder.DropTable(
                name: "Sweets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "ScientificWorks");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "SweetTypes");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
