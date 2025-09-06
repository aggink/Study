using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Study.Lab3.Storage.Models.University
{
    public class WorkReference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IsnReference { get; set; }  

        [Required]
        [ForeignKey(nameof(ReferencedWork))]
        public Guid ReferencedWorkId { get; set; }  

        [Required]
        [ForeignKey(nameof(SourceWork))]
        public Guid SourceWorkId { get; set; }  

        [Required]
        public DateTime ReferenceDate { get; set; }

       
        public virtual ScientificWork ReferencedWork { get; set; }  
        public virtual ScientificWork SourceWork { get; set; }      
    }
}