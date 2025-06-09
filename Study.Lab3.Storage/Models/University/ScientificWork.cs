using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University
{
    [Table("SCIENTIFIC_WORKS")]
    public class ScientificWork
    {
        [Key]
        [Column("ISN_SCIENTIFIC_WORK")]
        public Guid IsnScientificWork { get; set; }

        [Column("ISN_STUDENT")]
        [Required]
        public Guid IsnStudent { get; set; }

        [Column("ISN_SUBJECT")]
        [Required]
        public Guid IsnSubject { get; set; }

        [Column("TITLE")]
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Column("DESCRIPTION")]
        [MaxLength(1000)]
        public string? Description { get; set; }

        [Column("PAGE_COUNT")]
        [Required]
        public int PageCount { get; set; }

        [Column("PUBLICATION_DATE")]
        [Required]
        public DateTime PublicationDate { get; set; }

        [Column("IS_PUBLISHED")]
        public bool IsPublished { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
    
}