using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Study.Lab3.Storage.Models.ConfectioneryFactory
{
    /// <summary>
    /// Класс категории сладостей (группировка по типу)
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Название категории
        /// </summary>
        /// <example>Торты</example>
        public string Name { get; set; }

        /// <summary>
        /// Коллекция сладостей, принадлежащих данной категории
        /// </summary>
        /// <seealso cref="Sweet"/>
        public ICollection<Sweet> Sweets { get; set; }
    }
}
