namespace Study.Lab3.Web.Features.Museum.MuseumExhibits.DtoModels;

public sealed record MuseumExhibitDto
{
    /// <summary>
    /// Идентификатор экспоната
    /// </summary>
    public Guid IsnMuseumExhibit { get; init; }

    /// <summary>
    /// Название экспоната
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Описание экспоната
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Дата приобретения
    /// </summary>
    public DateTime AcquisitionDate { get; init; }

    /// <summary>
    /// Оценочная стоимость
    /// </summary>
    public double EstimatedValue { get; init; }

    /// <summary>
    /// Местоположение в музее
    /// </summary>
    public string Location { get; init; }

    /// <summary>
    /// Статус экспоната
    /// </summary>
    public string Status { get; init; }
}
