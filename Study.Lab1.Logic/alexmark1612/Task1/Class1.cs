namespace Study.Lab1.Logic.alexmark1612.Task1
{
    public class RationalNumbers
    {
        // Поиск НОД
        private static int Nod(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public int Numerator { get; }
        public int Denominator { get; }
        // Конструктор для инициализации переменных
        public RationalNumbers(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Знаменатель не может быть равен нулю");
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            // Сокращение дроби
            var gcd = Math.Abs(Nod(numerator, denominator));
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }
        // Функция для вывода дроби
        public override string ToString()
        {
            if (Denominator != 1)
            {
                return $"{Numerator}/{Denominator}";
            }
            return $"{Numerator}";
        }
        // Перегриузка оператора +
        public static RationalNumbers operator +(RationalNumbers x, RationalNumbers y)
        {
            var a = x.Numerator * y.Denominator + y.Numerator * x.Denominator;
            var b = x.Denominator * y.Denominator;
            return new RationalNumbers(a, b);
        }
        // Перегриузка оператора -
        public static RationalNumbers operator -(RationalNumbers x, RationalNumbers y)
        {
            var a = x.Numerator * y.Denominator - y.Numerator * x.Denominator;
            var b = x.Denominator * y.Denominator;
            return new RationalNumbers(a, b);
        }
        // Перегриузка оператора *
        public static RationalNumbers operator *(RationalNumbers x, RationalNumbers y)
        {
            var a = x.Numerator * y.Numerator;
            var b = x.Denominator * y.Denominator;
            return new RationalNumbers(a, b);
        }
        // Перегриузка оператора /
        public static RationalNumbers operator /(RationalNumbers x, RationalNumbers y)
        {
            var a = x.Numerator * y.Denominator;
            var b = x.Denominator * y.Numerator;
            return new RationalNumbers(a, b);
        }
        // Перегрузка унарного минуса
        public static RationalNumbers operator -(RationalNumbers a)
        {
            return new RationalNumbers(-a.Numerator, a.Denominator);
        }
    }
}
