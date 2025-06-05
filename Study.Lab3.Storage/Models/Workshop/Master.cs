using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Workshop;

/// <summary>
/// Мастер сервисного центра
/// </summary>
public class Master
{
    /// <summary>
    /// Идентификатор мастера
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnMaster { get; set; }

    /// <summary>
    /// Имя мастера
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Master.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Email мастера
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Master.Email)]
    public string Email { get; set; }

    /// <summary>
    /// Телефон мастера
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Master.Phone)]
    public string Phone { get; set; }

    /// <summary>
    /// Специализация мастера
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Master.Specialization)]
    public string Specialization { get; set; }

    /// <summary>
    /// Заказы мастера
    /// </summary>
    [InverseProperty(nameof(ServiceOrder.Master))]
    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }
}