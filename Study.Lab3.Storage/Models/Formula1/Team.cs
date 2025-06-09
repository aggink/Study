using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Formula1
{
    /// <summary>
    /// Команда
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Идентификатор команды
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnTeam { get; set; }

        /// <summary>
        /// Название команды
        /// </summary>        
        [Required, MaxLength(ModelConstants.Team.Name)]
        public string Name { get; set; }

        /// <summary>
        /// Год создания команды
        /// </summary>
        [Range(ModelConstants.Team.MinYearOfCreation, ModelConstants.Team.MaxYearOfCreation)]
        public int YearOfCreation { get; set; }

        /// <summary>
        /// Поставщик двигателей для команды
        /// </summary>
        [MaxLength(ModelConstants.Team.EngineSupplier)]
        public string EngineSupplier { get; set; }

        public virtual GrandPrix GrandPrix { get; set; }

        [InverseProperty(nameof(Driver.Team))]
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
