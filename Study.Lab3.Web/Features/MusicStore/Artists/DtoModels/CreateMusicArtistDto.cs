using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.MusicStore;

namespace Study.Lab3.Web.Features.MusicStore.Artists.DtoModels;

public sealed record CreateMusicArtistDto
{
    /// <summary>
    /// Имя исполнителя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicArtist.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Страна происхождения
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicArtist.Country)]
    public string Country { get; init; }

    /// <summary>
    /// Год рождения/основания
    /// </summary>
    [Range(ModelConstants.MusicArtist.MinBirthYear, ModelConstants.MusicArtist.MaxBirthYear)]
    public int? BirthYear { get; init; }

    /// <summary>
    /// Основной жанр
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicArtist.Genre)]
    public string Genre { get; init; }

    /// <summary>
    /// Тип исполнителя
    /// </summary>
    [Required]
    public ArtistType ArtistType { get; init; }

    /// <summary>
    /// Краткое описание
    /// </summary>
    [MaxLength(ModelConstants.MusicArtist.Biography)]
    public string Biography { get; init; }
}
