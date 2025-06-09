using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Лаба
/// </summary>
public class Labs
{
    /// <summary>
    /// Идентификатор лабы
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnLab { get; set; }

    /// <summary>
    /// Наименование лабы
    /// </summary>
    [Required, MaxLength(ModelConstants.Labs.Name)]
    public string Name { get; set; }
}