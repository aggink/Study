using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.MusicStore.Albums.DtoModels;

public sealed record UpdateMusicAlbumDto
{
    /// <summary>
    /// Идентификатор альбома
    /// </summary>
    [Required]
    public Guid IsnAlbum { get; init; }

    /// <summary>
    /// Название альбома
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicAlbum.Title)]
    public string Title { get; init; }

    /// <summary>
    /// Жанр
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicAlbum.Genre)]
    public string Genre { get; init; }

    /// <summary>
    /// Год выпуска
    /// </summary>
    [Required]
    [Range(ModelConstants.MusicAlbum.MinReleaseYear, ModelConstants.MusicAlbum.MaxReleaseYear)]
    public int ReleaseYear { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    [Required]
    [Range(ModelConstants.MusicAlbum.MinPrice, ModelConstants.MusicAlbum.MaxPrice)]
    public double Price { get; init; }

    /// <summary>
    /// Продолжительность в минутах
    /// </summary>
    [Required]
    [Range(ModelConstants.MusicAlbum.MinDuration, ModelConstants.MusicAlbum.MaxDuration)]
    public int Duration { get; init; }
}
