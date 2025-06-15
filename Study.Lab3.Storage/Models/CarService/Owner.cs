using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.CarService;

public class Owner
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnOwner { get; set; }
    
    [Required]
    [MaxLength(ModelConstants.Owner.FirstName)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(ModelConstants.Owner.SecondName)]
    public string SecondName { get; set; }
    
    [Required]
    [MaxLength(ModelConstants.Owner.PhoneNumber)]
    public string PhoneNumber { get; set; }
    
    [Required]
    [MaxLength(ModelConstants.Owner.Email)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(ModelConstants.Owner.Address)]
    public string Address { get; set; }
    
    [InverseProperty(nameof(Car.Owner))]
    public virtual Car Car { get; set; }
}