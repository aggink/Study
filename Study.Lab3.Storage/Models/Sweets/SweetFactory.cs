using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Models.University;
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
    /// Фабрика по произодству конфет
    /// </summary>
    public class SweetFactory
    {
        /// <summary>
        /// Идентификатор фабрики
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  Int64 ID { get; set; }

        /// <summary>
        /// Наименование фабрики
        /// </summary>
        [Required, MaxLength(ModelConstants.SweetFactory.MaxNameLenght), MinLength(ModelConstants.SweetFactory.MinNameLenght)]
        public string Name { get; set; }

        /// <summary>
        /// Адрес фабрики
        /// </summary>
        [Required, MaxLength(ModelConstants.SweetFactory.MaxAddressLenght), MinLength(ModelConstants.SweetFactory.MinAddressLenght)]
        public string Address { get; set; }

        /// <summary>
        /// Объём производства фабрики в тоннах в день
        /// </summary>
        [Required]
        public Int64 Volume { get; set; }

        /// <summary>
        /// 
        /// </summary>
   
        public virtual ICollection<Sweet> Sweets { get; set; }

    }
}
