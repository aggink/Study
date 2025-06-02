using Study.Lab3.Storage.Models.Sweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Logic.Extensions.Sweets
{
    /// <summary>
    /// Нахождение нужных конфет по составу
    /// </summary>
    public static class SweetExtensions
    {
        /// <summary>
        /// Получить конфеты с выбранным ингридиентом
        /// </summary>
        /// <param name="Sweet">конфета</param>
        /// <returns>Название конфеты</returns>
        public static bool IsNatural(Sweet sweet)
        {
            return sweet.Ingredients.Contains("Natural ingedients");
        }
    }
}
