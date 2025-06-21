namespace Study.Lab3.Web.Features.AsianComics.Manhua.DtoModels;

public sealed record ManhuaDto
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
