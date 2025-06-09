using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Formula1
{
    /// <summary>
    /// Гран-при(гонка)
    /// </summary>
    public class GrandPrix
    {
        /// <summary>
        /// Идентификатор гран-при
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnGrandPrix { get; set; }

        /// <summary>
        /// Название гран-при
        /// </summary>
        [Required, MaxLength(ModelConstants.GrandPrix.Name)]
        public string Name { get; set; }

        /// <summary>
        /// Имя победителя
        /// </summary>
        [Required, MaxLength(ModelConstants.GrandPrix.Winner)]
        public string Winner { get; set; }

        /// <summary>
        /// Название трассы
        /// </summary>
        [MaxLength(ModelConstants.GrandPrix.Circuit)]
        public string Circuit { get; set; }

        /// <summary>
        /// Дата проведения гран-при
        /// </summary>
        [Required]
        public DateOnly Date { get; set; }

        /// <summary>
        /// Гонщики
        /// </summary>
        [InverseProperty(nameof(Driver.GrandPrix))]
        public virtual ICollection<Driver> Drivers { get; set; }

        /// <summary>
        /// Гран-при
        /// </summary>
        [InverseProperty(nameof(Team.GrandPrix))]
        public virtual ICollection<Team> Teams { get; set; }

        /// <summary>
        /// Связь с таблицей гонщики-гран-при
        /// </summary>
        [InverseProperty(nameof(DriverGrandPrix.GrandPrix))]
        public virtual ICollection<DriverGrandPrix> DriverGrandPrixes { get; set; }
    }
}
