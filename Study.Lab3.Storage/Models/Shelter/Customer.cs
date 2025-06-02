using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Shelter
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.ShelterCustomer.Name)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(ModelConstants.ShelterCustomer.Name)]
        public string LastName { get; set; }
        
        [MaxLength(ModelConstants.ShelterCustomer.Description)]
        public string Description { get; set; }

        [Required]
        [MaxLength(ModelConstants.ShelterCustomer.Address)]
        public string Address { get; set; }

        [Required]
        [MaxLength(ModelConstants.ShelterCustomer.PhoneNumber)]
        public string PhoneNumber { get; set; }
        
        [Required]
        [MaxLength(ModelConstants.ShelterCustomer.Email)]
        public string Email { get; set; }
        
        /// <summary>
        /// Заказы клиента
        /// </summary>
        [InverseProperty(nameof(Adoption.Customer))]
        public virtual ICollection<Adoption> Adoptions { get; set; }
    }
}