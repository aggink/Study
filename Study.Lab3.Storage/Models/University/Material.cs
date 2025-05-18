using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Учебный материал
/// </summary>
public class Material
{
    /// <summary>
    /// Идентификатор материала
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnMaterial { get; set; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [ForeignKey(nameof(Subject))]
    public Guid IsnSubject { get; set; }

    /// <summary>
    /// Название материала
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Material.Title)]
    public string Title { get; set; }

    /// <summary>
    /// Описание материала
    /// </summary>
    [MaxLength(ModelConstants.Material.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Тип материала
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Material.Type)]
    public string Type { get; set; }

    /// <summary>
    /// URL материала
    /// </summary>
    [Required]
    public string Url { get; set; }

    /// <summary>
    /// Дата публикации
    /// </summary>
    [DataType(DataType.DateTime)]
    public DateTime PublishDate { get; set; }

    /// <summary>
    /// Предмет
    /// </summary>
    public virtual Subject Subject { get; set; }
}