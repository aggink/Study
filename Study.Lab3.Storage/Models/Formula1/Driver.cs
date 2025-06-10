using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Formula1;

/// <summary>
/// Гонщик
/// </summary>
[Index(nameof(IsnTeam))]
public class Driver
{

    /// <summary>
    /// Идентификатор гонщика
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnDriver { get; set; }

    /// <summary>
    /// Идентификатор гран-при
    /// </summary>
    [ForeignKey(nameof(Team))]
    public Guid IsnTeam { get; set; }

    /// <summary>
    /// Имя гонщика
    /// </summary>
    [Required, MaxLength(ModelConstants.Driver.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Возраст
    /// </summary>
    [Required, Range(ModelConstants.Driver.AgeMin, ModelConstants.Driver.AgeMax)]
    public int Age { get; set; }

    /// <summary>
    /// Страна происхождения
    /// </summary>
    [MaxLength(ModelConstants.Driver.CountryOfOrigin)]
    public string CountryOfOrigin { get; set; }

    /// <summary>
    /// Гран-при
    /// </summary>
    public virtual GrandPrix GrandPrix { get; set; }
    /// <summary>
    /// Команда
    /// </summary>
    public virtual Team Team { get; set; }
    /// <summary>
    /// Связь с таблицей гонщики-гран-при
    /// </summary>
    [InverseProperty(nameof(DriverGrandPrix.Driver))]
    public virtual DriverGrandPrix GrandPrixDrivers { get; set; }
}
