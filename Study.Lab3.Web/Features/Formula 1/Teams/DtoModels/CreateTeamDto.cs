using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Formula1.Teams.DtoModels
{
    public class CreateTeamDto
    {
        /// <summary>
        /// Идентификатор команды
        /// </summary>
        [Required]
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
    }
}
