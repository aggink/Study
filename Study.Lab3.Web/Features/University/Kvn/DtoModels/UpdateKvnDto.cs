using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace Study.Lab3.Web.Features.University.TheKvn.DtoModels;
=======
namespace Study.Lab3.Web.Features.University.Kvn.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

public sealed record UpdateKvnDto
{
    /// <summary>
    /// Идентификатор квн
    /// </summary>
    [Required]
    public Guid IsnKvn { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    [Required]
    [Range(ModelConstants.Kvn.MinPart, ModelConstants.Kvn.MaxPart)]
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата проведения выступления
    /// </summary>
    [Required]
    public DateTime KvnDate { get; init; }
}