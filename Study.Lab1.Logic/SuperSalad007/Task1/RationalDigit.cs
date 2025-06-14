using Study.Lab1.Logic.lsokol14l.Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.SuperSalad007.Task1
{
    public class FracNumber
    {
        public int NumeratorPart { get; }

        public int DenominatorPart { get; }

        public FracNumber(int NumeratorPart, int DenominatorPart)
        {
            if (DenominatorPart == 0)
            {
                throw new DivideByZeroException("The denominator cannot be zero!!!");
            }
            if (DenominatorPart < 0)
            {
                NumeratorPart *= -1;
                DenominatorPart *= -1;
            }

            int gcd = NOD(Math.Abs(NumeratorPart), Math.Abs(DenominatorPart));
            this.NumeratorPart = NumeratorPart / gcd;
            this.DenominatorPart = DenominatorPart / gcd;
        }


        public override string ToString()
        {
            return DenominatorPart == 1 ? $"{NumeratorPart}" : $"{NumeratorPart}/{DenominatorPart}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NumeratorPart, DenominatorPart);
        }

        public override bool Equals(object obj)
        {
            if (obj is FracNumber number)
                return this == number;
            return false;
        }

        public static FracNumber operator +(FracNumber op) => op;

        public static FracNumber operator -(FracNumber op)
        {
            if (op is null) throw new ArgumentNullException(nameof(op));
            return new FracNumber(-op.NumeratorPart, op.DenominatorPart);
        }

        public static FracNumber operator +(FracNumber op1, FracNumber op2)
        {
            int DenominatorPart = op1.DenominatorPart * op2.DenominatorPart;
            int NumeratorPart = op1.NumeratorPart * op2.DenominatorPart + op2.NumeratorPart * op1.DenominatorPart;
            return new FracNumber(NumeratorPart, DenominatorPart);
        }

        public static FracNumber operator -(FracNumber op1, FracNumber op2)
        {
            int DenominatorPart = op1.DenominatorPart * op2.DenominatorPart;
            int NumeratorPart = op1.NumeratorPart * op2.DenominatorPart - op2.NumeratorPart * op1.DenominatorPart;
            return new FracNumber(NumeratorPart, DenominatorPart);
        }

        public static FracNumber operator *(FracNumber op1, FracNumber op2)
        {
            int DenominatorPart = op1.DenominatorPart * op2.DenominatorPart;
            int NumeratorPart = op1.NumeratorPart * op2.NumeratorPart;
            return new FracNumber(NumeratorPart, DenominatorPart);
        }

        public static FracNumber operator /(FracNumber op1, FracNumber op2)
        {
            int DenominatorPart = op1.DenominatorPart * op2.NumeratorPart;
            int NumeratorPart = op1.NumeratorPart * op2.DenominatorPart;
            return new FracNumber(NumeratorPart, DenominatorPart);
        }

        public static bool operator ==(FracNumber op1, FracNumber op2)
        {
            if (ReferenceEquals(op1, null) || ReferenceEquals(op2, null))
                return false;
            return op1.NumeratorPart * op2.DenominatorPart == op2.NumeratorPart * op1.DenominatorPart;
        }

        public static bool operator !=(FracNumber op1, FracNumber op2) => !(op1 == op2);

        public static bool operator >=(FracNumber op1, FracNumber op2)
        {
            if (ReferenceEquals(op1, null) || ReferenceEquals(op2, null))
                return false;
            return op1.NumeratorPart * op2.DenominatorPart >= op2.NumeratorPart * op1.DenominatorPart;
        }

        public static bool operator <=(FracNumber op1, FracNumber op2)
        {
            if (ReferenceEquals(op1, null) || ReferenceEquals(op2, null))
                return false;
            return op1.NumeratorPart * op2.DenominatorPart <= op2.NumeratorPart * op1.DenominatorPart;
        }

        public static bool operator <(FracNumber op1, FracNumber op2)
        {
            if (ReferenceEquals(op1, null) || ReferenceEquals(op2, null))
                return false;
            return op1.NumeratorPart * op2.DenominatorPart < op2.NumeratorPart * op1.DenominatorPart;
        }

        public static bool operator >(FracNumber op1, FracNumber op2)
        {
            if (ReferenceEquals(op1, null) || ReferenceEquals(op2, null))
                return false;
            return op1.NumeratorPart * op2.DenominatorPart > op2.NumeratorPart * op1.DenominatorPart;
        }

        private static int NOD(int DenominatorPart_1op, int DenominatorPart_2op)
        {
            DenominatorPart_1op = Math.Abs(DenominatorPart_1op);
            DenominatorPart_2op = Math.Abs(DenominatorPart_2op);

            while (DenominatorPart_2op != 0)
            {
                var temp = DenominatorPart_2op;
                DenominatorPart_2op = DenominatorPart_1op % DenominatorPart_2op;
                DenominatorPart_1op = temp;
            }

            return DenominatorPart_1op;
        }

    }
}
