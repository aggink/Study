using Study.Lab1.Logic.Interfaces;

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
            throw new NotImplementedException();
        }

        public void RunTask3()
        {
            throw new NotImplementedException();
        }
    }
}
