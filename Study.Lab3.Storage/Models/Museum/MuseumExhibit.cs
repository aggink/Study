using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Museum;

/// <summary>
/// Экспонат музея
/// </summary>
public class MuseumExhibit
{
    /// <summary>
    /// Идентификатор экспоната
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnMuseumExhibit { get; set; }

    /// <summary>
    /// Название экспоната
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MuseumExhibit.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Описание экспоната
    /// </summary>
    [MaxLength(ModelConstants.MuseumExhibit.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Дата приобретения
    /// </summary>
    [Required]
    public DateTime AcquisitionDate { get; set; }

    /// <summary>
    /// Оценочная стоимость
    /// </summary>
    [Range(ModelConstants.MuseumExhibit.MinEstimatedValue, ModelConstants.MuseumExhibit.MaxEstimatedValue)]
    public double EstimatedValue { get; set; }

    /// <summary>
    /// Местоположение в музее
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MuseumExhibit.Location)]
    public string Location { get; set; }

    /// <summary>
    /// Статус экспоната (выставлен, в хранилище, на реставрации)
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MuseumExhibit.Status)]
    public string Status { get; set; }

    /// <summary>
    /// Детальная информация об экспонате
    /// </summary>
    [InverseProperty(nameof(MuseumExhibitDetails.Exhibit))]
    public virtual MuseumExhibitDetails Details { get; set; }
}