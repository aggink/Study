using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Order.DtoModels;

/// <summary>
/// DTO для создания заказа
/// </summary>
public sealed record CreateHospitalStoreOrderDto
{
    /// <summary>
    /// Идентификатор пациента
    /// </summary>
    [Required]
    public Guid IsnPatient { get; init; }

    /// <summary>
    /// Идентификатор товара
    /// </summary>
    [Required]
    public Guid IsnProduct { get; init; }

    /// <summary>
    /// Количество
    /// </summary>
    [Required]
    [Range(ModelConstants.Order.QuantityMin, ModelConstants.Order.QuantityMax)]
    public int Quantity { get; init; }
}
