using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Storage.Models.AsianComics;

/// <summary>
/// маньхуа
/// </summary>
public class Manhua
{
    /// <summary>
    /// Идентификатор маньхуа
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnBook { get; set; }

    /// <summary>
    /// Название маньхуа
    /// </summary>
    [Required, MaxLength(ModelConstants.AsianComicsConstants.Title)]
    public string Title { get; set; }

    /// <summary>
    /// Год издания
    /// </summary>
    [Required, Range(ModelConstants.AsianComicsConstants.MinYear, ModelConstants.AsianComicsConstants.MaxYear)]
    public int PublicationYear { get; set; }
}
