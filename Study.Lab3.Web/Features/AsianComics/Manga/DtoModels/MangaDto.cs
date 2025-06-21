namespace Study.Lab3.Web.Features.AsianComics.Manga.DtoModels;

public sealed record MangaDto
{
    /// <summary>
    /// ������������� �����
    /// </summary>
    public Guid IsnBook { get; init; }

    /// <summary>
    /// �������� �����
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// ��� �������
    /// </summary>
    public int PublicationYear { get; init; }
}
