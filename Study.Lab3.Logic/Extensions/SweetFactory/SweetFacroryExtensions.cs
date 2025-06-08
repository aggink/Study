<<<<<<< HEAD
﻿using Study.Lab3.Storage.Models.Sweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Logic.Extensions.Sweets
=======
﻿namespace Study.Lab3.Logic.Extensions.SweetFactory
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
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
<<<<<<< HEAD
        public static bool IsAddressCorrect(this SweetFactory sweetfactory)
=======
        public static bool IsAddressCorrect(this Storage.Models.Sweets.SweetFactory sweetfactory)
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        {
            return sweetfactory.Address.Contains("Russian Federation");
        }
    }
}
