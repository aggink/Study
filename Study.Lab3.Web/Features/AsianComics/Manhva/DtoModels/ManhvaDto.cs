namespace Study.Lab3.Web.Features.AsianComics.Manhva.DtoModels;

public sealed record ManhvaDto
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
