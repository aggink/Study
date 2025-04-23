using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.SuperSalad007.Task1
{
    internal class RationalDigit
    {
        private int Numerator;
        private int Denominator;

        int get_Numerator()
        {
            return Numerator;
        }

        void set_Numerator(int new_digit_N)
        {
            Numerator = new_digit_N;
        }

        int get_Denominator()
        {
            return Denominator;
        }

        void set_Denominator(int new_digit_D)
        {
            Denominator = new_digit_D;
        }
        public RationalDigit(int numer, int denom) 
        {
            Numerator = numer;
            Denominator = denom;
        }
    }
}
