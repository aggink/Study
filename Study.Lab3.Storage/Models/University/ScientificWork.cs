using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Study.Lab3.Storage.Models.University;


public class ScientificWork
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnScientificWork { get; set; }


        // <summary>
        /// Студент
        /// </summary>

        [ForeignKey(nameof(Student))]
        public Guid IsnStudent { get; set; }

        public virtual Student Student { get; set; }

        // <summary>
        /// Предмет
        /// </summary>
        [ForeignKey(nameof(Subject))]
        public Guid IsnSubject { get; set; }

        public virtual Subject Subject { get; set; }

        // <summary>
        /// Название
        /// </summary>
        [Required]
        public string Title { get; set; }

        // <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        // <summary>
        /// Число страниц
        /// </summary>
        [Required]
        public int PageCount { get; set; }

        // <summary>
        /// Дата публикации
        /// </summary>
        [Required]
        public DateTime PublicationDate { get; set; }

        // <summary>
        /// Опубликовано
        /// </summary>
        public bool IsPublished { get; set; }

    }
