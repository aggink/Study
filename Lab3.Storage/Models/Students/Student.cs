using Lab3.Storage.Constants;
using Lab3.Storage.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Storage.Models.Students
{
    /// <summary>
    /// Студент
    /// </summary>
    [Index(nameof(IsnGroup))]
    public class Student
    {
        /// <summary>
        /// Идентификатор студента
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnStudent { get; set; }

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        [ForeignKey(nameof(Group))]
        public Guid IsnGroup { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required, MaxLength(ModelLengthConstants.Student.SurName)]
        public string SurName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required, MaxLength(ModelLengthConstants.Student.Name)]
        public string Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Required, MaxLength(ModelLengthConstants.Student.PatronymicName)]
        public string PatronymicName { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public SexType Sex { get; set; }

        /// <summary>
        /// Группа
        /// </summary>
        public virtual Group Group { get; set; }
    }
}
