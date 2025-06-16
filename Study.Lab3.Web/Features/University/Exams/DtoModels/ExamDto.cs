namespace Study.Lab3.Web.Features.University.Exams.DtoModels;

public sealed record ExamDto
{
    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    public Guid IsnExam { get; init; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Название экзамена
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Описание экзамена
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Дата проведения экзамена
    /// </summary>
    public DateTime ExamDate { get; init; }

    /// <summary>
    /// Продолжительность экзамена в минутах
    /// </summary>
    public int Duration { get; init; }

    /// <summary>
    /// Максимальный балл
    /// </summary>
    public int MaxScore { get; init; }

    /// <summary>
    /// Проходной балл
    /// </summary>
    public int PassingScore { get; init; }
}