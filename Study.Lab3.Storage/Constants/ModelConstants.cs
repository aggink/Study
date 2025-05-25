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

}