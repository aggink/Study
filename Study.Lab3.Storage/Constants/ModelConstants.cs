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
    }

    public static class Customer
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
        public const int Number = 15;

        /// <summary>
        /// Максимальная длина email клиента
        /// </summary>
        public const int Email = 255;
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
}

