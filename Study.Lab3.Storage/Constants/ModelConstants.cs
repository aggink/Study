namespace Study.Lab3.Storage.Constants;

/// <summary>
/// Ограничения для моделей
/// </summary>
public static class ModelConstants
{
    #region BeautySalon

    public static class BeautyClient
    {
        /// <summary>
        /// Максимальная длина поля "Имя"
        /// </summary>
        public const int FirstName = 100;

        /// <summary>
        /// Максимальная длина поля "Фамилия"
        /// </summary>
        public const int LastName = 100;

        /// <summary>
        /// Максимальная длина поля "Номер телефона"
        /// </summary>
        public const int PhoneNumber = 11;

        /// <summary>
        /// Максимальная длина поля "Электронная почта"
        /// </summary>
        public const int EmailAddress = 100;
    }

    public static class BeautyService
    {
        /// <summary>
        /// Максимальная длина поля "Название услуги"
        /// </summary>
        public const int ServiceName = 100;

        /// <summary>
        /// Максимальная длина поля "Описание услуги"
        /// </summary>
        public const int Description = 2000;

        /// <summary>
        /// Минимальная цена в рублях
        /// </summary>
        public const int MinServicePrice = 1;

        /// <summary>
        /// Максимальная цена в рублях
        /// </summary>
        public const int MaxServicePrice = 1000000;

        /// <summary>
        /// Максимальная длина поля "Длительность услуги в минутах"
        /// </summary>
        public const int Duration = 600;
    }

    public static class BeautyAppointment
    {
        /// <summary>
        /// Максимальное значение поля "День"
        /// </summary>
        public const int Day = 31;

        /// <summary>
        /// Максимальное значение поля "Месяц"
        /// </summary>
        public const int Month = 12;

        /// <summary>
        /// Максимальное значение поля "Час"
        /// </summary>
        public const int Hour = 24;

        /// <summary>
        /// Максимальное значение поля "Минуты"
        /// </summary>
        public const int Minutes = 60;
    }

    #endregion

    #region Cinema

    public static class Customer
    {
        /// <summary>
        /// Максимальная длина имени
        /// </summary>
        public const int FirstName = 100;

        /// <summary>
        /// Максимальная длина фамилии
        /// </summary>
        public const int LastName = 100;

        /// <summary>
        /// Максимальная длина email
        /// </summary>
        public const int Email = 255;

        /// <summary>
        /// Максимальная длина телефона
        /// </summary>
        public const int Phone = 20;
    }

    public static class Genre
    {
        /// <summary>
        /// Максимальная длина названия жанра
        /// </summary>
        public const int Name = 50;
    }

    public static class Hall
    {
        /// <summary>
        /// Максимальная длина названия зала
        /// </summary>
        public const int Name = 50;

        /// <summary>
        /// Минимальная вместимость зала
        /// </summary>
        public const int MinCapacity = 10;

        /// <summary>
        /// Максимальная вместимость зала
        /// </summary>
        public const int MaxCapacity = 500;

        /// <summary>
        /// Минимальное количество рядов
        /// </summary>
        public const int MinRows = 1;

        /// <summary>
        /// Максимальное количество рядов
        /// </summary>
        public const int MaxRows = 30;

        /// <summary>
        /// Минимальное количество мест в ряду
        /// </summary>
        public const int MinSeatsPerRow = 1;

        /// <summary>
        /// Максимальное количество мест в ряду
        /// </summary>
        public const int MaxSeatsPerRow = 30;
    }

    public static class Movie
    {
        /// <summary>
        /// Максимальная длина названия фильма
        /// </summary>
        public const int Title = 200;

        /// <summary>
        /// Максимальная длина описания
        /// </summary>
        public const int Description = 2000;

        /// <summary>
        /// Максимальная длина страны производства
        /// </summary>
        public const int Country = 100;

        /// <summary>
        /// Минимальная продолжительность фильма в минутах
        /// </summary>
        public const int MinDuration = 1;

        /// <summary>
        /// Максимальная продолжительность фильма в минутах
        /// </summary>
        public const int MaxDuration = 600;

        /// <summary>
        /// Минимальный рейтинг
        /// </summary>
        public const double MinRating = 0.0;

        /// <summary>
        /// Максимальный рейтинг
        /// </summary>
        public const double MaxRating = 10.0;

        /// <summary>
        /// Минимальный год выпуска
        /// </summary>
        public const int MinYear = 1895; // Год изобретения кинематографа

        /// <summary>
        /// Максимальный возрастной рейтинг
        /// </summary>
        public const int MaxAgeRating = 21;
    }

    public static class Ticket
    {
        /// <summary>
        /// Минимальная цена билета
        /// </summary>
        public const double MinPrice = 0.01;

        /// <summary>
        /// Максимальная цена билета
        /// </summary>
        public const double MaxPrice = 10000;

        /// <summary>
        /// Максимальная длина кода билета
        /// </summary>
        public const int TicketCodeLength = 50;
    }

    #endregion

    #region Fitness

    public static class FitnessMember
    {
        /// <summary>
        /// Максимальная длина поля "Фамилия"
        /// </summary>
        public const int SurName = 100;

        /// <summary>
        /// Максимальная длина поля "Имя"
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Максимальная длина поля "Отчество"
        /// </summary>
        public const int PatronymicName = 100;

        /// <summary>
        /// Максимальная длина поля "Номер телефона"
        /// </summary>
        public const int PhoneNumber = 20;

        /// <summary>
        /// Максимальная длина поля "Email"
        /// </summary>
        public const int Email = 255;
    }

    public static class FitnessTrainer
    {
        /// <summary>
        /// Максимальная длина поля "Фамилия"
        /// </summary>
        public const int SurName = 100;

        /// <summary>
        /// Максимальная длина поля "Имя"
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Максимальная длина поля "Отчество"
        /// </summary>
        public const int PatronymicName = 100;

        /// <summary>
        /// Максимальная длина поля "Номер телефона"
        /// </summary>
        public const int PhoneNumber = 20;

        /// <summary>
        /// Максимальная длина поля "Email"
        /// </summary>
        public const int Email = 255;

        /// <summary>
        /// Максимальная длина поля "Сертификации"
        /// </summary>
        public const int Certifications = 1000;

        /// <summary>
        /// Минимальный опыт работы в годах
        /// </summary>
        public const int MinExperience = 0;

        /// <summary>
        /// Максимальный опыт работы в годах
        /// </summary>
        public const int MaxExperience = 50;

