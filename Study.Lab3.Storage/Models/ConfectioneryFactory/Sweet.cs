using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Storage.Models.ConfectioneryFactory
{
    /// <summary>
    /// Класс, представляющий сладость (кондитерское изделие)
    /// </summary>
    public class Sweet 
    {
        /// <summary>
        /// Название сладости
        /// </summary>
        /// <example>Шоколадный торт</example>
        public string Name { get; set; }

        /// <summary>
        /// Описание сладости (состав, особенности)
        /// </summary>
        /// <example>Шоколадный бисквит с кремом из темного шоколада</example>
        public string Description { get; set; }

        /// <summary>
        /// Цена сладости в рублях
        /// </summary>
        /// <example>450.50</example>
        public decimal Price { get; set; }

        /// <summary>
        /// Идентификатор категории, к которой относится сладость
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Навигационное свойство для связи с категорией
        /// </summary>
        /// <seealso cref="Category"/>
        public Category Category { get; set; }
    }
}
