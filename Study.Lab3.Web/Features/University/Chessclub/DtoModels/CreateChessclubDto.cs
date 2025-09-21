using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Chessclub.DtoModels;

public sealed record CreateChessclubDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Идентификатор соревнований
    /// </summary>
    [Required]
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    [Required]
    [Range(ModelConstants.Chessclub.MinPersonValue, ModelConstants.Chessclub.MaxPersonValue)]
    public int ParticipantsPip { get; init; }

    /// <summary>
    /// Дата соревнований
    /// </summary>
    [Required]
    public DateTime ChessclubDate { get; init; }
}