        /// <summary>
        /// Минимальная почасовая ставка
        /// </summary>
        public const double MinHourlyRate = 0;

        /// <summary>
        /// Максимальная почасовая ставка
        /// </summary>
        public const double MaxHourlyRate = 10000;
    }

    public static class FitnessEquipment
    {
        /// <summary>
        /// Максимальная длина поля "Название"
        /// </summary>
        public const int Name = 200;

        /// <summary>
        /// Максимальная длина поля "Производитель"
        /// </summary>
        public const int Manufacturer = 100;

        /// <summary>
        /// Максимальная длина поля "Модель"
        /// </summary>
        public const int Model = 100;

        /// <summary>
        /// Максимальная длина поля "Серийный номер"
        /// </summary>
        public const int SerialNumber = 50;

        /// <summary>
        /// Максимальная длина поля "Описание"
        /// </summary>
        public const int Description = 1000;

        /// <summary>
        /// Минимальная цена
        /// </summary>
        public const double MinPrice = 0;

        /// <summary>
        /// Максимальная цена
        /// </summary>
        public const double MaxPrice = 1000000;
    }

    #endregion

    #region HospitalStore

    public static class Order
    {
        /// <summary>
        /// Минимальное количество товара в заказе
        /// </summary>
        public const int QuantityMin = 1;

        /// <summary>
        /// Максимальное количество товара в заказе
        /// </summary>
        public const int QuantityMax = 100;
    }

    public static class Patient
    {
        /// <summary>
        /// Максимальная длина поля "ФИО пациента"
        /// </summary>
        public const int FullNameMaxLength = 200;

        /// <summary>
        /// Максимальная длина номера медицинской карты
        /// </summary>
        public const int MedicalCardIdMaxLength = 50;

        /// <summary>
        /// Максимальная длина телефонного номера
        /// </summary>
        public const int PhoneMaxLength = 20;
    }

    public static class Product
    {
        /// <summary>
        /// Максимальная длина названия товара
        /// </summary>
        public const int NameMaxLength = 100;

        /// <summary>
        /// Максимальная длина категории товара
        /// </summary>
        public const int CategoryMaxLength = 50;

        /// <summary>
        /// Минимальная цена товара (в рублях)
        /// </summary>
        public const int PriceMin = 0;

        /// <summary>
        /// Максимальная цена товара (в рублях)
        /// </summary>
        public const int PriceMax = 1000000;
    }

    #endregion

    #region Library

    public static class Author
    {
        /// <summary>
        /// Максимальная длина поля "Фамилия"
        /// </summary>
        public const int SurName = 100;

        /// <summary>
        /// Максимальная длина поля "Имя"
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Максимальная длина поля "Отчество"
        /// </summary>
        public const int PatronymicName = 100;
    }

    public static class Book
    {
        /// <summary>
        /// Максимальная длина поля "Названия"
        /// </summary>
        public const int Title = 255;

        /// <summary>
        /// Минимальное значение года
        /// </summary>
        public const int MinYear = 1800;

        /// <summary>
        /// Максимальное значение года
        /// </summary>
        public const int MaxYear = 2025;

        /// <summary>
        /// Максимальная длина поля "Жанр"
        /// </summary>
        public const int Genre = 255;
    }

    #endregion

    #region Messenger

    public static class User
    {
        /// <summary>
        /// Максимальная длина почтового адреса
        /// </summary>
        public const int Email = 254;

        /// <summary>
        /// Максимальная длина имени пользователя
        /// </summary>
        public const int Username = 100;

        /// <summary>
        /// Максимальная длина номера телефона
        /// </summary>
        public const int Phone = 16;

        /// <summary>
        /// Максимальная длина ссылки на персональный сайт пользователя
        /// </summary>
        public const int Website = 255;
    }

    public static class Image
    {
        /// <summary>
        /// Максимальная длина описания
        /// </summary>
        public const int Description = 255;
    }

    #endregion

    #region Restaurants

    public static class Restaurant
    {
        /// <summary>
        /// Максимальная длина названия ресторана
        /// </summary>
        public const int Name = 200;

        /// <summary>
        /// Максимальная длина адреса
        /// </summary>
        public const int Address = 500;

        /// <summary>
        /// Максимальная длина телефона
        /// </summary>
        public const int Phone = 20;

        /// <summary>
        /// Максимальная длина email
        /// </summary>
        public const int Email = 100;

        /// <summary>
        /// Максимальная длина времени работы
        /// </summary>
        public const int WorkingHours = 100;
    }

    public static class Menu
    {
        /// <summary>
        /// Максимальная длина названия меню
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Максимальная длина описания меню
        /// </summary>
        public const int Description = 500;
    }

    public static class MenuItem
    {
        /// <summary>
        /// Максимальная длина названия блюда
        /// </summary>
        public const int Name = 200;

        /// <summary>
        /// Максимальная длина описания блюда
        /// </summary>
        public const int Description = 1000;

        /// <summary>
        /// Максимальная длина категории
        /// </summary>
        public const int Category = 50;

        /// <summary>
        /// Минимальная цена
        /// </summary>
        public const double MinPrice = 0.01;

        /// <summary>
        /// Максимальная цена
        /// </summary>
        public const double MaxPrice = 99999.99;

        /// <summary>
        /// Минимальное время приготовления
        /// </summary>
        public const int MinCookingTime = 1;

        /// <summary>
        /// Максимальное время приготовления
        /// </summary>
        public const int MaxCookingTime = 480; // 8 часов
    }

    public static class RestaurantOrder
    {
        /// <summary>
        /// Максимальная длина номера заказа
        /// </summary>
        public const int OrderNumber = 20;

        /// <summary>
        /// Максимальная длина имени клиента
        /// </summary>
        public const int CustomerName = 100;

        /// <summary>
        /// Максимальная длина телефона клиента
        /// </summary>
        public const int CustomerPhone = 20;

        /// <summary>
        /// Максимальная длина статуса
        /// </summary>
        public const int Status = 20;

        /// <summary>
        /// Минимальный номер стола
        /// </summary>
        public const int MinTableNumber = 1;

        /// <summary>
        /// Максимальный номер стола
        /// </summary>
        public const int MaxTableNumber = 999;
    }

    public static class OrderItem
    {
        /// <summary>
        /// Минимальное количество
        /// </summary>
        public const int MinQuantity = 1;

        /// <summary>
        /// Максимальное количество
        /// </summary>
        public const int MaxQuantity = 100;

