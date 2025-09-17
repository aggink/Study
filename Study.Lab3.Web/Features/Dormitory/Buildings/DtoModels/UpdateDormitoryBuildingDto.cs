using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Dormitory.Buildings.DtoModels;

public sealed record UpdateDormitoryBuildingDto
{
    /// <summary>
    /// Название здания
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Адрес здания
    /// </summary>
    [Required]
    [StringLength(200)]
    public string Address { get; init; } = string.Empty;

    /// <summary>
    /// Количество этажей
    /// </summary>
    [Range(1, 50)]
    public int FloorsCount { get; init; }

    /// <summary>
    /// Общее количество комнат
    /// </summary>
    [Range(1, 1000)]
    public int TotalRooms { get; init; }

    /// <summary>
    /// Год постройки
    /// </summary>
    [Range(1900, 2100)]
    public int BuildYear { get; init; }

    /// <summary>
    /// Имя управляющего
    /// </summary>
    [StringLength(100)]
    public string ManagerName { get; init; }

    /// <summary>
    /// Телефон управляющего
    /// </summary>
    [StringLength(20)]
    public string ManagerPhone { get; init; }
}
