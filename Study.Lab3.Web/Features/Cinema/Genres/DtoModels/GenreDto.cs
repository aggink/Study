namespace Study.Lab3.Web.Features.Cinema.Genres.DtoModels;

public sealed record GenreDto
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    public Guid IsnGenre { get; init; }

    /// <summary>
    /// Название жанра
    /// </summary>
    public string Name { get; init; }
}