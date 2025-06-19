using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Study.Lab3.Storage.Models.University;

public class ScientificWork
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnScientificWork { get; set; }

    public Guid IsnStudent { get; set; }

    public Guid IsnSubject { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    public int PageCount { get; set; }

    [Required]
    public DateTime PublicationDate { get; set; }

    public virtual Student Student { get; set; }
    public virtual Subject Subject { get; set; }

}
