using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Shelter
{
    public class Adoption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        [Range(ModelConstants.Adoption.PriceMin, ModelConstants.Adoption.PriceMax)]
        public int Price { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(Cat))]
        public int CatId { get; set; }

        [Required]
        public DateTime AdoptionDate { get; set; }
        
        [Required]
        [MaxLength(ModelConstants.Adoption.Status)]
        public string Status { get; set; }
    }
}
