using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Chessclub.DtoModels;

public sealed record UpdateChessclubDto
{
    /// <summary>
    /// Идентификатор шахматного клуба
    /// </summary>
    [Required]
    public Guid IsnChessclub { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    [Required]
    [Range(ModelConstants.Chessclub.MinPersonValue, ModelConstants.Chessclub.MaxPersonValue)]
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата проведения соревнований
    /// </summary>
    [Required]
    public DateTime ChessclubDate { get; init; }
}