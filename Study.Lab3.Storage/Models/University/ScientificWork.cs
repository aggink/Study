using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Study.Lab3.Storage.Models.University
{
    [Table("SCIENTIFIC_WORKS")]
    public class ScientificWork
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnScientificWork { get; set; }

        // <summary>
        /// Студент
        /// </summary>
        public Guid IsnStudent { get; set; }
        [ForeignKey(nameof(IsnStudent))]
        public Student Student { get; set; }

        // <summary>
        /// Предмет
        /// </summary>
        public Guid IsnSubject { get; set; }
        [ForeignKey("IsnSubject")]
        public Subject Subject { get; set; }

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

}