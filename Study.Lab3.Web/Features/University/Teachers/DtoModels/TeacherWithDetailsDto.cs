using Study.Lab3.Storage.Enums.University;

public sealed record TeacherWithDetailsDto
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    public Guid IsnTeacher { get; init; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string SurName { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string PatronymicName { get; init; }

    /// <summary>
    /// Пол
    /// </summary>
    public SexType Sex { get; init; }

    /// <summary>
    /// Количество предметов
    /// </summary>
    public int SubjectsCount { get; init; }

    /// <summary>
    /// Количество студентов
    /// </summary>
    public int StudentsCount { get; init; }

    /// <summary>
    /// Средняя оценка по всем предметам
    /// </summary>
    public double AverageGrade { get; init; }
}