namespace Study.Lab1.Logic.SlavicSquat.Task1
{
    internal class RationalNumber
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public RationalNumber(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;

            if (Denominator < 0 && Numerator < 0)
            {
                Numerator *= -1;
                Denominator *= -1;

            }

            if (Denominator == 0)
            {
                throw new ArgumentException("Знаменатель не должен быть нулем");
            }
        }

        public override string ToString()
        {

            return $"{Numerator}/{Denominator}";
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {

            return new RationalNumber(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {

            return new RationalNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {

            return new RationalNumber(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {

            return new RationalNumber(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static bool operator ==(RationalNumber a, RationalNumber b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
        }

        public static bool operator !=(RationalNumber a, RationalNumber b)
        {
            return !(a == b);
        }

        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
        }

        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
        }

        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator >= b.Numerator * a.Denominator;
        }

        public static bool operator <=(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator <= b.Numerator * a.Denominator;
        }

        private int NOD(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        private void Reduce()
        {
            int nod = NOD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= nod;
            Denominator /= nod;

            if (Denominator < 0)
            {
                Denominator = Math.Abs(Denominator);
                Numerator = -Numerator;
            }
        }
    }
}
