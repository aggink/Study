using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Sessions.DtoModels;

public sealed record CreateSessionDto
{
    /// <summary>
    /// Идентификатор фильма
    /// </summary>
    [Required]
    public Guid IsnMovie { get; init; }
    
    /// <summary>
    /// Идентификатор зала
    /// </summary>
    [Required]
    public Guid IsnHall { get; init; }
    
    /// <summary>
    /// Время начала сеанса
    /// </summary>
    [Required]
    public DateTime StartTime { get; init; }
    
    /// <summary>
    /// Базовая цена билета
    /// </summary>
    [Required]
    [Range(ModelConstants.Session.MinPrice, ModelConstants.Session.MaxPrice)]
    public decimal BasePrice { get; init; }
}