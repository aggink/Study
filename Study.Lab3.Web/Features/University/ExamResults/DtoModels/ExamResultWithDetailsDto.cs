namespace Study.Lab3.Web.Features.University.ExamResults.DtoModels;

public sealed record ExamResultWithDetailsDto
{
    /// <summary>
    /// Идентификатор результата
    /// </summary>
    public Guid IsnExamResult { get; init; }

    /// <summary>
    /// Идентификатор регистрации на экзамен
    /// </summary>
    public Guid IsnExamRegistration { get; init; }

    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    public Guid IsnExam { get; init; }

    /// <summary>
    /// Название экзамена
    /// </summary>
    public string ExamName { get; init; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// ФИО студента
    /// </summary>
    public string StudentFullName { get; init; }

    /// <summary>
    /// Дата экзамена
    /// </summary>
    public DateTime ExamDate { get; init; }

    /// <summary>
    /// Максимальный балл
    /// </summary>
    public int MaxScore { get; init; }

    /// <summary>
    /// Проходной балл
    /// </summary>
    public int PassingScore { get; init; }

    /// <summary>
    /// Полученный балл
    /// </summary>
    public int Score { get; init; }

    /// <summary>
    /// Успешная сдача экзамена
    /// </summary>
    public bool IsPassed { get; init; }

    /// <summary>
    /// Комментарии к результату
    /// </summary>
    public string Comments { get; init; }
}