using Study.Lab3.Storage.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Storage.Models.Sweets
{
    public class SweetType
    {
        /// <summary>
        /// Идентификатор типа конфеты
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        /// <summary>
        /// Наименование типа конфеты
        /// </summary>
        [Required, MaxLength(ModelConstants.SweetFactory.MaxNameLenght), MinLength(ModelConstants.SweetFactory.MinNameLenght)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [InverseProperty(nameof(Sweet.SweetType))]
        public virtual ICollection<Sweet> Sweets { get; set; }
    }
}
