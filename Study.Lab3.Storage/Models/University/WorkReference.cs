using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Study.Lab3.Storage.Models.University
{
    public class WorkReference
    {
        public int Id { get; set; }

        [ForeignKey(nameof(IsnScientificWork))]
        public ScientificWork ScientificWork { get; set; }

        public Guid IsnReference { get; set; }

        [Required]
        public Guid IsnScientificWork { get; set; }

        [Required]
        public Guid ReferencedWorkId { get; set; }

        [Required]
        public DateTime ReferenceDate { get; set; }

        

        
    }
}