        /// <summary>
        /// Максимальная длина особых пожеланий
        /// </summary>
        public const int SpecialRequests = 500;
    }

    #endregion

    #region Shelter

    public static class Adoption
    {
        /// <summary>
        /// Минимальная цена за усыновление
        /// </summary>
        public const int PriceMin = 0;

        /// <summary>
        /// Максимальная цена за усыновление
        /// </summary>
        public const int PriceMax = 1_000_000;

        /// <summary>
        /// Максимальная длина статуса усыновления
        /// </summary>
        public const int Status = 50;
    }

    public static class Cat
    {
        /// <summary>
        /// Максимальная длина клички кота
        /// </summary>
        public const int Nickname = 100;

        /// <summary>
        /// Максимальная длина описания кота
        /// </summary>
        public const int Description = 500;

        /// <summary>
        /// Максимальная длина названия породы
        /// </summary>
        public const int Breed = 100;

        /// <summary>
        /// Максимальная длина названия окраса
        /// </summary>
        public const int Color = 20;

        /// <summary>
        /// Максимальная длина истории болезней
        /// </summary>
        public const int MedicalHistory = 1000;

        /// <summary>
        /// Минимальный возраст кота (в годах)
        /// </summary>
        public const int AgeMin = 0;

        /// <summary>
        /// Максимальный возраст кота (в годах)
        /// </summary>
        public const int AgeMax = 30;

        /// <summary>
        /// Минимальный вес кота (в кг)
        /// </summary>
        public const double WeightMin = 0.5;

        /// <summary>
        /// Максимальный вес кота (в кг)
        /// </summary>
        public const double WeightMax = 15.0;

        /// <summary>
        /// Ссылка на фотографию кота
        /// </summary>
        public const int PhotoUrl = 100;
    }

    public static class ShelterCustomer
    {
        /// <summary>
        /// Максимальная длина имени клиента
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Максимальная длина описания клиента
        /// </summary>
        public const int Description = 500;

        /// <summary>
        /// Максимальная длина адреса клиента
        /// </summary>
        public const int Address = 100;

        /// <summary>
        /// Максимальная длина номера телефона клиента
        /// </summary>
        public const int PhoneNumber = 15;

        /// <summary>
        /// Максимальная длина email клиента
        /// </summary>
        public const int Email = 255;
    }

    public static class MiniPig
    {
        /// <summary>
        /// Максимальная длина клички мини пига
        /// </summary>
        public const int Nickname = 100;

        /// <summary>
        /// Максимальная длина описания мини пига
        /// </summary>
        public const int Description = 500;

        /// <summary>
        /// Максимальная длина названия породы
        /// </summary>
        public const int Breed = 100;

        /// <summary>
        /// Максимальная длина названия окраса
        /// </summary>
        public const int Color = 20;

        /// <summary>
        /// Максимальная длина истории болезней
        /// </summary>
        public const int MedicalHistory = 1000;

        /// <summary>
        /// Минимальный возраст мини пига (в годах)
        /// </summary>
        public const int AgeMin = 0;

        /// <summary>
        /// Максимальный возраст мини пига (в годах)
        /// </summary>
        public const int AgeMax = 20;

        /// <summary>
        /// Минимальный вес мини пига (в кг)
        /// </summary>
        public const double WeightMin = 10.0;

        /// <summary>
        /// Максимальный вес мини пига (в кг)
        /// </summary>
        public const double WeightMax = 120.0;

        /// <summary>
        /// Ссылка на фотографию мини пига
        /// </summary>
        public const int PhotoUrl = 100;
    }

    #endregion

    #region SweetFactory

    public static class SweetFactory
    {
        /// <summary>
        /// Минимальная длинна названия фабрики
        /// </summary>
        public const int MinNameLenght = 1;

        /// <summary>
        /// Максимальная длинна идентификатора фабрики
        /// </summary>
        public const int MaxNameLenght = 256;

        /// <summary>
        /// Минимальная длинна адреса
        /// </summary>
        public const int MinAddressLenght = 1;

        /// <summary>
        /// Максимальная длинна адреса
        /// </summary>
        public const int MaxAddressLenght = 256;
    }

    public static class Sweet
    {
        /// <summary>
        /// Минимальное наименование конфеты
        /// </summary>
        public const int MinNameLenght = 1;

        /// <summary>
        /// Максимальное наименование конфеты
        /// </summary>
        public const int MaxNameLenght = 256;

        /// <summary>
        /// Минимальное наименование ингридиента конфеты
        /// </summary>
        public const int MinIngredientsLenght = 1;

        /// <summary>
        /// Максимальное наименование ингридиента конфеты
        /// </summary>
        public const int MaxIngredientsLenght = 256;
    }

    public static class SweetType
    {
        /// <summary>
        /// Минимальное наименование типа конфеты
        /// </summary>
        public const int MinNameLenght = 1;

        /// <summary>
        /// Максимальное наименование типа конфеты
        /// </summary>
        public const int MaxNameLenght = 256;
    }

    #endregion

    #region TravelAgency

    public static class Tour
    {
        /// <summary>
        /// Максимальная длина поля "Название"
        /// </summary>
        public const int Name = 200;

        /// <summary>
        /// Максимальная длина поля "Описание"
        /// </summary>
        public const int Description = 2000;

        /// <summary>
        /// Максимальная длина поля "Страна"
        /// </summary>
        public const int Country = 100;

        /// <summary>
        /// Максимальная длина поля "Город"
        /// </summary>
        public const int City = 100;

        /// <summary>
        /// Минимальная цена тура
        /// </summary>
        public const double MinPrice = 0;

        /// <summary>
        /// Максимальная цена тура
        /// </summary>
        public const double MaxPrice = 999999;

        /// <summary>
        /// Минимальная продолжительность тура в днях
        /// </summary>
        public const int MinDuration = 1;

        /// <summary>
        /// Максимальная продолжительность тура в днях
        /// </summary>
        public const int MaxDuration = 365;

        /// <summary>
        /// Минимальное количество участников
        /// </summary>
        public const int MinParticipants = 1;

        /// <summary>
        /// Максимальное количество участников
        /// </summary>
        public const int MaxParticipants = 100;
    }

    public static class Hotel
    {
        /// <summary>
        /// Максимальная длина поля "Название"
        /// </summary>
        public const int Name = 200;

        /// <summary>
        /// Максимальная длина поля "Описание"
        /// </summary>
        public const int Description = 2000;

