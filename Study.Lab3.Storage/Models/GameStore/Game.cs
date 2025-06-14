using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.GameStore;

/// <summary>
/// Игра
/// </summary>
public class Game
{
    /// <summary>
    /// Идентификатор игры
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnGame { get; set; }

    /// <summary>
    /// Идентификатор разработчика
    /// </summary>
    [ForeignKey(nameof(Developer))]
    public Guid? IsnDeveloper { get; set; }

    /// <summary>
    /// Название игры
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Game.Title)]
    public string Title { get; set; }

    /// <summary>
    /// Описание игры
    /// </summary>
    [MaxLength(ModelConstants.Game.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    [Required]
    [Range(ModelConstants.Game.MinPrice, ModelConstants.Game.MaxPrice)]
    public double Price { get; set; }

    /// <summary>
    /// Дата выхода
    /// </summary>
    [Required]
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Жанр
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Game.Genre)]
    public string Genre { get; set; }

    /// <summary>
    /// Возрастной рейтинг
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Game.AgeRating)]
    public string AgeRating { get; set; }

    /// <summary>
    /// Активна ли игра в продаже
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Разработчик игры
    /// </summary>
    public virtual Developer Developer { get; set; }
}