namespace Study.Lab3.Web.Features.University.ExamResults.DtoModels;

public sealed record ExamResultDto
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