        /// <summary>
        /// Максимальная длина поля "Адрес"
        /// </summary>
        public const int Address = 500;

        /// <summary>
        /// Максимальная длина поля "Страна"
        /// </summary>
        public const int Country = 100;

        /// <summary>
        /// Максимальная длина поля "Город"
        /// </summary>
        public const int City = 100;

        /// <summary>
        /// Максимальная длина поля "Телефон"
        /// </summary>
        public const int Phone = 20;

        /// <summary>
        /// Максимальная длина поля "Email"
        /// </summary>
        public const int Email = 100;

        /// <summary>
        /// Минимальное значение для стоимости за ночь.
        /// </summary>
        public const int PricePerNightMin = 0;

        /// <summary>
        /// Максимальное значение для стоимости за ночь.
        /// </summary>
        public const int PricePerNightMax = 1000000;
    }

    public static class TravelCustomer
    {
        /// <summary>
        /// Максимальная длина поля "Фамилия"
        /// </summary>
        public const int SurName = 100;

        /// <summary>
        /// Максимальная длина поля "Имя"
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Максимальная длина поля "Отчество"
        /// </summary>
        public const int PatronymicName = 100;

        /// <summary>
        /// Максимальная длина поля "Номер паспорта"
        /// </summary>
        public const int PassportNumber = 20;

        /// <summary>
        /// Максимальная длина поля "Телефон"
        /// </summary>
        public const int Phone = 20;

        /// <summary>
        /// Максимальная длина поля "Email"
        /// </summary>
        public const int Email = 100;

        /// <summary>
        /// Максимальная длина поля "Адрес"
        /// </summary>
        public const int Address = 500;
    }

    #endregion

    #region University

    public static class Student
    {
        /// <summary>
        /// Максимальная длина поля "Фамилия"
        /// </summary>
        public const int SurName = 100;

        /// <summary>
        /// Максимальная длина поля "Имя"
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Максимальная длина поля "Отчество"
        /// </summary>
        public const int PatronymicName = 100;

        /// <summary>
        /// Минимальное значение возраста
        /// </summary>
        public const int AgeMin = 1;

        /// <summary>
        /// Максимальное значение возраста
        /// </summary>
        public const int AgeMax = 100;
    }

    public static class Group
    {
        /// <summary>
        /// Максимальная длина поля "Наименование"
        /// </summary>
        public const int Name = 20;
    }

    public static class Labs
    {
        /// <summary>
        /// Максимальная длина поля "Наименование"
        /// </summary>
        public const int Name = 20;
    }

    public static class Subject
    {
        /// <summary>
        /// Максимальная длина поля "Наименование"
        /// </summary>
        public const int Name = 255;
    }

    public static class Teacher
    {
        /// <summary>
        /// Максимальная длина поля "Фамилия"
        /// </summary>
        public const int SurName = 100;

        /// <summary>
        /// Максимальная длина поля "Имя"
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Максимальная длина поля "Отчество"
        /// </summary>
        public const int PatronymicName = 100;
    }

    public static class Grade
    {
        /// <summary>
        /// Минимальное значение оценки
        /// </summary>
        public const int MinValue = 2;

        /// <summary>
        /// Максимальное значение оценки
        /// </summary>
        public const int MaxValue = 5;
    }

    public static class Assignment
    {
        /// <summary>
        /// Максимальная длина названия задания
        /// </summary>
        public const int Title = 200;

        /// <summary>
        /// Максимальная длина описания
        /// </summary>
        public const int Description = 2000;

        /// <summary>
        /// Максимальная оценка за задание
        /// </summary>
        public const int MaxScore = 100;

        /// <summary>
        /// Минимальная оценка за задание
        /// </summary>
        public const int MinScore = 1;
    }

    public static class Material
    {
        /// <summary>
        /// Максимальная длина названия материала
        /// </summary>
        public const int Title = 200;

        /// <summary>
        /// Максимальная длина описания
        /// </summary>
        public const int Description = 2000;

        /// <summary>
        /// Максимальная длина типа материала
        /// </summary>
        public const int Type = 50;
    }

    public static class Pingpongclub
    {
        /// <summary>
        /// Минимально допустимое количество участников.
        /// </summary>
        public const int MinParticipantValue = 4;

        /// <summary>
        /// Максимально допустимое количество участников.
        /// </summary>
        public const int MaxParticipantValue = 102;
    }

    public static class Announcement
    {
        /// <summary>
        /// Максимальная длина заголовка объявления
        /// </summary>
        public const int Title = 200;

        /// <summary>
        /// Максимальная длина содержимого задания
        /// </summary>
        public const int Content = 2000;
    }

    public static class Exam
    {
        /// <summary>
        /// Максимальная длина поля "Имя"
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Максимальная длина поля "Описание"
        /// </summary>
        public const int Description = 500;

        /// <summary>
        /// Минимальная продолжительность экзамена в минутах
        /// </summary>
        public const int MinDuration = 30;

        /// <summary>
        /// Максимальная продолжительность экзамена в минутах
        /// </summary>
        public const int MaxDuration = 240;

        /// <summary>
        /// Минимальное количество баллов для зачета
        /// </summary>
        public const int MinScore = 1;

        /// <summary>
        /// Максимальное количество баллов за экзамен
        /// </summary>
        public const int MaxScore = 100;
    }

    public static class ExamResult
    {
        /// <summary>
        /// Минимально допустимое количество баллов для задания или экзамена.
        /// </summary>
        public const int MinScore = 0;

        /// <summary>
        /// Максимально допустимое количество баллов для задания или экзамена.
        /// </summary>
        public const int MaxScore = 100;

        /// <summary>
        /// Максимальная длина поля "Комментарии".
        /// </summary>
        public const int Comments = 500;
    }

    public static class Sportclub
    {
        /// <summary>
        /// Минимально допустимое количество участников.
        /// </summary>
        public const int MinParticipantValue = 2;

        /// <summary>
        /// Максимально допустимое количество участников.
        /// </summary>
        public const int MaxParticipantValue = 100;
    }

    public static class Session
    {
        /// <summary>
        /// Минимальная цена билета
        /// </summary>
        public const double MinPrice = 0.01;

        /// <summary>
        /// Максимальная цена билета
        /// </summary>
        public const double MaxPrice = 10000;
    }

    public static class Profcom
    {
        /// <summary>
        /// Минимально допустимое количество участников.
        /// </summary>
        public const int MinPartValue = 0;

