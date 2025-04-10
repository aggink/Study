using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Study.Lab1.Logic.Interfaces.brnvika.firstTask;

namespace Study.Lab1.Logic.brnvika.firstTask
{
    public class RationalNumbers : IRationNumber
    {
        //private int a;
        //public int A
        //{
        //    get { return a + 1 ; }
        //    private set { a = value; }
        //}

        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public RationalNumbers(int numerator = 0, int denominator = 1)
        {
             switch (denominator)
            {
                case 0:
                    throw new DivideByZeroException("Знаменатель не может быть равен 0.");
                case < 0: 
                    numerator *= -1;
                    denominator *= -1;
                    break;
            }
            int NodNumbers = nodNumbers(numerator, denominator);
            if (NodNumbers != 0)
            {
                this.Numerator = numerator / NodNumbers;
                this.Denominator = denominator / NodNumbers;
            }
        }

        private int nodNumbers(int a, int b)
        {
            if (a < 0)
            {
                a *= -1;
            }
            while (a != 0 && b != 0)
            {
                if (a > b) { a = a % b; }
                else { b = b % a; }
            }
            return a + b;
        }

        public override string ToString()
        {
            if (Denominator != 1)
                return String.Format("{0}/{1}", Numerator, Denominator);
            return String.Format("{0}", Numerator);
        }

        public static RationalNumbers operator +(RationalNumbers number1, RationalNumbers number2)
        {
            number1.Numerator *= number2.Denominator;
            number2.Numerator *= number1.Denominator;
            number1.Denominator *= number2.Denominator;
            return new RationalNumbers(number1.Numerator + number2.Numerator, number1.Denominator);
        }

        public static RationalNumbers operator -(RationalNumbers number1, RationalNumbers number2)
        {
            number1.Numerator *= number2.Denominator;
            number2.Numerator *= number1.Denominator;
            number1.Denominator *= number2.Denominator;
            return new RationalNumbers(number1.Numerator - number2.Numerator, number1.Denominator);
        }

        public static RationalNumbers operator* (RationalNumbers number1, RationalNumbers number2)
        {
            return new RationalNumbers(number1.Numerator * number2.Numerator, number1.Denominator * number2.Denominator);
        }

        public static RationalNumbers operator /(RationalNumbers number1, RationalNumbers number2)
        {
            if (number2.Numerator == 0)
                throw new DivideByZeroException("Делить на 0 нельзя");
            return new RationalNumbers(number1.Numerator * number2.Denominator, number1.Denominator * number2.Numerator);
        }

        public static RationalNumbers operator -(RationalNumbers number)
        {
            return new RationalNumbers(-number.Numerator, number.Denominator);
        }

        public static bool operator==(RationalNumbers number1, RationalNumbers number2)
        {
            if (number1.Numerator == number2.Numerator && number1.Denominator == number2.Denominator)
                return true;
            return false;
        }
        public static bool operator !=(RationalNumbers number1, RationalNumbers number2)
        {
            if (number1.Numerator != number2.Numerator || number1.Denominator != number2.Denominator)
                return true;
            return false;
        }
        public static bool operator <(RationalNumbers number1, RationalNumbers number2)
        {
            if (number1.Numerator / number1.Denominator < number2.Numerator / number2.Denominator)
                return true;
            return false;
        }
        public static bool operator >(RationalNumbers number1, RationalNumbers number2)
        {
            if (number1.Numerator / number1.Denominator > number2.Numerator / number2.Denominator)
                return true;
            return false;
        }
        public static bool operator <=(RationalNumbers number1, RationalNumbers number2)
        {
            if (number1.Numerator / number1.Denominator <= number2.Numerator / number2.Denominator)
                return true;
            return false;
        }
        public static bool operator >=(RationalNumbers number1, RationalNumbers number2)
        {
            if (number1.Numerator / number1.Denominator >= number2.Numerator / number2.Denominator)
                return true;
            return false;
        }
    }
}
