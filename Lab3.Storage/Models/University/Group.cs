using Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Storage.Models.University
{
    /// <summary>
    /// Группа
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnGroup { get; set; }

        /// <summary>
        /// Наименование группы
        /// </summary>
        [Required, MaxLength(ModelLengthConstants.Group.Name)]
        public string Name { get; set; }

        /// <summary>
        /// Студенты
        /// </summary>
        [InverseProperty(nameof(Student.Group))]
        public virtual ICollection<Student> Students { get; set; }

        /// <summary>
        /// Связь с таблицей группы - предметы
        /// </summary>
        [InverseProperty(nameof(SubjectGroup.Group))]
        public virtual ICollection<SubjectGroup> SubjectGroups { get; set; }
    }
}
