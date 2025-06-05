using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.Masters.DtoModels;

public sealed record UpdateMasterDto
{
    /// <summary>
    /// Идентификатор мастера
    /// </summary>
    [Required]
    public Guid IsnMaster { get; init; }

    /// <summary>
    /// Имя мастера
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Master.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Email мастера
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Master.Email)]
    [EmailAddress]
    public string Email { get; init; }

    /// <summary>
    /// Телефон мастера
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Master.Phone)]
    public string Phone { get; init; }

    /// <summary>
    /// Специализация мастера
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Master.Specialization)]
    public string Specialization { get; init; }
}
