using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.BeautySalon;

/// <summary>
/// Услуга салона красоты
/// </summary>
public class BeautyService
{
    /// <summary>
    /// ID услуги 
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnService { get; set; }

    /// <summary>
    /// Название услуги
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyService.ServiceName)]
    public string ServiceName { get; set; }

    /// <summary>
    /// Описание услуги
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyService.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Цена услуги
    /// </summary>
    [Required, Range(ModelConstants.BeautyService.MinServicePrice, ModelConstants.BeautyService.MaxServicePrice)]
    public int Price { get; set; }

    /// <summary>
    /// Длительность услуги
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyService.Duration)]
    public int Duration { get; set; }
}
