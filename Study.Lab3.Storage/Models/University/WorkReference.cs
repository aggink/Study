using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University
{
    [Table("WORK_REFERENCES")]
    public class WorkReference
    {
        [Key]
        [Column("ISN_REFERENCE")]
        public Guid IsnReference { get; set; }

        [Column("ISN_SCIENTIFIC_WORK")]
        [Required]
        public Guid IsnScientificWork { get; set; }

        [Column("REFERENCED_WORK_ID")]
        [Required]
        public Guid ReferencedWorkId { get; set; }

        [Column("REFERENCE_DATE")]
        [Required]
        public DateTime ReferenceDate { get; set; }

        public ScientificWork ScientificWork { get; set; }
    }
}