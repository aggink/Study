using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Museum;

/// <summary>
/// Детальная информация об экспонате
/// </summary>
public class MuseumExhibitDetails
{
    /// <summary>
    /// Идентификатор деталей экспоната
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnMuseumExhibitDetails { get; set; }

    /// <summary>
    /// Идентификатор экспоната (внешний ключ)
    /// </summary>
    [Required]
    [ForeignKey(nameof(Exhibit))]
    public Guid IsnMuseumExhibit { get; set; }

    /// <summary>
    /// Происхождение экспоната
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibitDetails.Origin)]
    public string Origin { get; set; }

    /// <summary>
    /// Создатель/Автор
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibitDetails.Creator)]
    public string Creator { get; set; }

    /// <summary>
    /// Год создания
    /// </summary>
    public int? CreationYear { get; set; }

    /// <summary>
    /// Материал изготовления
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibitDetails.Material)]
    public string Material { get; set; }

    /// <summary>
    /// Размеры (высота x ширина x глубина)
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibitDetails.Dimensions)]
    public string Dimensions { get; set; }

    /// <summary>
    /// Вес в килограммах
    /// </summary>
    [Range(ModelConstants.MuseumExhibitDetails.MinWeight, ModelConstants.MuseumExhibitDetails.MaxWeight)]
    public double? Weight { get; set; }

    /// <summary>
    /// Историческая эпоха
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibitDetails.HistoricalPeriod)]
    public string HistoricalPeriod { get; set; }

    /// <summary>
    /// Состояние сохранности
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibitDetails.Condition)]
    public string Condition { get; set; }

    /// <summary>
    /// Связанный экспонат
    /// </summary>
    public virtual MuseumExhibit Exhibit { get; set; }
}