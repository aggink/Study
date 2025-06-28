CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "BeautyClient" (
        "IsnClient" uuid NOT NULL,
        "FirstName" character varying(100) NOT NULL,
        "LastName" character varying(100) NOT NULL,
        "PhoneNumber" character varying(11) NOT NULL,
        "EmailAddress" character varying(100) NOT NULL,
        CONSTRAINT "PK_BeautyClient" PRIMARY KEY ("IsnClient")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "BeautyService" (
        "IsnService" uuid NOT NULL,
        "ServiceName" character varying(100) NOT NULL,
        "Description" character varying(2000) NOT NULL,
        "Price" integer NOT NULL,
        "Duration" integer NOT NULL,
        CONSTRAINT "PK_BeautyService" PRIMARY KEY ("IsnService")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Books" (
        "IsnBook" uuid NOT NULL,
        "Title" character varying(255) NOT NULL,
        "PublicationYear" integer NOT NULL,
        CONSTRAINT "PK_Books" PRIMARY KEY ("IsnBook")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Cats" (
        "IsnCat" uuid NOT NULL,
        "Nickname" character varying(100) NOT NULL,
        "BirthDate" timestamp with time zone NOT NULL,
        "Description" character varying(500),
        "Breed" character varying(100) NOT NULL,
        "IsVaccinated" boolean NOT NULL,
        "IsSterilized" boolean NOT NULL,
        "Color" character varying(20) NOT NULL,
        "MedicalHistory" character varying(1000) NOT NULL,
        "PhotoUrl" character varying(100) NOT NULL,
        "ArrivalDate" timestamp with time zone NOT NULL,
        "IsAvailableForAdoption" boolean NOT NULL,
        "Age" integer NOT NULL,
        "Weight" integer NOT NULL,
        CONSTRAINT "PK_Cats" PRIMARY KEY ("IsnCat")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Customers" (
        "IsnCustomer" uuid NOT NULL,
        "FirstName" character varying(100) NOT NULL,
        "LastName" character varying(100) NOT NULL,
        "Email" character varying(255) NOT NULL,
        "Phone" character varying(20),
        "BirthDate" timestamp with time zone,
        "RegistrationDate" timestamp with time zone NOT NULL,
        "IsActive" boolean NOT NULL,
        CONSTRAINT "PK_Customers" PRIMARY KEY ("IsnCustomer")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Developers" (
        "IsnDeveloper" uuid NOT NULL,
        "CompanyName" character varying(150) NOT NULL,
        "Country" character varying(100) NOT NULL,
        "FoundedDate" timestamp with time zone,
        "Website" character varying(200),
        "ContactEmail" character varying(100),
        "IsActive" boolean NOT NULL,
        "Description" character varying(500),
        CONSTRAINT "PK_Developers" PRIMARY KEY ("IsnDeveloper")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "FitnessEquipments" (
        "IsnEquipment" uuid NOT NULL,
        "Name" character varying(200) NOT NULL,
        "Manufacturer" character varying(100) NOT NULL,
        "Model" character varying(100) NOT NULL,
        "SerialNumber" character varying(50) NOT NULL,
        "Type" integer NOT NULL,
        "PurchaseDate" timestamp with time zone NOT NULL,
        "PurchasePrice" numeric NOT NULL,
        "Status" integer NOT NULL,
        "LastMaintenanceDate" timestamp with time zone,
        "Description" character varying(1000),
        CONSTRAINT "PK_FitnessEquipments" PRIMARY KEY ("IsnEquipment")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Genres" (
        "IsnGenre" uuid NOT NULL,
        "Name" character varying(50) NOT NULL,
        CONSTRAINT "PK_Genres" PRIMARY KEY ("IsnGenre")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Groups" (
        "IsnGroup" uuid NOT NULL,
        "Name" character varying(20) NOT NULL,
        CONSTRAINT "PK_Groups" PRIMARY KEY ("IsnGroup")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Halls" (
        "IsnHall" uuid NOT NULL,
        "Name" character varying(50) NOT NULL,
        "Type" integer NOT NULL,
        "Capacity" integer NOT NULL,
        "RowsCount" integer NOT NULL,
        "SeatsPerRow" integer NOT NULL,
        "IsActive" boolean NOT NULL,
        CONSTRAINT "PK_Halls" PRIMARY KEY ("IsnHall")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Hotels" (
        "IsnHotel" uuid NOT NULL,
        "Name" character varying(200) NOT NULL,
        "Description" character varying(2000),
        "Address" character varying(500) NOT NULL,
        "Country" character varying(100) NOT NULL,
        "City" character varying(100) NOT NULL,
        "StarRating" integer NOT NULL,
        "PricePerNight" numeric NOT NULL,
        "HasWiFi" boolean NOT NULL,
        "HasPool" boolean NOT NULL,
        "HasSpa" boolean NOT NULL,
        "Phone" character varying(20),
        "Email" character varying(100),
        CONSTRAINT "PK_Hotels" PRIMARY KEY ("IsnHotel")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Labs" (
        "IsnLab" uuid NOT NULL,
        "Name" character varying(20) NOT NULL,
        CONSTRAINT "PK_Labs" PRIMARY KEY ("IsnLab")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Masters" (
        "IsnMaster" uuid NOT NULL,
        "Name" character varying(100) NOT NULL,
        "Email" character varying(200) NOT NULL,
        "Phone" character varying(20) NOT NULL,
        "Specialization" character varying(200) NOT NULL,
        CONSTRAINT "PK_Masters" PRIMARY KEY ("IsnMaster")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Members" (
        "IsnMember" uuid NOT NULL,
        "SurName" character varying(100) NOT NULL,
        "Name" character varying(100) NOT NULL,
        "PatronymicName" character varying(100),
        "PhoneNumber" character varying(20) NOT NULL,
        "Email" character varying(255) NOT NULL,
        "DateOfBirth" timestamp with time zone NOT NULL,
        "MembershipType" integer NOT NULL,
        "MembershipStartDate" timestamp with time zone NOT NULL,
        "MembershipEndDate" timestamp with time zone NOT NULL,
        "IsActive" boolean NOT NULL,
        CONSTRAINT "PK_Members" PRIMARY KEY ("IsnMember")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "MiniPigs" (
        "IsnMiniPig" uuid NOT NULL,
        "Nickname" character varying(100) NOT NULL,
        "BirthDate" timestamp with time zone NOT NULL,
        "Description" character varying(500),
        "Breed" character varying(100) NOT NULL,
        "IsVaccinated" boolean NOT NULL,
        "IsSterilized" boolean NOT NULL,
        "Color" character varying(20) NOT NULL,
        "MedicalHistory" character varying(1000) NOT NULL,
        "PhotoUrl" character varying(100) NOT NULL,
        "ArrivalDate" timestamp with time zone NOT NULL,
        "IsAvailableForAdoption" boolean NOT NULL,
        "Age" integer NOT NULL,
        "Weight" integer NOT NULL,
        CONSTRAINT "PK_MiniPigs" PRIMARY KEY ("IsnMiniPig")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Movies" (
        "IsnMovie" uuid NOT NULL,
        "Title" character varying(200) NOT NULL,
        "Description" character varying(2000),
        "Duration" integer NOT NULL,
        "Rating" double precision NOT NULL,
        "Year" integer NOT NULL,
        "Country" character varying(100),
        "AgeRating" integer NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "IsActive" boolean NOT NULL,
        CONSTRAINT "PK_Movies" PRIMARY KEY ("IsnMovie")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Patients" (
        "IsnPatient" uuid NOT NULL,
        "FullName" character varying(200) NOT NULL,
        "MedicalCardId" character varying(50) NOT NULL,
        "Phone" character varying(20) NOT NULL,
        CONSTRAINT "PK_Patients" PRIMARY KEY ("IsnPatient")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Platforms" (
        "IsnPlatform" uuid NOT NULL,
        "Name" character varying(100) NOT NULL,
        "Manufacturer" character varying(100) NOT NULL,
        "Type" character varying(50) NOT NULL,
        "ReleaseDate" timestamp with time zone,
        "IsActive" boolean NOT NULL,
        "Description" character varying(500),
        "Generation" integer,
        "SupportsOnlineGaming" boolean NOT NULL,
        CONSTRAINT "PK_Platforms" PRIMARY KEY ("IsnPlatform")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Products" (
        "IsnProduct" uuid NOT NULL,
        "Name" character varying(100) NOT NULL,
        "Category" character varying(50) NOT NULL,
        "Price" integer NOT NULL,
        CONSTRAINT "PK_Products" PRIMARY KEY ("IsnProduct")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Restaurants" (
        "IsnRestaurant" uuid NOT NULL,
        "Name" character varying(200) NOT NULL,
        "Address" character varying(500) NOT NULL,
        "Phone" character varying(20),
        "Email" character varying(100),
        "WorkingHours" character varying(100),
        "CreatedDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_Restaurants" PRIMARY KEY ("IsnRestaurant")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Services" (
        "IsnService" uuid NOT NULL,
        "Name" character varying(200) NOT NULL,
        "Description" character varying(1000),
        "Price" double precision NOT NULL,
        "Duration" integer NOT NULL,
        CONSTRAINT "PK_Services" PRIMARY KEY ("IsnService")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "ShelterCustomers" (
        "IsnCustomer" uuid NOT NULL,
        "Name" character varying(100) NOT NULL,
        "LastName" character varying(100) NOT NULL,
        "Description" character varying(500),
        "Address" character varying(100) NOT NULL,
        "PhoneNumber" character varying(15) NOT NULL,
        "Email" character varying(255) NOT NULL,
        CONSTRAINT "PK_ShelterCustomers" PRIMARY KEY ("IsnCustomer")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Subjects" (
        "IsnSubject" uuid NOT NULL,
        "Name" character varying(255) NOT NULL,
        CONSTRAINT "PK_Subjects" PRIMARY KEY ("IsnSubject")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "SweetFactories" (
        "IsnSweetFactory" uuid NOT NULL,
        "Name" character varying(256) NOT NULL,
        "Address" character varying(256) NOT NULL,
        "Volume" bigint NOT NULL,
        CONSTRAINT "PK_SweetFactories" PRIMARY KEY ("IsnSweetFactory")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "SweetTypes" (
        "IsnSweetType" uuid NOT NULL,
        "Name" character varying(256) NOT NULL,
        CONSTRAINT "PK_SweetTypes" PRIMARY KEY ("IsnSweetType")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Teachers" (
        "IsnTeacher" uuid NOT NULL,
        "SurName" character varying(100) NOT NULL,
        "Name" character varying(100) NOT NULL,
        "PatronymicName" character varying(100) NOT NULL,
        "Sex" integer NOT NULL,
        CONSTRAINT "PK_Teachers" PRIMARY KEY ("IsnTeacher")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Tours" (
        "IsnTour" uuid NOT NULL,
        "Name" character varying(200) NOT NULL,
        "Description" character varying(2000),
        "Country" character varying(100) NOT NULL,
        "City" character varying(100) NOT NULL,
        "Price" numeric NOT NULL,
        "Duration" integer NOT NULL,
        "StartDate" timestamp with time zone NOT NULL,
        "EndDate" timestamp with time zone NOT NULL,
        "MaxParticipants" integer NOT NULL,
        "IsAvailable" boolean NOT NULL,
        CONSTRAINT "PK_Tours" PRIMARY KEY ("IsnTour")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Trainers" (
        "IsnTrainer" uuid NOT NULL,
        "SurName" character varying(100) NOT NULL,
        "Name" character varying(100) NOT NULL,
        "PatronymicName" character varying(100),
        "PhoneNumber" character varying(20) NOT NULL,
        "Email" character varying(255) NOT NULL,
        "Specialization" integer NOT NULL,
        "ExperienceYears" integer NOT NULL,
        "Certifications" character varying(1000),
        "HourlyRate" numeric NOT NULL,
        "IsActive" boolean NOT NULL,
        CONSTRAINT "PK_Trainers" PRIMARY KEY ("IsnTrainer")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "TravelCustomers" (
        "IsnCustomer" uuid NOT NULL,
        "SurName" character varying(100) NOT NULL,
        "Name" character varying(100) NOT NULL,
        "PatronymicName" character varying(100),
        "DateOfBirth" timestamp with time zone NOT NULL,
        "PassportNumber" character varying(20) NOT NULL,
        "Phone" character varying(20) NOT NULL,
        "Email" character varying(100) NOT NULL,
        "Address" character varying(500),
        "RegistrationDate" timestamp with time zone NOT NULL,
        "IsVip" boolean NOT NULL,
        CONSTRAINT "PK_TravelCustomers" PRIMARY KEY ("IsnCustomer")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "BeautyAppointment" (
        "IsnAppointment" uuid NOT NULL,
        "IsnBeautyClient" uuid NOT NULL,
        "IsnBeautyService" uuid NOT NULL,
        "Day" integer NOT NULL,
        "Month" integer NOT NULL,
        "Hour" integer NOT NULL,
        "Minutes" integer NOT NULL,
        CONSTRAINT "PK_BeautyAppointment" PRIMARY KEY ("IsnAppointment"),
        CONSTRAINT "FK_BeautyAppointment_BeautyClient_IsnBeautyClient" FOREIGN KEY ("IsnBeautyClient") REFERENCES "BeautyClient" ("IsnClient") ON DELETE RESTRICT,
        CONSTRAINT "FK_BeautyAppointment_BeautyService_IsnBeautyService" FOREIGN KEY ("IsnBeautyService") REFERENCES "BeautyService" ("IsnService") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Games" (
        "IsnGame" uuid NOT NULL,
        "IsnDeveloper" uuid,
        "Title" character varying(200) NOT NULL,
        "Description" character varying(1000),
        "Price" double precision NOT NULL,
        "ReleaseDate" timestamp with time zone NOT NULL,
        "Genre" character varying(100) NOT NULL,
        "AgeRating" character varying(10) NOT NULL,
        "IsActive" boolean NOT NULL,
        CONSTRAINT "PK_Games" PRIMARY KEY ("IsnGame"),
        CONSTRAINT "FK_Games_Developers_IsnDeveloper" FOREIGN KEY ("IsnDeveloper") REFERENCES "Developers" ("IsnDeveloper")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Students" (
        "IsnStudent" uuid NOT NULL,
        "IsnGroup" uuid NOT NULL,
        "SurName" character varying(100) NOT NULL,
        "Name" character varying(100) NOT NULL,
        "PatronymicName" character varying(100) NOT NULL,
        "Sex" integer NOT NULL,
        "Age" integer NOT NULL,
        CONSTRAINT "PK_Students" PRIMARY KEY ("IsnStudent"),
        CONSTRAINT "FK_Students_Groups_IsnGroup" FOREIGN KEY ("IsnGroup") REFERENCES "Groups" ("IsnGroup") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Seats" (
        "IsnSeat" uuid NOT NULL,
        "IsnHall" uuid NOT NULL,
        "Row" integer NOT NULL,
        "Number" integer NOT NULL,
        "Type" integer NOT NULL,
        "IsActive" boolean NOT NULL,
        CONSTRAINT "PK_Seats" PRIMARY KEY ("IsnSeat"),
        CONSTRAINT "FK_Seats_Halls_IsnHall" FOREIGN KEY ("IsnHall") REFERENCES "Halls" ("IsnHall") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "MovieGenres" (
        "IsnMovie" uuid NOT NULL,
        "IsnGenre" uuid NOT NULL,
        CONSTRAINT "PK_MovieGenres" PRIMARY KEY ("IsnMovie", "IsnGenre"),
        CONSTRAINT "FK_MovieGenres_Genres_IsnGenre" FOREIGN KEY ("IsnGenre") REFERENCES "Genres" ("IsnGenre") ON DELETE RESTRICT,
        CONSTRAINT "FK_MovieGenres_Movies_IsnMovie" FOREIGN KEY ("IsnMovie") REFERENCES "Movies" ("IsnMovie") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Sessions" (
        "IsnSession" uuid NOT NULL,
        "IsnMovie" uuid NOT NULL,
        "IsnHall" uuid NOT NULL,
        "StartTime" timestamp with time zone NOT NULL,
        "EndTime" timestamp with time zone NOT NULL,
        "BasePrice" numeric NOT NULL,
        "IsActive" boolean NOT NULL,
        CONSTRAINT "PK_Sessions" PRIMARY KEY ("IsnSession"),
        CONSTRAINT "FK_Sessions_Halls_IsnHall" FOREIGN KEY ("IsnHall") REFERENCES "Halls" ("IsnHall") ON DELETE RESTRICT,
        CONSTRAINT "FK_Sessions_Movies_IsnMovie" FOREIGN KEY ("IsnMovie") REFERENCES "Movies" ("IsnMovie") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Orders" (
        "IsnOrder" uuid NOT NULL,
        "IsnPatient" uuid NOT NULL,
        "IsnProduct" uuid NOT NULL,
        "Quantity" integer NOT NULL,
        CONSTRAINT "PK_Orders" PRIMARY KEY ("IsnOrder"),
        CONSTRAINT "FK_Orders_Patients_IsnPatient" FOREIGN KEY ("IsnPatient") REFERENCES "Patients" ("IsnPatient") ON DELETE RESTRICT,
        CONSTRAINT "FK_Orders_Products_IsnProduct" FOREIGN KEY ("IsnProduct") REFERENCES "Products" ("IsnProduct") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Menus" (
        "IsnMenu" uuid NOT NULL,
        "IsnRestaurant" uuid NOT NULL,
        "Name" character varying(100) NOT NULL,
        "Description" character varying(500),
        "IsActive" boolean NOT NULL,
        "CreatedDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_Menus" PRIMARY KEY ("IsnMenu"),
        CONSTRAINT "FK_Menus_Restaurants_IsnRestaurant" FOREIGN KEY ("IsnRestaurant") REFERENCES "Restaurants" ("IsnRestaurant") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "RestaurantOrders" (
        "IsnOrder" uuid NOT NULL,
        "IsnRestaurant" uuid NOT NULL,
        "OrderNumber" character varying(20) NOT NULL,
        "CustomerName" character varying(100) NOT NULL,
        "CustomerPhone" character varying(20),
        "TableNumber" integer,
        "Status" character varying(20) NOT NULL,
        "TotalAmount" double precision NOT NULL,
        "CreatedDate" timestamp with time zone NOT NULL,
        "CompletedDate" timestamp with time zone,
        CONSTRAINT "PK_RestaurantOrders" PRIMARY KEY ("IsnOrder"),
        CONSTRAINT "FK_RestaurantOrders_Restaurants_IsnRestaurant" FOREIGN KEY ("IsnRestaurant") REFERENCES "Restaurants" ("IsnRestaurant") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "ServiceOrders" (
        "IsnServiceOrder" uuid NOT NULL,
        "IsnMaster" uuid NOT NULL,
        "IsnService" uuid NOT NULL,
        "CustomerName" character varying(100) NOT NULL,
        "CustomerPhone" character varying(20) NOT NULL,
        "OrderDate" timestamp with time zone NOT NULL,
        "Status" integer NOT NULL,
        "Description" character varying(1000),
        "TotalPrice" double precision,
        CONSTRAINT "PK_ServiceOrders" PRIMARY KEY ("IsnServiceOrder"),
        CONSTRAINT "FK_ServiceOrders_Masters_IsnMaster" FOREIGN KEY ("IsnMaster") REFERENCES "Masters" ("IsnMaster") ON DELETE RESTRICT,
        CONSTRAINT "FK_ServiceOrders_Services_IsnService" FOREIGN KEY ("IsnService") REFERENCES "Services" ("IsnService") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Adoptions" (
        "IsnAdoption" uuid NOT NULL,
        "IsnCat" uuid NOT NULL,
        "IsnMiniPig" uuid NOT NULL,
        "IsnCustomer" uuid NOT NULL,
        "Price" integer NOT NULL,
        "AdoptionDate" timestamp with time zone NOT NULL,
        "Status" character varying(50) NOT NULL,
        CONSTRAINT "PK_Adoptions" PRIMARY KEY ("IsnAdoption"),
        CONSTRAINT "FK_Adoptions_Cats_IsnCat" FOREIGN KEY ("IsnCat") REFERENCES "Cats" ("IsnCat") ON DELETE RESTRICT,
        CONSTRAINT "FK_Adoptions_MiniPigs_IsnMiniPig" FOREIGN KEY ("IsnMiniPig") REFERENCES "MiniPigs" ("IsnMiniPig") ON DELETE RESTRICT,
        CONSTRAINT "FK_Adoptions_ShelterCustomers_IsnCustomer" FOREIGN KEY ("IsnCustomer") REFERENCES "ShelterCustomers" ("IsnCustomer") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Assignments" (
        "IsnAssignment" uuid NOT NULL,
        "IsnSubject" uuid NOT NULL,
        "Title" character varying(200) NOT NULL,
        "Description" character varying(2000) NOT NULL,
        "PublishDate" timestamp with time zone NOT NULL,
        "Deadline" timestamp with time zone,
        "MaxScore" integer NOT NULL,
        CONSTRAINT "PK_Assignments" PRIMARY KEY ("IsnAssignment"),
        CONSTRAINT "FK_Assignments_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Exams" (
        "IsnExam" uuid NOT NULL,
        "IsnSubject" uuid NOT NULL,
        "Name" character varying(100) NOT NULL,
        "Description" character varying(500),
        "ExamDate" timestamp with time zone NOT NULL,
        "Duration" integer NOT NULL,
        "MaxScore" integer NOT NULL,
        "PassingScore" integer NOT NULL,
        CONSTRAINT "PK_Exams" PRIMARY KEY ("IsnExam"),
        CONSTRAINT "FK_Exams_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Materials" (
        "IsnMaterial" uuid NOT NULL,
        "IsnSubject" uuid NOT NULL,
        "Title" character varying(200) NOT NULL,
        "Description" character varying(2000),
        "Type" character varying(50) NOT NULL,
        "Url" text NOT NULL,
        "PublishDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_Materials" PRIMARY KEY ("IsnMaterial"),
        CONSTRAINT "FK_Materials_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "SubjectsGroups" (
        "IsnSubject" uuid NOT NULL,
        "IsnGroup" uuid NOT NULL,
        CONSTRAINT "PK_SubjectsGroups" PRIMARY KEY ("IsnSubject", "IsnGroup"),
        CONSTRAINT "FK_SubjectsGroups_Groups_IsnGroup" FOREIGN KEY ("IsnGroup") REFERENCES "Groups" ("IsnGroup") ON DELETE RESTRICT,
        CONSTRAINT "FK_SubjectsGroups_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Sweets" (
        "IsnSweet" uuid NOT NULL,
        "IsnSweetType" uuid NOT NULL,
        "Name" character varying(256) NOT NULL,
        "Ingredients" character varying(256) NOT NULL,
        CONSTRAINT "PK_Sweets" PRIMARY KEY ("IsnSweet"),
        CONSTRAINT "FK_Sweets_SweetTypes_IsnSweetType" FOREIGN KEY ("IsnSweetType") REFERENCES "SweetTypes" ("IsnSweetType") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Announcements" (
        "IsnAnnouncement" uuid NOT NULL,
        "IsnTeacher" uuid NOT NULL,
        "Title" character varying(200) NOT NULL,
        "Content" character varying(2000) NOT NULL,
        "PublishDate" timestamp with time zone NOT NULL,
        "IsImportant" boolean NOT NULL,
        CONSTRAINT "PK_Announcements" PRIMARY KEY ("IsnAnnouncement"),
        CONSTRAINT "FK_Announcements_Teachers_IsnTeacher" FOREIGN KEY ("IsnTeacher") REFERENCES "Teachers" ("IsnTeacher") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Authors" (
        "IsnAuthor" uuid NOT NULL,
        "SurName" character varying(100) NOT NULL,
        "Name" character varying(100) NOT NULL,
        "PatronymicName" character varying(100) NOT NULL,
        "Sex" integer NOT NULL,
        "IsnTeacher" uuid,
        CONSTRAINT "PK_Authors" PRIMARY KEY ("IsnAuthor"),
        CONSTRAINT "FK_Authors_Teachers_IsnTeacher" FOREIGN KEY ("IsnTeacher") REFERENCES "Teachers" ("IsnTeacher")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "TeacherSubjects" (
        "IsnTeacher" uuid NOT NULL,
        "IsnSubject" uuid NOT NULL,
        CONSTRAINT "PK_TeacherSubjects" PRIMARY KEY ("IsnTeacher", "IsnSubject"),
        CONSTRAINT "FK_TeacherSubjects_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT,
        CONSTRAINT "FK_TeacherSubjects_Teachers_IsnTeacher" FOREIGN KEY ("IsnTeacher") REFERENCES "Teachers" ("IsnTeacher") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Career" (
        "IsnCareer" uuid NOT NULL,
        "IsnStudent" uuid NOT NULL,
        "IsnSubject" uuid NOT NULL,
        "ParticipantsCount" integer NOT NULL,
        "CareerDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_Career" PRIMARY KEY ("IsnCareer"),
        CONSTRAINT "FK_Career_Students_IsnStudent" FOREIGN KEY ("IsnStudent") REFERENCES "Students" ("IsnStudent") ON DELETE RESTRICT,
        CONSTRAINT "FK_Career_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Grades" (
        "IsnGrade" uuid NOT NULL,
        "IsnStudent" uuid NOT NULL,
        "IsnSubject" uuid NOT NULL,
        "Value" integer NOT NULL,
        "GradeDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_Grades" PRIMARY KEY ("IsnGrade"),
        CONSTRAINT "FK_Grades_Students_IsnStudent" FOREIGN KEY ("IsnStudent") REFERENCES "Students" ("IsnStudent") ON DELETE RESTRICT,
        CONSTRAINT "FK_Grades_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Kvns" (
        "IsnKvn" uuid NOT NULL,
        "IsnStudent" uuid NOT NULL,
        "IsnSubject" uuid NOT NULL,
        "ParticipantsCount" integer NOT NULL,
        "KvnDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_Kvns" PRIMARY KEY ("IsnKvn"),
        CONSTRAINT "FK_Kvns_Students_IsnStudent" FOREIGN KEY ("IsnStudent") REFERENCES "Students" ("IsnStudent") ON DELETE RESTRICT,
        CONSTRAINT "FK_Kvns_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Pingpongclub" (
        "IsnPingpongclub" uuid NOT NULL,
        "IsnStudent" uuid NOT NULL,
        "IsnSubject" uuid NOT NULL,
        "ParticipantsCount" integer NOT NULL,
        "PingpongclubDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_Pingpongclub" PRIMARY KEY ("IsnPingpongclub"),
        CONSTRAINT "FK_Pingpongclub_Students_IsnStudent" FOREIGN KEY ("IsnStudent") REFERENCES "Students" ("IsnStudent") ON DELETE RESTRICT,
        CONSTRAINT "FK_Pingpongclub_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Profcoms" (
        "IsnProfcom" uuid NOT NULL,
        "IsnStudent" uuid NOT NULL,
        "IsnSubject" uuid NOT NULL,
        "ParticipantsCount" integer NOT NULL,
        "ProfcomDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_Profcoms" PRIMARY KEY ("IsnProfcom"),
        CONSTRAINT "FK_Profcoms_Students_IsnStudent" FOREIGN KEY ("IsnStudent") REFERENCES "Students" ("IsnStudent") ON DELETE RESTRICT,
        CONSTRAINT "FK_Profcoms_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "ProjectActivities" (
        "IsnProjectActivities" uuid NOT NULL,
        "IsnStudent" uuid NOT NULL,
        "IsnSubject" uuid NOT NULL,
        "PerformancesCount" integer NOT NULL,
        "ProjectActivitiesDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_ProjectActivities" PRIMARY KEY ("IsnProjectActivities"),
        CONSTRAINT "FK_ProjectActivities_Students_IsnStudent" FOREIGN KEY ("IsnStudent") REFERENCES "Students" ("IsnStudent") ON DELETE RESTRICT,
        CONSTRAINT "FK_ProjectActivities_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Sportclub" (
        "IsnSportclub" uuid NOT NULL,
        "IsnStudent" uuid NOT NULL,
        "IsnSubject" uuid NOT NULL,
        "ParticipantsCount" integer NOT NULL,
        "SportclubDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_Sportclub" PRIMARY KEY ("IsnSportclub"),
        CONSTRAINT "FK_Sportclub_Students_IsnStudent" FOREIGN KEY ("IsnStudent") REFERENCES "Students" ("IsnStudent") ON DELETE RESTRICT,
        CONSTRAINT "FK_Sportclub_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "StudentLab" (
        "IsnStudentLab" uuid NOT NULL,
        "IsnStudent" uuid NOT NULL,
        "IsnLab" uuid NOT NULL,
        "Value" integer NOT NULL,
        CONSTRAINT "PK_StudentLab" PRIMARY KEY ("IsnStudentLab"),
        CONSTRAINT "FK_StudentLab_Labs_IsnLab" FOREIGN KEY ("IsnLab") REFERENCES "Labs" ("IsnLab") ON DELETE RESTRICT,
        CONSTRAINT "FK_StudentLab_Students_IsnStudent" FOREIGN KEY ("IsnStudent") REFERENCES "Students" ("IsnStudent") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "StudentNotes" (
        "IsnNote" uuid NOT NULL,
        "IsnStudent" uuid NOT NULL,
        "Text" character varying(500) NOT NULL,
        CONSTRAINT "PK_StudentNotes" PRIMARY KEY ("IsnNote"),
        CONSTRAINT "FK_StudentNotes_Students_IsnStudent" FOREIGN KEY ("IsnStudent") REFERENCES "Students" ("IsnStudent") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "TheAttendanceLog" (
        "IsnAttendanceLog" uuid NOT NULL,
        "IsnStudent" uuid NOT NULL,
        "IsnSubject" uuid NOT NULL,
        "SubjectDate" timestamp with time zone NOT NULL,
        "IsPresent" integer NOT NULL,
        CONSTRAINT "PK_TheAttendanceLog" PRIMARY KEY ("IsnAttendanceLog"),
        CONSTRAINT "FK_TheAttendanceLog_Students_IsnStudent" FOREIGN KEY ("IsnStudent") REFERENCES "Students" ("IsnStudent") ON DELETE RESTRICT,
        CONSTRAINT "FK_TheAttendanceLog_Subjects_IsnSubject" FOREIGN KEY ("IsnSubject") REFERENCES "Subjects" ("IsnSubject") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Tickets" (
        "IsnTicket" uuid NOT NULL,
        "IsnSession" uuid NOT NULL,
        "IsnSeat" uuid NOT NULL,
        "IsnCustomer" uuid NOT NULL,
        "Price" numeric NOT NULL,
        "PurchaseDate" timestamp with time zone NOT NULL,
        "Status" integer NOT NULL,
        "TicketCode" character varying(50),
        CONSTRAINT "PK_Tickets" PRIMARY KEY ("IsnTicket"),
        CONSTRAINT "FK_Tickets_Customers_IsnCustomer" FOREIGN KEY ("IsnCustomer") REFERENCES "Customers" ("IsnCustomer") ON DELETE RESTRICT,
        CONSTRAINT "FK_Tickets_Seats_IsnSeat" FOREIGN KEY ("IsnSeat") REFERENCES "Seats" ("IsnSeat") ON DELETE RESTRICT,
        CONSTRAINT "FK_Tickets_Sessions_IsnSession" FOREIGN KEY ("IsnSession") REFERENCES "Sessions" ("IsnSession") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "MenuItems" (
        "IsnMenuItem" uuid NOT NULL,
        "IsnMenu" uuid NOT NULL,
        "Name" character varying(200) NOT NULL,
        "Description" character varying(1000),
        "Category" character varying(50) NOT NULL,
        "Price" double precision NOT NULL,
        "IsAvailable" boolean NOT NULL,
        "CookingTimeMinutes" integer NOT NULL,
        CONSTRAINT "PK_MenuItems" PRIMARY KEY ("IsnMenuItem"),
        CONSTRAINT "FK_MenuItems_Menus_IsnMenu" FOREIGN KEY ("IsnMenu") REFERENCES "Menus" ("IsnMenu") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "ExamRegistrations" (
        "IsnExamRegistration" uuid NOT NULL,
        "IsnExam" uuid NOT NULL,
        "IsnStudent" uuid NOT NULL,
        "RegistrationDate" timestamp with time zone NOT NULL,
        "Status" integer NOT NULL,
        CONSTRAINT "PK_ExamRegistrations" PRIMARY KEY ("IsnExamRegistration"),
        CONSTRAINT "FK_ExamRegistrations_Exams_IsnExam" FOREIGN KEY ("IsnExam") REFERENCES "Exams" ("IsnExam") ON DELETE RESTRICT,
        CONSTRAINT "FK_ExamRegistrations_Students_IsnStudent" FOREIGN KEY ("IsnStudent") REFERENCES "Students" ("IsnStudent") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "SweetProductions" (
        "IsnSweetProduction" uuid NOT NULL,
        "IsnSweet" uuid NOT NULL,
        "IsnSweetFactory" uuid NOT NULL,
        CONSTRAINT "PK_SweetProductions" PRIMARY KEY ("IsnSweetProduction"),
        CONSTRAINT "FK_SweetProductions_SweetFactories_IsnSweetFactory" FOREIGN KEY ("IsnSweetFactory") REFERENCES "SweetFactories" ("IsnSweetFactory") ON DELETE RESTRICT,
        CONSTRAINT "FK_SweetProductions_Sweets_IsnSweet" FOREIGN KEY ("IsnSweet") REFERENCES "Sweets" ("IsnSweet") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "AnnouncementGroups" (
        "IsnAnnouncement" uuid NOT NULL,
        "IsnGroup" uuid NOT NULL,
        CONSTRAINT "PK_AnnouncementGroups" PRIMARY KEY ("IsnAnnouncement", "IsnGroup"),
        CONSTRAINT "FK_AnnouncementGroups_Announcements_IsnAnnouncement" FOREIGN KEY ("IsnAnnouncement") REFERENCES "Announcements" ("IsnAnnouncement") ON DELETE RESTRICT,
        CONSTRAINT "FK_AnnouncementGroups_Groups_IsnGroup" FOREIGN KEY ("IsnGroup") REFERENCES "Groups" ("IsnGroup") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "AuthorBooks" (
        "IsnAuthor" uuid NOT NULL,
        "IsnBook" uuid NOT NULL,
        CONSTRAINT "PK_AuthorBooks" PRIMARY KEY ("IsnAuthor", "IsnBook"),
        CONSTRAINT "FK_AuthorBooks_Authors_IsnAuthor" FOREIGN KEY ("IsnAuthor") REFERENCES "Authors" ("IsnAuthor") ON DELETE RESTRICT,
        CONSTRAINT "FK_AuthorBooks_Books_IsnBook" FOREIGN KEY ("IsnBook") REFERENCES "Books" ("IsnBook") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "OrderItems" (
        "IsnOrderItem" uuid NOT NULL,
        "IsnOrder" uuid NOT NULL,
        "IsnMenuItem" uuid NOT NULL,
        "Quantity" integer NOT NULL,
        "UnitPrice" double precision NOT NULL,
        "TotalPrice" double precision NOT NULL,
        "SpecialRequests" character varying(500),
        CONSTRAINT "PK_OrderItems" PRIMARY KEY ("IsnOrderItem"),
        CONSTRAINT "FK_OrderItems_MenuItems_IsnMenuItem" FOREIGN KEY ("IsnMenuItem") REFERENCES "MenuItems" ("IsnMenuItem") ON DELETE RESTRICT,
        CONSTRAINT "FK_OrderItems_RestaurantOrders_IsnOrder" FOREIGN KEY ("IsnOrder") REFERENCES "RestaurantOrders" ("IsnOrder") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "ExamResults" (
        "IsnExamResult" uuid NOT NULL,
        "IsnExamRegistration" uuid NOT NULL,
        "Score" integer NOT NULL,
        "IsPassed" boolean NOT NULL,
        "Comments" character varying(500),
        CONSTRAINT "PK_ExamResults" PRIMARY KEY ("IsnExamResult"),
        CONSTRAINT "FK_ExamResults_ExamRegistrations_IsnExamRegistration" FOREIGN KEY ("IsnExamRegistration") REFERENCES "ExamRegistrations" ("IsnExamRegistration") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "ImageEmbeds" (
        "IsnImageEmbed" uuid NOT NULL,
        "IsnPost" uuid NOT NULL,
        "IsnImage" uuid NOT NULL,
        CONSTRAINT "PK_ImageEmbeds" PRIMARY KEY ("IsnImageEmbed")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Images" (
        "IsnImage" uuid NOT NULL,
        "IsnUploader" uuid NOT NULL,
        "Description" character varying(255),
        "Data" bytea NOT NULL,
        CONSTRAINT "PK_Images" PRIMARY KEY ("IsnImage")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Users" (
        "IsnUser" uuid NOT NULL,
        "IsnProfilePicture" uuid,
        "Email" character varying(254) NOT NULL,
        "Username" character varying(100) NOT NULL,
        "Phone" character varying(16),
        "Website" character varying(255),
        "AboutMe" text,
        CONSTRAINT "PK_Users" PRIMARY KEY ("IsnUser"),
        CONSTRAINT "FK_Users_Images_IsnProfilePicture" FOREIGN KEY ("IsnProfilePicture") REFERENCES "Images" ("IsnImage")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE TABLE "Posts" (
        "IsnPost" uuid NOT NULL,
        "IsnUser" uuid NOT NULL,
        "Message" text NOT NULL,
        CONSTRAINT "PK_Posts" PRIMARY KEY ("IsnPost"),
        CONSTRAINT "FK_Posts_Users_IsnUser" FOREIGN KEY ("IsnUser") REFERENCES "Users" ("IsnUser") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Adoptions_IsnCat" ON "Adoptions" ("IsnCat");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Adoptions_IsnCustomer" ON "Adoptions" ("IsnCustomer");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Adoptions_IsnMiniPig" ON "Adoptions" ("IsnMiniPig");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_AnnouncementGroups_IsnAnnouncement_IsnGroup" ON "AnnouncementGroups" ("IsnAnnouncement", "IsnGroup");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_AnnouncementGroups_IsnGroup" ON "AnnouncementGroups" ("IsnGroup");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Announcements_IsnTeacher" ON "Announcements" ("IsnTeacher");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Assignments_IsnSubject" ON "Assignments" ("IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_AuthorBooks_IsnAuthor_IsnBook" ON "AuthorBooks" ("IsnAuthor", "IsnBook");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_AuthorBooks_IsnBook" ON "AuthorBooks" ("IsnBook");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE UNIQUE INDEX "IX_Authors_IsnTeacher" ON "Authors" ("IsnTeacher");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_BeautyAppointment_IsnBeautyClient" ON "BeautyAppointment" ("IsnBeautyClient");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_BeautyAppointment_IsnBeautyService" ON "BeautyAppointment" ("IsnBeautyService");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Career_IsnStudent" ON "Career" ("IsnStudent");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Career_IsnSubject" ON "Career" ("IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_ExamRegistrations_IsnExam" ON "ExamRegistrations" ("IsnExam");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_ExamRegistrations_IsnStudent" ON "ExamRegistrations" ("IsnStudent");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE UNIQUE INDEX "IX_ExamResults_IsnExamRegistration" ON "ExamResults" ("IsnExamRegistration");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Exams_IsnSubject" ON "Exams" ("IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Games_IsnDeveloper" ON "Games" ("IsnDeveloper");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Grades_IsnStudent" ON "Grades" ("IsnStudent");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Grades_IsnSubject" ON "Grades" ("IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_ImageEmbeds_IsnImage" ON "ImageEmbeds" ("IsnImage");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_ImageEmbeds_IsnPost" ON "ImageEmbeds" ("IsnPost");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Images_IsnUploader" ON "Images" ("IsnUploader");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Kvns_IsnStudent" ON "Kvns" ("IsnStudent");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Kvns_IsnSubject" ON "Kvns" ("IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Materials_IsnSubject" ON "Materials" ("IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_MenuItems_IsnMenu" ON "MenuItems" ("IsnMenu");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Menus_IsnRestaurant" ON "Menus" ("IsnRestaurant");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_MovieGenres_IsnGenre" ON "MovieGenres" ("IsnGenre");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_OrderItems_IsnMenuItem" ON "OrderItems" ("IsnMenuItem");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_OrderItems_IsnOrder" ON "OrderItems" ("IsnOrder");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Orders_IsnPatient" ON "Orders" ("IsnPatient");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Orders_IsnProduct" ON "Orders" ("IsnProduct");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Pingpongclub_IsnStudent" ON "Pingpongclub" ("IsnStudent");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Pingpongclub_IsnSubject" ON "Pingpongclub" ("IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Posts_IsnUser" ON "Posts" ("IsnUser");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Profcoms_IsnStudent" ON "Profcoms" ("IsnStudent");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Profcoms_IsnSubject" ON "Profcoms" ("IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_ProjectActivities_IsnStudent" ON "ProjectActivities" ("IsnStudent");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_ProjectActivities_IsnSubject" ON "ProjectActivities" ("IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_RestaurantOrders_IsnRestaurant" ON "RestaurantOrders" ("IsnRestaurant");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Seats_IsnHall" ON "Seats" ("IsnHall");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_ServiceOrders_IsnMaster" ON "ServiceOrders" ("IsnMaster");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_ServiceOrders_IsnService" ON "ServiceOrders" ("IsnService");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Sessions_IsnHall" ON "Sessions" ("IsnHall");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Sessions_IsnMovie" ON "Sessions" ("IsnMovie");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Sportclub_IsnStudent" ON "Sportclub" ("IsnStudent");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Sportclub_IsnSubject" ON "Sportclub" ("IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_StudentLab_IsnLab" ON "StudentLab" ("IsnLab");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_StudentLab_IsnStudent" ON "StudentLab" ("IsnStudent");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_StudentNotes_IsnStudent" ON "StudentNotes" ("IsnStudent");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Students_IsnGroup" ON "Students" ("IsnGroup");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_SubjectsGroups_IsnGroup" ON "SubjectsGroups" ("IsnGroup");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_SubjectsGroups_IsnSubject_IsnGroup" ON "SubjectsGroups" ("IsnSubject", "IsnGroup");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_SweetProductions_IsnSweet" ON "SweetProductions" ("IsnSweet");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_SweetProductions_IsnSweetFactory" ON "SweetProductions" ("IsnSweetFactory");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Sweets_IsnSweetType" ON "Sweets" ("IsnSweetType");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_TeacherSubjects_IsnSubject" ON "TeacherSubjects" ("IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_TeacherSubjects_IsnTeacher_IsnSubject" ON "TeacherSubjects" ("IsnTeacher", "IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_TheAttendanceLog_IsnStudent" ON "TheAttendanceLog" ("IsnStudent");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_TheAttendanceLog_IsnSubject" ON "TheAttendanceLog" ("IsnSubject");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Tickets_IsnCustomer" ON "Tickets" ("IsnCustomer");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Tickets_IsnSeat" ON "Tickets" ("IsnSeat");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE INDEX "IX_Tickets_IsnSession" ON "Tickets" ("IsnSession");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE UNIQUE INDEX "IX_Users_Email" ON "Users" ("Email");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    CREATE UNIQUE INDEX "IX_Users_IsnProfilePicture" ON "Users" ("IsnProfilePicture");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    ALTER TABLE "ImageEmbeds" ADD CONSTRAINT "FK_ImageEmbeds_Images_IsnImage" FOREIGN KEY ("IsnImage") REFERENCES "Images" ("IsnImage") ON DELETE RESTRICT;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    ALTER TABLE "ImageEmbeds" ADD CONSTRAINT "FK_ImageEmbeds_Posts_IsnPost" FOREIGN KEY ("IsnPost") REFERENCES "Posts" ("IsnPost") ON DELETE RESTRICT;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    ALTER TABLE "Images" ADD CONSTRAINT "FK_Images_Users_IsnUploader" FOREIGN KEY ("IsnUploader") REFERENCES "Users" ("IsnUser") ON DELETE RESTRICT;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250616114747_InitDatabase') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250616114747_InitDatabase', '9.0.5');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619000444_AddPhotography') THEN
    CREATE TABLE "PhotographyClients" (
        "IsnPhotographyClient" uuid NOT NULL,
        "FirstName" character varying(100) NOT NULL,
        "LastName" character varying(100) NOT NULL,
        "Phone" character varying(20) NOT NULL,
        "Email" character varying(255) NOT NULL,
        "RegistrationDate" timestamp with time zone NOT NULL,
        "BirthDate" timestamp with time zone,
        "Notes" character varying(1000),
        CONSTRAINT "PK_PhotographyClients" PRIMARY KEY ("IsnPhotographyClient")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619000444_AddPhotography') THEN
    CREATE TABLE "PhotographyEquipments" (
        "IsnPhotographyEquipment" uuid NOT NULL,
        "Name" character varying(200) NOT NULL,
        "Type" integer NOT NULL,
        "Brand" character varying(100) NOT NULL,
        "Model" character varying(100) NOT NULL,
        "SerialNumber" character varying(50),
        "PurchaseDate" timestamp with time zone,
        "Price" double precision,
        "Status" integer NOT NULL,
        "Description" character varying(1000),
        CONSTRAINT "PK_PhotographyEquipments" PRIMARY KEY ("IsnPhotographyEquipment")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619000444_AddPhotography') THEN
    CREATE TABLE "PhotographySessions" (
        "IsnPhotographySession" uuid NOT NULL,
        "Title" character varying(200) NOT NULL,
        "SessionDate" timestamp with time zone NOT NULL,
        "Duration" integer NOT NULL,
        "Location" character varying(300) NOT NULL,
        "Price" double precision NOT NULL,
        "PhotographerName" character varying(100) NOT NULL,
        "PhotographySessionType" integer NOT NULL,
        "Status" integer NOT NULL,
        "Description" character varying(1000),
        "PhotoCount" integer,
        CONSTRAINT "PK_PhotographySessions" PRIMARY KEY ("IsnPhotographySession")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619000444_AddPhotography') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250619000444_AddPhotography', '9.0.5');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619001700_AddCarService') THEN
    CREATE TABLE "Owners" (
        "IsnOwner" uuid NOT NULL,
        "FirstName" character varying(50) NOT NULL,
        "SecondName" character varying(50) NOT NULL,
        "PhoneNumber" character varying(20) NOT NULL,
        "Email" character varying(50) NOT NULL,
        "Address" character varying(500) NOT NULL,
        CONSTRAINT "PK_Owners" PRIMARY KEY ("IsnOwner")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619001700_AddCarService') THEN
    CREATE TABLE "ServiceRecords" (
        "IsnServiceRecord" uuid NOT NULL,
        "CarLicensePlate" character varying(50) NOT NULL,
        "ServiceDate" timestamp with time zone NOT NULL,
        "ServiceType" character varying(100) NOT NULL,
        "Description" character varying(1000) NOT NULL,
        "MechanicName" character varying(100) NOT NULL,
        "Cost" double precision NOT NULL,
        "IsCompleted" boolean NOT NULL,
        CONSTRAINT "PK_ServiceRecords" PRIMARY KEY ("IsnServiceRecord")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619001700_AddCarService') THEN
    CREATE TABLE "Cars" (
        "IsnCar" uuid NOT NULL,
        "IsnOwner" uuid NOT NULL,
        "Brand" character varying(50) NOT NULL,
        "Model" character varying(50) NOT NULL,
        "Year" integer NOT NULL,
        "Mileage" integer NOT NULL,
        "Color" character varying(50) NOT NULL,
        "LicensePlate" character varying(50) NOT NULL,
        "VinNumber" character varying(50) NOT NULL,
        CONSTRAINT "PK_Cars" PRIMARY KEY ("IsnCar"),
        CONSTRAINT "FK_Cars_Owners_IsnOwner" FOREIGN KEY ("IsnOwner") REFERENCES "Owners" ("IsnOwner") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619001700_AddCarService') THEN
    CREATE UNIQUE INDEX "IX_Cars_IsnOwner" ON "Cars" ("IsnOwner");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619001700_AddCarService') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250619001700_AddCarService', '9.0.5');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619002550_AddMusic') THEN
    CREATE TABLE "MusicAlbums" (
        "IsnAlbum" uuid NOT NULL,
        "Title" character varying(200) NOT NULL,
        "Genre" character varying(100) NOT NULL,
        "ReleaseYear" integer NOT NULL,
        "Price" double precision NOT NULL,
        "Duration" integer NOT NULL,
        "CreatedDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_MusicAlbums" PRIMARY KEY ("IsnAlbum")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619002550_AddMusic') THEN
    CREATE TABLE "MusicArtists" (
        "IsnArtist" uuid NOT NULL,
        "Name" character varying(200) NOT NULL,
        "Country" character varying(100) NOT NULL,
        "BirthYear" integer,
        "Genre" character varying(100) NOT NULL,
        "ArtistType" integer NOT NULL,
        "Biography" character varying(2000),
        "CreatedDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_MusicArtists" PRIMARY KEY ("IsnArtist")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619002550_AddMusic') THEN
    CREATE TABLE "MusicCustomers" (
        "IsnCustomer" uuid NOT NULL,
        "FirstName" character varying(100) NOT NULL,
        "LastName" character varying(100) NOT NULL,
        "Email" character varying(255) NOT NULL,
        "Phone" character varying(20),
        "BirthDate" timestamp with time zone,
        "PreferredGenre" character varying(100),
        "Status" integer NOT NULL,
        "RegistrationDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_MusicCustomers" PRIMARY KEY ("IsnCustomer")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250619002550_AddMusic') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250619002550_AddMusic', '9.0.5');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250620181726_AddBookshop') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250620181726_AddBookshop', '9.0.5');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250627015528_AddBookshopKeys') THEN
    CREATE TABLE "BookshopAuthors" (
        "AuthorId" integer GENERATED BY DEFAULT AS IDENTITY,
        "Name" character varying(128),
        "BirthYear" integer,
        CONSTRAINT "PK_BookshopAuthors" PRIMARY KEY ("AuthorId")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250627015528_AddBookshopKeys') THEN
    CREATE TABLE "BookshopGenres" (
        "GenreId" integer GENERATED BY DEFAULT AS IDENTITY,
        "Name" character varying(64),
        CONSTRAINT "PK_BookshopGenres" PRIMARY KEY ("GenreId")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250627015528_AddBookshopKeys') THEN
    CREATE TABLE "BookshopBooks" (
        "BookId" integer GENERATED BY DEFAULT AS IDENTITY,
        "Title" character varying(256),
        "Pages" integer,
        "AuthorId" integer NOT NULL,
        "GenreId" integer NOT NULL,
        CONSTRAINT "PK_BookshopBooks" PRIMARY KEY ("BookId"),
        CONSTRAINT "FK_BookshopBooks_BookshopAuthors_AuthorId" FOREIGN KEY ("AuthorId") REFERENCES "BookshopAuthors" ("AuthorId") ON DELETE RESTRICT,
        CONSTRAINT "FK_BookshopBooks_BookshopGenres_GenreId" FOREIGN KEY ("GenreId") REFERENCES "BookshopGenres" ("GenreId") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250627015528_AddBookshopKeys') THEN
    CREATE INDEX "IX_BookshopBooks_AuthorId" ON "BookshopBooks" ("AuthorId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250627015528_AddBookshopKeys') THEN
    CREATE INDEX "IX_BookshopBooks_GenreId" ON "BookshopBooks" ("GenreId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250627015528_AddBookshopKeys') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250627015528_AddBookshopKeys', '9.0.5');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250628001308_FixBookshopPKs') THEN
    ALTER TABLE "BookshopGenres" ALTER COLUMN "Name" TYPE text;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250628001308_FixBookshopPKs') THEN
    ALTER TABLE "BookshopBooks" ALTER COLUMN "Title" TYPE text;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250628001308_FixBookshopPKs') THEN
    ALTER TABLE "BookshopAuthors" ALTER COLUMN "Name" TYPE text;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250628001308_FixBookshopPKs') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250628001308_FixBookshopPKs', '9.0.5');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250628022956_SyncModel') THEN
    ALTER TABLE "BookshopAuthors" ALTER COLUMN "Name" TYPE character varying(150);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250628022956_SyncModel') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250628022956_SyncModel', '9.0.5');
    END IF;
END $EF$;
COMMIT;