        /// <summary>
        /// Максимально допустимое количество участников.
        /// </summary>
        public const int MaxPartValue = 500;
    }

    public static class Kvn
    {
        /// <summary>
        /// Минимально допустимое количество участников.
        /// </summary>
        public const int MinPart = 3;

        /// <summary>
        /// Максимально допустимое количество участников.
        /// </summary>
        public const int MaxPart = 10;
    }

    public static class Career
    {
        /// <summary>
        /// Минимально допустимое количество участников.
        /// </summary>
        public const int MinPartValue = 20;

        /// <summary>
        /// Максимально допустимое количество участников.
        /// </summary>
        public const int MaxPartValue = 100;
    }

    public static class AttendanceLog
    {
        /// <summary>
        /// Минимально 0 как отсутствие студента
        /// </summary>
        public const int MinPresentValue = 0;

        /// <summary>
        /// Максимально 1 как присутствие студента
        /// </summary>
        public const int MaxPresentValue = 1;
    }

    public static class ProjectActivities
    {
        /// <summary>
        /// Минимально допустимое количество выступлений.
        /// </summary>
        public const int MinPerformancesValue = 10;

        /// <summary>
        /// Максимально допустимое количество выступлений.
        /// </summary>
        public const int MaxPerformancesValue = 20;
    }

    public static class StudentNote
    {
        public const int MaxTextLength = 500;
    }

    public static class ScientificWork
    {
        public const int MinPageCount = 5;
        public const int MaxPageCount = 500;
        public const int TitleMaxLength = 200;
        public const int DescriptionMaxLength = 1000;
    }

    #endregion

    #region Workshop

    public static class Master
    {
        /// <summary>
        /// Максимальная длина поля "Имя"
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Максимальная длина поля "Email"
        /// </summary>
        public const int Email = 200;

        /// <summary>
        /// Максимальная длина поля "Телефон"
        /// </summary>
        public const int Phone = 20;

        /// <summary>
        /// Максимальная длина поля "Специализация"
        /// </summary>
        public const int Specialization = 200;
    }

    public static class Service
    {
        /// <summary>
        /// Максимальная длина поля "Название"
        /// </summary>
        public const int Name = 200;

        /// <summary>
        /// Максимальная длина поля "Описание"
        /// </summary>
        public const int Description = 1000;

        /// <summary>
        /// Минимальная цена услуги
        /// </summary>
        public const double MinPrice = 0.01;

        /// <summary>
        /// Максимальная цена услуги
        /// </summary>
        public const double MaxPrice = 999999.99;

        /// <summary>
        /// Минимальная длительность в минутах
        /// </summary>
        public const int MinDuration = 5;

        /// <summary>
        /// Максимальная длительность в минутах
        /// </summary>
        public const int MaxDuration = 10080; // неделя
    }

    public static class ServiceOrder
    {
        /// <summary>
        /// Максимальная длина поля "Имя клиента"
        /// </summary>
        public const int CustomerName = 100;

        /// <summary>
        /// Максимальная длина поля "Телефон клиента"
        /// </summary>
        public const int CustomerPhone = 20;

        /// <summary>
        /// Максимальная длина поля "Описание"
        /// </summary>
        public const int Description = 1000;

        /// <summary>
        /// Минимальная итоговая стоимость
        /// </summary>
        public const double MinTotalPrice = 0.01;

        /// <summary>
        /// Максимальная итоговая стоимость
        /// </summary>
        public const double MaxTotalPrice = 999999.99;
    }


    #endregion

    #region GameStore

    public static class Game
    {
        /// <summary>
        /// Максимальная длина названия игры
        /// </summary>
        public const int Title = 200;

        /// <summary>
        /// Максимальная длина описания игры
        /// </summary>
        public const int Description = 1000;

        /// <summary>
        /// Минимальная цена игры
        /// </summary>
        public const double MinPrice = 0;

        /// <summary>
        /// Максимальная цена игры
        /// </summary>
        public const double MaxPrice = 99999.99;

        /// <summary>
        /// Максимальная длина жанра
        /// </summary>
        public const int Genre = 100;

        /// <summary>
        /// Максимальная длина возрастного рейтинга
        /// </summary>
        public const int AgeRating = 10;
    }

    public static class Developer
    {
        /// <summary>
        /// Максимальная длина названия компании
        /// </summary>
        public const int CompanyName = 150;

        /// <summary>
        /// Максимальная длина названия страны
        /// </summary>
        public const int Country = 100;

        /// <summary>
        /// Максимальная длина веб-сайта
        /// </summary>
        public const int Website = 200;

        /// <summary>
        /// Максимальная длина email
        /// </summary>
        public const int ContactEmail = 100;

        /// <summary>
        /// Максимальная длина описания компании
        /// </summary>
        public const int Description = 500;

        /// <summary>
        /// Минимальный год основания компании
        /// </summary>
        public const int MinFoundedYear = 1900;
    }

    public static class Platform
    {
        /// <summary>
        /// Максимальная длина названия платформы
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Максимальная длина названия производителя
        /// </summary>
        public const int Manufacturer = 100;

        /// <summary>
        /// Максимальная длина типа платформы
        /// </summary>
        public const int Type = 50;

        /// <summary>
        /// Максимальная длина описания платформы
        /// </summary>
        public const int Description = 500;

        /// <summary>
        /// Минимальное поколение платформы
        /// </summary>
        public const int MinGeneration = 1;

        /// <summary>
        /// Максимальное поколение платформы
        /// </summary>
        public const int MaxGeneration = 20;

        /// <summary>
        /// Минимальный год выпуска платформы
        /// </summary>
        public const int MinReleaseYear = 1970;
    }

    #endregion

    #region MusicStore

    public static class MusicAlbum
    {
        /// <summary>
        /// Максимальная длина названия альбома
        /// </summary>
        public const int Title = 200;

        /// <summary>
        /// Максимальная длина жанра
        /// </summary>
        public const int Genre = 100;

        /// <summary>
        /// Минимальный год выпуска
        /// </summary>
        public const int MinReleaseYear = 1900;

        /// <summary>
        /// Максимальный год выпуска
        /// </summary>
        public const int MaxReleaseYear = 2030;

        /// <summary>
        /// Минимальная цена
        /// </summary>
        public const double MinPrice = 0;

        /// <summary>
        /// Максимальная цена
        /// </summary>
        public const double MaxPrice = 10000;

        /// <summary>
        /// Минимальная продолжительность в минутах
        /// </summary>
        public const int MinDuration = 1;

