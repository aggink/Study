using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.CarService;

public class Car
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnCar { get; set; }

    /// <summary>
    /// Идентификатор владельца
    /// </summary>
    [ForeignKey(nameof(Owner))]
    public Guid IsnOwner { get; set; }

    /// <summary>
    /// Бренд
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Car.Brand)]
    public string Brand { get; set; }

    [Required]
    [MaxLength(ModelConstants.Car.Model)]
    public string Model { get; set; }

    [Required]
    [Range(ModelConstants.Car.MinYear, ModelConstants.Car.MaxYear)]
    public int Year { get; set; }

    [Required]
    [Range(ModelConstants.Car.MinMileage, ModelConstants.Car.MaxMileage)]
    public int Mileage { get; set; }

    [Required]
    [MaxLength(ModelConstants.Car.Color)]
    public string Color { get; set; }

    [Required]
    [MaxLength(ModelConstants.Car.LicensePlate)]
    public string LicensePlate { get; set; }

    [Required]
    [MaxLength(ModelConstants.Car.VinNumber)]
    public string VinNumber { get; set; }

    public virtual Owner Owner { get; set; }
}