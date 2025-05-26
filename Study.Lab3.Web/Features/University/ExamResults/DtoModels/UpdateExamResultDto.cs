/*using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamResults.DtoModels;

public sealed record UpdateExamResultDto
{
    /// <summary>
    /// Идентификатор результата
    /// </summary>
    [Required]
    public Guid IsnExamResult { get; init; }
    
    /// <summary>
    /// Полученный балл
    /// </summary>
    [Required]
    [Range(ModelConstants.ExamResult.MinScore, ModelConstants.ExamResult.MaxScore)]
    public int Score { get; init; }
    
    /// <summary>
    /// Комментарии к результату
    /// </summary>
    [MaxLength(ModelConstants.ExamResult.Comments)]
    public string Comments { get; init; }
}*/