        /// <summary>
        /// Максимальная продолжительность в минутах
        /// </summary>
        public const int MaxDuration = 300;
    }

    public static class MusicArtist
    {
        /// <summary>
        /// Максимальная длина имени исполнителя
        /// </summary>
        public const int Name = 200;

        /// <summary>
        /// Максимальная длина страны
        /// </summary>
        public const int Country = 100;

        /// <summary>
        /// Максимальная длина жанра
        /// </summary>
        public const int Genre = 100;

        /// <summary>
        /// Максимальная длина биографии
        /// </summary>
        public const int Biography = 2000;

        /// <summary>
        /// Минимальный год рождения/основания
        /// </summary>
        public const int MinBirthYear = 1800;

        /// <summary>
        /// Максимальный год рождения/основания
        /// </summary>
        public const int MaxBirthYear = 2020;
    }

    public static class MusicCustomer
    {
        /// <summary>
        /// Максимальная длина имени
        /// </summary>
        public const int FirstName = 100;

        /// <summary>
        /// Максимальная длина фамилии
        /// </summary>
        public const int LastName = 100;

        /// <summary>
        /// Максимальная длина email
        /// </summary>
        public const int Email = 255;

        /// <summary>
        /// Максимальная длина телефона
        /// </summary>
        public const int Phone = 20;

        /// <summary>
        /// Максимальная длина предпочитаемого жанра
        /// </summary>
        public const int PreferredGenre = 100;
    }

    #endregion

    #region Photography

    public static class PhotographyClient
    {
        /// <summary>
        /// Максимальная длина поля "Имя"
        /// </summary>
        public const int FirstName = 100;

        /// <summary>
        /// Максимальная длина поля "Фамилия"
        /// </summary>
        public const int LastName = 100;

        /// <summary>
        /// Максимальная длина поля "Телефон"
        /// </summary>
        public const int Phone = 20;

        /// <summary>
        /// Максимальная длина поля "Email"
        /// </summary>
        public const int Email = 255;

        /// <summary>
        /// Максимальная длина поля "Комментарии"
        /// </summary>
        public const int Notes = 1000;
    }

    public static class PhotographyEquipment
    {
        /// <summary>
        /// Максимальная длина поля "Название"
        /// </summary>
        public const int Name = 200;

        /// <summary>
        /// Максимальная длина поля "Бренд"
        /// </summary>
        public const int Brand = 100;

        /// <summary>
        /// Максимальная длина поля "Модель"
        /// </summary>
        public const int Model = 100;

        /// <summary>
        /// Максимальная длина поля "Серийный номер"
        /// </summary>
        public const int SerialNumber = 50;

        /// <summary>
        /// Максимальная длина поля "Описание"
        /// </summary>
        public const int Description = 1000;

        /// <summary>
        /// Минимальная цена оборудования
        /// </summary>
        public const double MinPrice = 0.01;

        /// <summary>
        /// Максимальная цена оборудования
        /// </summary>
        public const double MaxPrice = 1000000.0;
    }

    public static class PhotographySession
    {
        /// <summary>
        /// Максимальная длина поля "Название"
        /// </summary>
        public const int Title = 200;

        /// <summary>
        /// Максимальная длина поля "Местоположение"
        /// </summary>
        public const int Location = 300;

        /// <summary>
        /// Максимальная длина поля "Имя фотографа"
        /// </summary>
        public const int PhotographerName = 100;

        /// <summary>
        /// Максимальная длина поля "Описание"
        /// </summary>
        public const int Description = 1000;

        /// <summary>
        /// Минимальная продолжительность фотосессии в минутах
        /// </summary>
        public const int MinDuration = 15;

        /// <summary>
        /// Максимальная продолжительность фотосессии в минутах
        /// </summary>
        public const int MaxDuration = 720; // 12 часов

        /// <summary>
        /// Минимальная стоимость фотосессии
        /// </summary>
        public const double MinPrice = 100.0;

        /// <summary>
        /// Максимальная стоимость фотосессии
        /// </summary>
        public const double MaxPrice = 100000.0;
    }

    #endregion

    #region CoffeeShop

    public static class Coffee
    {
        /// <summary>
        /// Максимальная длина названия кофе
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Максимальная длина описания кофе
        /// </summary>
        public const int Description = 500;

        /// <summary>
        /// Минимальная цена кофе
        /// </summary>
        public const double MinPrice = 0.01;

        /// <summary>
        /// Максимальная цена кофе
        /// </summary>
        public const double MaxPrice = 9999.99;

        /// <summary>
        /// Минимальный размер порции в мл
        /// </summary>
        public const int MinSize = 50;

        /// <summary>
        /// Максимальный размер порции в мл
        /// </summary>
        public const int MaxSize = 1000;

        /// <summary>
        /// Минимальное содержание кофеина в мг
        /// </summary>
        public const int MinCaffeine = 0;

        /// <summary>
        /// Максимальное содержание кофеина в мг
        /// </summary>
        public const int MaxCaffeine = 500;
    }

    public static class CoffeeShop
    {
        /// <summary>
        /// Максимальная длина названия кофейни
        /// </summary>
        public const int Name = 200;

        /// <summary>
        /// Максимальная длина адреса
        /// </summary>
        public const int Address = 500;

        /// <summary>
        /// Максимальная длина телефона
        /// </summary>
        public const int Phone = 20;

        /// <summary>
        /// Максимальная длина email
        /// </summary>
        public const int Email = 100;

        /// <summary>
        /// Максимальная длина времени работы
        /// </summary>
        public const int WorkingHours = 100;

        /// <summary>
        /// Минимальный рейтинг
        /// </summary>
        public const double MinRating = 0.0;

        /// <summary>
        /// Максимальный рейтинг
        /// </summary>
        public const double MaxRating = 5.0;
    }

    public static class Barista
    {
        /// <summary>
        /// Максимальная длина имени
        /// </summary>
        public const int FirstName = 100;

        /// <summary>
        /// Максимальная длина фамилии
        /// </summary>
        public const int LastName = 100;

        /// <summary>
        /// Максимальная длина телефона
        /// </summary>
        public const int Phone = 20;

        /// <summary>
        /// Максимальная длина email
        /// </summary>
        public const int Email = 100;

        /// <summary>
        /// Минимальный опыт работы в годах
        /// </summary>
        public const int MinExperience = 0;

        /// <summary>
        /// Максимальный опыт работы в годах
        /// </summary>
        public const int MaxExperience = 50;

