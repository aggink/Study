namespace Study.Lab3.Storage.Constants;

/// <summary>
/// Ограничения для моделей
/// </summary>
public static class ModelConstants
{
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
}