using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.Interfaces.lsokol14l.task1
{
    public interface IRationalNumber
    {
        /// <summary>
        /// Числитель
        /// </summary>
        int Numerator { get; }

        /// <summary>
        /// Знаменатель
        /// </summary>
        int Denominator { get; }
    }
}