        /// <summary>
        /// Максимальная длина специализации
        /// </summary>
        public const int Specialization = 200;

        /// <summary>
        /// Минимальная зарплата
        /// </summary>
        public const double MinSalary = 0;

        /// <summary>
        /// Максимальная зарплата
        /// </summary>
        public const double MaxSalary = 999999.99;
    }

    #endregion


    #region CarService

    public static class Car
    {
        public const int Brand = 50;

        public const int Model = 50;

        public const int MinYear = 1900;

        public const int MaxYear = 2025;

        public const int MinMileage = 0;

        public const int MaxMileage = 1000000;

        public const int Color = 50;

        public const int LicensePlate = 50;

        public const int VinNumber = 50;
    }

    public static class Owner
    {
        public const int FirstName = 50;

        public const int SecondName = 50;

        public const int PhoneNumber = 20;

        public const int Email = 50;

        public const int Address = 500;
    }

    public static class ServiceRecord
    {
        public const int CarLicensePlate = 50;

        public const int ServiceType = 100;

        public const int Description = 1000;

        public const int MechanicName = 100;

        public const int MinCost = 0;

        public const int MaxCost = 1000000;
    }


    #endregion

    #region PetShop

    public static class Pet
    {
        /// <summary>
        /// Максимальная длина клички
        /// </summary>
        public const int Name = 50;

        /// <summary>
        /// Максимальная длина породы
        /// </summary>
        public const int Breed = 100;

        /// <summary>
        /// Минимальный возраст в месяцах
        /// </summary>
        public const int AgeMin = 1;

        /// <summary>
        /// Максимальный возраст в месяцах
        /// </summary>
        public const int AgeMax = 300;

        /// <summary>
        /// Минимальная цена
        /// </summary>
        public const double PriceMin = 0.01;

        /// <summary>
        /// Максимальная цена
        /// </summary>
        public const double PriceMax = 1000000;

        /// <summary>
        /// Максимальная длина описания
        /// </summary>
        public const int Description = 1000;
    }

    public static class PetFood
    {
        /// <summary>
        /// Максимальная длина названия
        /// </summary>
        public const int Name = 200;

        /// <summary>
        /// Максимальная длина бренда
        /// </summary>
        public const int Brand = 100;

        /// <summary>
        /// Минимальный вес в граммах
        /// </summary>
        public const int WeightMin = 10;

        /// <summary>
        /// Максимальная длина описания блюда
        /// </summary>
        public const int Description = 1000;

        /// <summary>
        /// Максимальный вес в граммах
        /// </summary>
        public const int WeightMax = 50000;

        /// <summary>
        /// Минимальная цена
        /// </summary>
        public const double PriceMin = 0.01;

        /// <summary>
        /// Максимальная цена
        /// </summary>
        public const double PriceMax = 50000;

        /// <summary>
        /// Максимальная длина состава
        /// </summary>
        public const int Ingredients = 2000;

        /// <summary>
        /// Минимальное количество в наличии
        /// </summary>
        public const int StockMin = 0;

        /// <summary>
        /// Максимальное количество в наличии
        /// </summary>
        public const int StockMax = 10000;
    }

    public static class PetToy
    {
        /// <summary>
        /// Максимальная длина названия
        /// </summary>
        public const int Name = 200;

        /// <summary>
        /// Максимальная длина телефона клиента
        /// </summary>
        public const int CustomerPhone = 20;

        /// <summary>
        /// Максимальная длина цвета
        /// </summary>
        public const int Color = 50;

        /// <summary>
        /// Минимальная цена
        /// </summary>
        public const double PriceMin = 0.01;

        /// <summary>
        /// Максимальная цена
        /// </summary>
        public const double PriceMax = 10000;

        /// <summary>
        /// Максимальная длина описания
        /// </summary>
        public const int Description = 1000;

        /// <summary>
        /// Минимальное количество в наличии
        /// </summary>
        public const int StockMin = 0;

        /// <summary>
        /// Максимальное количество в наличии
        /// </summary>
        public const int StockMax = 1000;
    }


    #endregion

    #region Museum

    public static class MuseumExhibit
    {
        public const int Name = 100;
        public const int Description = 500;
        public const int Location = 100;
        public const int Status = 50;
        public const int MaxEstimatedValue = 1000000;
        public const int MinEstimatedValue = 0;
    }

    public static class MuseumExhibitDetails
    {
        public const int Origin = 200;
        public const int Creator = 100;
        public const int Material = 100;
        public const int Dimensions = 50;
        public const int HistoricalPeriod = 100;
        public const int Condition = 50;
        public const int MaxWeight = 1000000;
        public const int MinWeight = 0;
    }

    public static class MuseumVisitor
    {
        public const int FirstName = 100;
        public const int LastName = 100;
        public const int Email = 255;
        public const int Phone = 20;
        public const int TicketType = 50;
        public const double MinTicketPrice = 0;
        public const double MaxTicketPrice = 1000;
        public const int MembershipNumber = 50;
    }

    #endregion

    #region Pharmacy

    public static class PharmacyMedication
    {
        /// <summary>
        /// Максимальная длина названия медикамента
        /// </summary>
        public const int NameMaxLength = 100;

        /// <summary>
        /// Максимальная длина описания медикамента
        /// </summary>
        public const int DescriptionMaxLength = 500;

        /// <summary>
        /// Максимальная длина названия производителя
        /// </summary>
        public const int ManufacturerMaxLength = 100;

        /// <summary>
        /// Минимальная цена медикамента
        /// </summary>
        public const double MinPrice = 0.01;

        /// <summary>
        /// Максимальная цена медикамента
        /// </summary>
        public const double MaxPrice = 100000;

        /// <summary>
        /// Минимальное количество на складе
        /// </summary>
        public const int MinQuantity = 0;

        /// <summary>
        /// Максимальное количество на складе
        /// </summary>
        public const int MaxQuantity = 10000;
    }

    public static class PharmacyCustomer
    {
        /// <summary>
        /// Максимальная длина имени клиента
        /// </summary>
        public const int FirstNameMaxLength = 50;

        /// <summary>
        /// Максимальная длина фамилии клиента
        /// </summary>
        public const int LastNameMaxLength = 50;

        /// <summary>
        /// Максимальная длина номера телефона
        /// </summary>
        public const int PhoneMaxLength = 15;

        /// <summary>
        /// Максимальная длина адреса электронной почты
        /// </summary>
        public const int EmailMaxLength = 100;

