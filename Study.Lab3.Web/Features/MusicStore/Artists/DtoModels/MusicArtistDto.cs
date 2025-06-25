using Study.Lab3.Storage.Enums.MusicStore;

namespace Study.Lab3.Web.Features.MusicStore.Artists.DtoModels;

public sealed record MusicArtistDto
{
    /// <summary>
    /// Идентификатор исполнителя
    /// </summary>
    public Guid IsnArtist { get; init; }

    /// <summary>
    /// Имя исполнителя
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Страна происхождения
    /// </summary>
    public string Country { get; init; }

    /// <summary>
    /// Год рождения/основания
    /// </summary>
    public int? BirthYear { get; init; }

    /// <summary>
    /// Основной жанр
    /// </summary>
    public string Genre { get; init; }

    /// <summary>
    /// Тип исполнителя
    /// </summary>
    public ArtistType ArtistType { get; init; }

    /// <summary>
    /// Краткое описание
    /// </summary>
    public string Biography { get; init; }

    /// <summary>
    /// Дата добавления в систему
    /// </summary>
    public DateTime CreatedDate { get; init; }
}
