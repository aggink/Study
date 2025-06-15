using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.CarService;

public class ServiceRecord
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnServiceRecord { get; set; }
    
    [Required]
    [MaxLength(ModelConstants.ServiceRecord.CarLicensePlate)]
    public string CarLicensePlate { get; set; }
    
    [Required]
    public DateTime ServiceDate { get; set; }
    
    [Required]
    [MaxLength(ModelConstants.ServiceRecord.ServiceType)]
    public string ServiceType { get; set; }
    
    [Required]
    [MaxLength(ModelConstants.ServiceRecord.Description)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(ModelConstants.ServiceRecord.MechanicName)]
    public string MechanicName { get; set; }

    [Required]
    [Range(ModelConstants.ServiceRecord.MinCost, ModelConstants.ServiceRecord.MaxCost)]
    public double Cost { get; set; }
    
    [Required]
    public bool IsCompleted { get; set; }
    
}