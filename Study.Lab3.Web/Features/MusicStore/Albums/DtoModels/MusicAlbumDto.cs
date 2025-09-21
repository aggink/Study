namespace Study.Lab3.Web.Features.MusicStore.Albums.DtoModels;

public sealed record MusicAlbumDto
{
    /// <summary>
    /// Идентификатор альбома
    /// </summary>
    public Guid IsnAlbum { get; init; }

    /// <summary>
    /// Название альбома
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// Жанр
    /// </summary>
    public string Genre { get; init; }

    /// <summary>
    /// Год выпуска
    /// </summary>
    public int ReleaseYear { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; init; }

    /// <summary>
    /// Продолжительность в минутах
    /// </summary>
    public int Duration { get; init; }

    /// <summary>
    /// Дата добавления в каталог
    /// </summary>
    public DateTime CreatedDate { get; init; }
}
