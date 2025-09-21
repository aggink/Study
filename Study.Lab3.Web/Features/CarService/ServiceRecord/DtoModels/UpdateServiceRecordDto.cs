using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.CarService.ServiceRecord.DtoModels;

public sealed record UpdateServiceRecordDto
{
    /// <summary>
    /// Идентификатор записи обслуживания
    /// </summary>
    [Required]
    public Guid IsnServiceRecord { get; init; }
 
    /// <summary>
    /// Государственный номер автомобиля
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.ServiceRecord.CarLicensePlate)]
    public string CarLicensePlate { get; init; }
 
    /// <summary>
    /// Дата обслуживания
    /// </summary>
    [Required]
    public DateTime ServiceDate { get; init; }
 
    /// <summary>
    /// Тип обслуживания
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.ServiceRecord.ServiceType)]
    public string ServiceType { get; init; }
 
    /// <summary>
    /// Описание выполненных работ
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.ServiceRecord.Description)]
    public string Description { get; init; }
 
    /// <summary>
    /// Имя механика
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.ServiceRecord.MechanicName)]
    public string MechanicName { get; init; }
 
    /// <summary>
    /// Стоимость работ
    /// </summary>
    [Required]
    [Range(0, double.MaxValue)]
    public double Cost { get; init; }
 
    /// <summary>
    /// Статус выполнения
    /// </summary>
    [Required]
    public bool IsCompleted { get; init; }
}