using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Study.Lab3.Storage.Models.University
{
    [Table("SCIENTIFIC_WORKS")]
    public class ScientificWork
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IsnScientificWork { get; set; }

        [ForeignKey(nameof(Student))]
        public Guid IsnStudent { get; set; }

        [ForeignKey(nameof(Subject))]
        public Guid IsnSubject { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public int PageCount { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        public bool IsPublished { get; set; }

        [ForeignKey(nameof(IsnStudent))]
        public Student Student { get; set; }
        
        [ForeignKey("IsnSubject")]
        public Subject Subject { get; set; }

    }
    
}