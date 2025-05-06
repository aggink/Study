using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.Taipano.Task1;

namespace Study.Lab1.Logic.Taipano
{
    public class TaipanoService : IRunService
    {
        public void RunTask1()
        {
            RationalNumber r3 = new RationalNumber(6, 6);
            RationalNumber r1 = new RationalNumber(3, 6);
            RationalNumber r2 = new RationalNumber(4, 12);
            RationalNumber multiplication_rational = r1 * r2;
            RationalNumber division_rational = r1 / r2;
            RationalNumber add_rational = r1 + r2;
            RationalNumber sub_rational = r1 - r2;

            Console.WriteLine($"Rational 1: {r1.ToString()}\n");
            Console.WriteLine($"Rational 2: {r2.ToString()}\n");
            Console.WriteLine($"Multiplication: {multiplication_rational.ToString()}\n");
            Console.WriteLine($"Division: {division_rational.ToString()}\n");
            Console.WriteLine($"Add: {add_rational.ToString()}\n");
            Console.WriteLine($"Sub: {sub_rational.ToString()}\n");

            Console.WriteLine($"r1 > r2: {r1 > r2}\n");
            Console.WriteLine($"r1 < r2: {r1 < r2}\n");
            Console.WriteLine($"r1 >= r2: {r1 >= r2}\n");
            Console.WriteLine($"r1 <= r2: {r1 <= r2}\n");
            Console.WriteLine($"r1 == r2: {r1 == r2}\n");
            Console.WriteLine($"r1 != r2: {r1 != r2}\n");
            Console.WriteLine($"r3 =  { r3.ToString()}\n");
        }

        public void RunTask2()
        {
            throw new NotImplementedException();
        }

        public void RunTask3()
        {
            throw new NotImplementedException();
        }
    }
}
