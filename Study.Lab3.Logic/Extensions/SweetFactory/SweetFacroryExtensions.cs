using Study.Lab3.Storage.Models.Sweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Logic.Extensions.Sweets
{
    /// <summary>
    /// Нахождение,находящихся в России, фабрики
    /// </summary>
    public static class SweetFactoryExtensions
    {
        /// <summary>
        /// Получить фабрики с Российским адресом 
        /// </summary>
        /// <param name="factory">Фабрики</param>
        /// <returns>Название фабрики</returns>
        public static bool IsAddressCorrect(this SweetFactory sweetfactory)
        {
            return sweetfactory.Address.Contains("Russian Federation");
        }
    }
}
