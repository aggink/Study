using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.MusicStore;

/// <summary>
/// Музыкальный альбом
/// </summary>
public class MusicAlbum
{
    /// <summary>
    /// Идентификатор альбома
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnAlbum { get; set; }

    /// <summary>
    /// Название альбома
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicAlbum.Title)]
    public string Title { get; set; }

    /// <summary>
    /// Жанр
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicAlbum.Genre)]
    public string Genre { get; set; }

    /// <summary>
    /// Год выпуска
    /// </summary>
    [Required]
    [Range(ModelConstants.MusicAlbum.MinReleaseYear, ModelConstants.MusicAlbum.MaxReleaseYear)]
    public int ReleaseYear { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    [Required]
    [Range(ModelConstants.MusicAlbum.MinPrice, ModelConstants.MusicAlbum.MaxPrice)]
    public double Price { get; set; }

    /// <summary>
    /// Продолжительность в минутах
    /// </summary>
    [Required]
    [Range(ModelConstants.MusicAlbum.MinDuration, ModelConstants.MusicAlbum.MaxDuration)]
    public int Duration { get; set; }

    /// <summary>
    /// Дата добавления в каталог
    /// </summary>
    [Required]
    public DateTime CreatedDate { get; set; }
}