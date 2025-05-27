using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Genres.DtoModels;

public sealed record CreateGenreDto
{
    /// <summary>
    /// Название жанра
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Genre.Name)]
    public string Name { get; init; }
}