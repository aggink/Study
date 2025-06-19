namespace Study.Lab3.Web.Features.CarService.ServiceRecord.DtoModels;

public sealed record ServiceRecordDto
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public Guid IsnServiceRecord { get; init; }
 
    /// <summary>
    /// Государственный номер автомобиля
    /// </summary>
    public string CarLicensePlate { get; init; }
 
    /// <summary>
    /// Дата обслуживания
    /// </summary>
    public DateTime ServiceDate { get; init; }
 
    /// <summary>
    /// Тип обслуживания
    /// </summary>
    public string ServiceType { get; init; }
 
    /// <summary>
    /// Описание выполненных работ
    /// </summary>
    public string Description { get; init; }
 
    /// <summary>
    /// Имя механика
    /// </summary>
    public string MechanicName { get; init; }
 
    /// <summary>
    /// Стоимость работ
    /// </summary>
    public double Cost { get; init; }
 
    /// <summary>
    /// Статус выполнения
    /// </summary>
    public bool IsCompleted { get; init; }
}