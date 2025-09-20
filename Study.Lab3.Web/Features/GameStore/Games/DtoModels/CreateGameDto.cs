using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.GameStore.Games.DtoModels;

/// <summary>
/// DTO для создания игры
/// </summary>
public sealed record CreateGameDto
{
    /// <summary>
    /// Идентификатор разработчика
    /// </summary>
    public Guid? IsnDeveloper { get; init; }

    /// <summary>
    /// Название игры
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Game.Title)]
    public string Title { get; init; }

    /// <summary>
    /// Описание игры
    /// </summary>
    [MaxLength(ModelConstants.Game.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    [Required]
    [Range(ModelConstants.Game.MinPrice, ModelConstants.Game.MaxPrice)]
    public double Price { get; init; }

    /// <summary>
    /// Дата выхода
    /// </summary>
    [Required]
    public DateTime ReleaseDate { get; init; }

    /// <summary>
    /// Жанр
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Game.Genre)]
    public string Genre { get; init; }

    /// <summary>
    /// Возрастной рейтинг
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Game.AgeRating)]
    public string AgeRating { get; init; }

    /// <summary>
    /// Активна ли игра в продаже
    /// </summary>
    public bool IsActive { get; init; } = true;
}