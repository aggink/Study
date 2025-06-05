namespace Study.Lab3.Web.Features.Workshop.Masters.DtoModels;

public sealed record MasterDto
{
    /// <summary>
    /// Идентификатор мастера
    /// </summary>
    public Guid IsnMaster { get; init; }

    /// <summary>
    /// Имя мастера
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Email мастера
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Телефон мастера
    /// </summary>
    public string Phone { get; init; }

    /// <summary>
    /// Специализация мастера
    /// </summary>
    public string Specialization { get; init; }
}
