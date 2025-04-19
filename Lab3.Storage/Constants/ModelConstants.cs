﻿namespace Study.Lab3.Storage.Constants;

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
}
