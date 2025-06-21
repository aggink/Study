using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Storage.Models.AsianComics;

/// <summary>
/// манга
/// </summary>
public class Manga
{
    /// <summary>
    /// Идентификатор манги
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnBook { get; set; }

    /// <summary>
    /// Название манги
    /// </summary>
    [Required, MaxLength(ModelConstants.AsianComicsConstants.Title)]
    public string Title { get; set; }

    /// <summary>
    /// Год издания
    /// </summary>
    [Required, Range(ModelConstants.AsianComicsConstants.MinYear, ModelConstants.AsianComicsConstants.MaxYear)]
    public int PublicationYear { get; set; }
}
