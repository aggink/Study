using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Formula1
{
    /// <summary>
    /// Связь таблиц гонщики - гран-при
    /// </summary>
    [Index(nameof(IsnDriver), nameof(IsnGrandPrix))]
    [PrimaryKey(nameof(IsnDriver), nameof(IsnGrandPrix))]
    public class DriverGrandPrix
    {
        /// <summary>
        /// Идентификатор гонщика
        /// </summary>
        [ForeignKey(nameof(GrandPrix)), Required]
        public Guid IsnDriver { get; set; }

        /// <summary>
        /// Идентификатор гран-при
        /// </summary>
        [ForeignKey(nameof(Driver)), Required]
        public Guid IsnGrandPrix { get; set; }

        /// <summary>
        /// Стартовая позиция
        /// </summary>
        [Required, Range(ModelConstants.DriverGrandPrix.MinPosition, ModelConstants.DriverGrandPrix.MaxPosition)]
        public int StartPosition { get; set; }

        /// <summary>
        /// Место по результатам гонки
        /// </summary>
        [Required, Range(ModelConstants.DriverGrandPrix.MinPosition, ModelConstants.DriverGrandPrix.MaxPosition)]
        public int Position { get; set; }

        /// <summary>
        /// Количество заработаннных в гонке очков
        /// </summary>
        [Range(ModelConstants.DriverGrandPrix.MinPointsEarned, ModelConstants.DriverGrandPrix.MaxPointsEarned)]
        public int PointsEarned { get; set; }

        /// <summary>
        /// Не финишировал в гонке
        /// </summary>
        [Required]
        public bool DidNotFinish { get; set; }

        /// <summary>
        /// Гонщик
        /// </summary>
        public virtual Driver Driver { get; set; }

        /// <summary>
        /// Гран-при
        /// </summary>
        public virtual GrandPrix GrandPrix { get; set; }
    }
}
