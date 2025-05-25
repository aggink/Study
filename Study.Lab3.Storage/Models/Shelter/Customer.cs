using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Storage.Models.Shelter
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(15)]
        public string Number { get; set; }

        public int SaleId { get; set; }

        public string Email { get; set; }
    }
}