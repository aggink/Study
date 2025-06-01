using Study.Lab3.Storage.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Storage.Models.Sweets
{
    /// <summary>
    /// Конфеты
    /// </summary>
    public class Sweet
    {
        /// <summary>
        /// Идентификатор конфеты
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 ID { get; set; }

        /// <summary>
        /// Наименование конфеты
        /// </summary>
        [Required, MaxLength(ModelConstants.SweetFactory.MaxNameLenght), MinLength(ModelConstants.SweetFactory.MinNameLenght)]
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор типа конфеты
        /// </summary>
        [Required]
        [ForeignKey(nameof(SweetType))]
        public Int64 SweetTypeID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual SweetType SweetType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<SweetFactory> SweetFactories{ get; set; }
    }
}
