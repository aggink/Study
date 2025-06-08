using Study.Lab3.Storage.Models.Sweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace Study.Lab3.Logic.Extensions.Sweets
=======
namespace Study.Lab3.Logic.Extensions.SweetFactory
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
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
        public static bool IsNatural(this Sweet sweet)
        {
            return sweet.Ingredients.Contains("Natural ingedients");
        }
    }
}
