using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Lab3.Storage.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TheKvn",
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
                    table.PrimaryKey("PK_TheKvn", x => x.IsnKvn);
                    table.ForeignKey(
                        name: "FK_TheKvn_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TheKvn_Subjects_IsnSubject",
                        column: x => x.IsnSubject,
                        principalTable: "Subjects",
                        principalColumn: "IsnSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TheProfcom",
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
                    table.PrimaryKey("PK_TheProfcom", x => x.IsnProfcom);
                    table.ForeignKey(
                        name: "FK_TheProfcom_Students_IsnStudent",
                        column: x => x.IsnStudent,
                        principalTable: "Students",
                        principalColumn: "IsnStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TheProfcom_Subjects_IsnSubject",
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

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_IsnCat",
                table: "Adoptions",
                column: "IsnCat");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_IsnCustomer",
                table: "Adoptions",
                column: "IsnCustomer");

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
                name: "IX_Career_IsnStudent",
                table: "Career",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Career_IsnSubject",
                table: "Career",
                column: "IsnSubject");

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
                name: "IX_Grades_IsnStudent",
                table: "Grades",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_IsnSubject",
                table: "Grades",
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
                name: "IX_RestaurantOrders_IsnRestaurant",
                table: "RestaurantOrders",
                column: "IsnRestaurant");

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
                name: "IX_TeacherSubjects_IsnSubject",
                table: "TeacherSubjects",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_IsnTeacher_IsnSubject",
                table: "TeacherSubjects",
                columns: new[] { "IsnTeacher", "IsnSubject" });

            migrationBuilder.CreateIndex(
                name: "IX_TheKvn_IsnStudent",
                table: "TheKvn",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_TheKvn_IsnSubject",
                table: "TheKvn",
                column: "IsnSubject");

            migrationBuilder.CreateIndex(
                name: "IX_TheProfcom_IsnStudent",
                table: "TheProfcom",
                column: "IsnStudent");

            migrationBuilder.CreateIndex(
                name: "IX_TheProfcom_IsnSubject",
                table: "TheProfcom",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoptions");

            migrationBuilder.DropTable(
                name: "AnnouncementGroups");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "BeautyAppointment");

            migrationBuilder.DropTable(
                name: "Career");

            migrationBuilder.DropTable(
                name: "ExamResults");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "Sportclub");

            migrationBuilder.DropTable(
                name: "SubjectsGroups");

            migrationBuilder.DropTable(
                name: "TeacherSubjects");

            migrationBuilder.DropTable(
                name: "TheKvn");

            migrationBuilder.DropTable(
                name: "TheProfcom");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Cats");

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
                name: "ExamRegistrations");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "RestaurantOrders");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Masters");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
