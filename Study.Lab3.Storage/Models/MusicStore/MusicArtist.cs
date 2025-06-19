using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.MusicStore;

namespace Study.Lab3.Storage.Models.MusicStore;

/// <summary>
/// Музыкальный исполнитель
/// </summary>
public class MusicArtist
{
    /// <summary>
    /// Идентификатор исполнителя
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnArtist { get; set; }

    /// <summary>
    /// Имя исполнителя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicArtist.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Страна происхождения
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicArtist.Country)]
    public string Country { get; set; }

    /// <summary>
    /// Год рождения/основания
    /// </summary>
    [Range(ModelConstants.MusicArtist.MinBirthYear, ModelConstants.MusicArtist.MaxBirthYear)]
    public int? BirthYear { get; set; }

    /// <summary>
    /// Основной жанр
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicArtist.Genre)]
    public string Genre { get; set; }

    /// <summary>
    /// Тип исполнителя
    /// </summary>
    [Required]
    public ArtistType ArtistType { get; set; }

    /// <summary>
    /// Краткое описание
    /// </summary>
    [MaxLength(ModelConstants.MusicArtist.Biography)]
    public string Biography { get; set; }

    /// <summary>
    /// Дата добавления в систему
    /// </summary>
    [Required]
    public DateTime CreatedDate { get; set; }
}