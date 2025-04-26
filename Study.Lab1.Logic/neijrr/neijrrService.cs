using Study.Lab1.Logic.Assistant.Task2;
using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.kinkiss1.Task2;
using Study.Lab1.Logic.neijrr.Task2;

namespace Study.Lab1.Logic.neijrr
{
    public class neijrrService : IRunService
    {
        /// <summary>
        /// Находит наибольший общий делитель
        /// </summary>
        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public void RunTask1()
        {
            var a = new Fraction(2, 3);
            var b = new Fraction(1, 6);
            var c = a + b;

            Console.WriteLine($"{a} + {b} = {c}");
        }

        public void RunTask2()
        {
            var euFormatter = new EuropeanDateTimeFormatter();
            var euDateFormatter = new PrefixDecorator(euFormatter, "Сегодня ");
            var euTimeFormatter = new SuffixDecorator(new PrefixDecorator(euFormatter, "Время: ["), "]");

            var amFormatter = new AmericanDateTimeFormatter();
            var amDateFormatter = new PrefixDecorator(amFormatter, "Сегодня ");
            var amTimeFormatter = new SuffixDecorator(new PrefixDecorator(amFormatter, "Время: ["), "]");

            Console.WriteLine("Европейский формат:");
            Console.WriteLine(euDateFormatter.Date());
            Console.WriteLine(euTimeFormatter.Date());

            Console.WriteLine("Американский формат:");
            Console.WriteLine(amDateFormatter.Date());
            Console.WriteLine(amTimeFormatter.Date());

            Console.WriteLine("Unix epoch:");
            Console.WriteLine($"Европейский формат: {euFormatter.DateTime(DateTime.UnixEpoch)}");
            Console.WriteLine($"Американский формат: {amFormatter.DateTime(DateTime.UnixEpoch)}");
        }

        public void RunTask3()
        {
            throw new NotImplementedException();
        }
    }
}