        /// <summary>
        /// Максимальная длина адреса
        /// </summary>
        public const int AddressMaxLength = 200;
    }

    public static class Prescription
    {
        /// <summary>
        /// Максимальная длина номера рецепта
        /// </summary>
        public const int NumberMaxLength = 20;

        /// <summary>
        /// Максимальная длина имени врача
        /// </summary>
        public const int DoctorNameMaxLength = 100;

        /// <summary>
        /// Минимальное количество единиц
        /// </summary>
        public const int MinDosage = 1;

        /// <summary>
        /// Максимальное количество единиц
        /// </summary>
        public const int MaxDosage = 100;

        /// <summary>
        /// Максимальная длина инструкций по применению
        /// </summary>
        public const int InstructionsMaxLength = 300;
    }

    #endregion

    #region CarDealership

    public static class CarDealershipCustomer
    {
        /// <summary>
        /// Максимальная длина поля "Имя"
        /// </summary>
        public const int FirstName = 100;

        /// <summary>
        /// Максимальная длина поля "Фамилия"
        /// </summary>
        public const int LastName = 100;

        /// <summary>
        /// Максимальная длина поля "Email"
        /// </summary>
        public const int Email = 255;

        /// <summary>
        /// Максимальная длина поля "Телефон"
        /// </summary>
        public const int Phone = 20;

        /// <summary>
        /// Максимальная длина поля "Адрес"
        /// </summary>
        public const int Address = 500;

        /// <summary>
        /// Максимальная длина поля "Номер паспорта"
        /// </summary>
        public const int PassportNumber = 20;
    }

    public static class Vehicle
    {
        /// <summary>
        /// Максимальная длина поля "Марка"
        /// </summary>
        public const int Brand = 100;

        /// <summary>
        /// Максимальная длина поля "Модель"
        /// </summary>
        public const int Model = 100;

        /// <summary>
        /// Максимальная длина поля "Цвет"
        /// </summary>
        public const int Color = 50;

        /// <summary>
        /// Максимальная длина поля "VIN номер"
        /// </summary>
        public const int VinNumber = 50;

        /// <summary>
        /// Минимальный год выпуска
        /// </summary>
        public const int MinYear = 1900;

        /// <summary>
        /// Максимальный год выпуска
        /// </summary>
        public const int MaxYear = 2030;

        /// <summary>
        /// Минимальная цена
        /// </summary>
        public const double MinPrice = 0;

        /// <summary>
        /// Максимальная цена
        /// </summary>
        public const double MaxPrice = 10000000;

        /// <summary>
        /// Минимальный пробег
        /// </summary>
        public const int MinMileage = 0;

        /// <summary>
        /// Максимальный пробег
        /// </summary>
        public const int MaxMileage = 1000000;
    }

    public static class CarDealershipSale
    {
        /// <summary>
        /// Минимальная сумма скидки
        /// </summary>
        public const double MinDiscount = 0;

        /// <summary>
        /// Максимальная сумма скидки
        /// </summary>
        public const double MaxDiscount = 100000;

        /// <summary>
        /// Минимальная итоговая цена
        /// </summary>
        public const double MinFinalPrice = 0;

        /// <summary>
        /// Максимальная итоговая цена
        /// </summary>
        public const double MaxFinalPrice = 10000000;
    }

    public static class Driver
    {
        /// <summary>
        /// Максимальная длина поля "Имя гонщика"
        /// </summary>
        public const int Name = 255;

        /// <summary>
        /// Минимальное значение возраста
        /// </summary>
        public const int AgeMin = 1;

        /// <summary>
        /// Максимальное значение возраста
        /// </summary>
        public const int AgeMax = 100;

        /// <summary>
        /// Максимальная длина поля "Страна происхождения"
        /// </summary>
        public const int CountryOfOrigin = 255;
    }

    public class GrandPrix
    {
        /// <summary>
        /// Максимальная длина поля "Название гран-при"
        /// </summary>
        public const int Name = 255;

        /// <summary>
        /// Максимальная длина поля "Имя победителя"
        /// </summary>
        public const int Winner = 100;

        /// <summary>
        /// Максимальная длина поля "Название трассы"
        /// </summary>
        public const int Circuit = 255;
    }

    public class Team
    {
        /// <summary>
        /// Максимальная длина поля "Название команды"
        /// </summary>
        public const int Name = 100;

        /// <summary>
        /// Минимальный год создания команды
        /// </summary>
        public const int MinYearOfCreation = 1930;

        /// <summary>
        /// Максимальный год создания команды
        /// </summary>
        public const int MaxYearOfCreation = 2025;

        /// <summary>
        /// Максимальная длина поля "Поставщик двигателей для команды"
        /// </summary>
        public const int EngineSupplier = 255;
    }

    public class DriverGrandPrix
    {
        /// <summary>
        /// Минимальное значение для поля "Место по результатам гонки"
        /// </summary>
        public const int MinPosition = 1;

        /// <summary>
        /// Максимальное значение для поля "Место по результатам гонки"
        /// </summary>
        public const int MaxPosition = 20;

        /// <summary>
        /// Минимальное значение для поля "Количество заработаннных в гонке очков"
        /// </summary>
        public const int MinPointsEarned = 0;

        /// <summary>
        /// Максимальное значение для поля "Количество заработаннных в гонке очков"
        /// </summary>
        public const int MaxPointsEarned = 25;
    }

    #endregion

    #region AsianComics

    public static class AsianComicsConstants
    {
        /// <summary>
        /// Максимальная длина поля "Названия"
        /// </summary>
        public const int Title = 255;

        /// <summary>
        /// Минимальное значение года
        /// </summary>
        public const int MinYear = 1800;

        /// <summary>
        /// Максимальное значение года
        /// </summary>
        public const int MaxYear = 2025;

    }

    #endregion


    public static class CyberSport
    {
        /// <summary>
        /// Минимально допустимое количество очков для прохождения в след. этап.
        /// </summary>
        public const int MinPointsValue = 100;

        /// <summary>
        /// Максимально допустимое количество очков для прохождения в след. этап.
        /// </summary>
        public const int MaxPointsValue = 900;
    }

    public static class Chessclub
    {
        /// <summary>
        /// Минимально допустимое количество участников.
        /// </summary>
        public const int MinPersonValue = 2;

        /// <summary>
        /// Максимально допустимое количество участников.
        /// </summary>
        public const int MaxPersonValue = 100;
    }
}