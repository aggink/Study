using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Storage.Models.Students
{
    /// <summary>
    /// Связь таблиц предметы - группы
    /// </summary>
    [Index(nameof(IsnSubject), nameof(IsnGroup))]
    [PrimaryKey(nameof(IsnSubject), nameof(IsnGroup))]
    public class SubjectGroup
    {
        /// <summary>
        /// Идентификатор предмета
        /// </summary>
        [ForeignKey(nameof(Group)), Required]
        public Guid IsnSubject { get; set; }

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        [ForeignKey(nameof(Subject)), Required]
        public Guid IsnGroup { get; set; }

        /// <summary>
        /// Группа
        /// </summary>
        public virtual Group Group { get; set; }

        /// <summary>
        /// Предмет
        /// </summary>
        public virtual Subject Subject { get; set; }
    }
}
