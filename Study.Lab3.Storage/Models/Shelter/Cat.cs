using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Shelter
{
    public class Cat
    {
        /// <summary>
        /// Идентификатор кота
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nickname { get; set; }

        public DateTime BirthDate { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Breed { get; set; }

        [Required]
        public bool IsVaccinated { get; set; }

        [Required]
        public bool IsSterilized { get; set; }

        [MaxLength(200)]
        public string Color { get; set; }

        [MaxLength(1000)]
        public string MedicalHistory { get; set; }

        [MaxLength(255)]
        public string PhotoUrl { get; set; }

        public DateTime ArrivalDate { get; set; }

        public bool IsAvailableForAdoption { get; set; }

        public int Age { get; set; }

        // Навигационное свойство для отношения многие-ко-многим
        public virtual ICollection<Adoption> Adoptions { get; set; }
    }
}