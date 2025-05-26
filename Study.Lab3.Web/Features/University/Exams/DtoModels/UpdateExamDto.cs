/*using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Exams.DtoModels;

public sealed record UpdateExamDto
{
    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    [Required]
    public Guid IsnExam { get; init; }

    /// <summary>
    /// Название экзамена
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Exam.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Описание экзамена
    /// </summary>
    [MaxLength(ModelConstants.Exam.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Дата проведения экзамена
    /// </summary>
    [Required]
    public DateTime ExamDate { get; init; }

    /// <summary>
    /// Продолжительность экзамена в минутах
    /// </summary>
    [Required]
    [Range(ModelConstants.Exam.MinDuration, ModelConstants.Exam.MaxDuration)]
    public int Duration { get; init; }

    /// <summary>
    /// Максимальный балл
    /// </summary>
    [Required]
    [Range(ModelConstants.Exam.MinScore, ModelConstants.Exam.MaxScore)]
    public int MaxScore { get; init; }

    /// <summary>
    /// Проходной балл
    /// </summary>
    [Required]
    [Range(ModelConstants.Exam.MinScore, ModelConstants.Exam.MaxScore)]
    public int PassingScore { get; init; }
}*/