using Study.Lab1.Logic.alexmark1612.Task1;
using Study.Lab1.Logic.Interfaces;

namespace Study.Lab1.Logic.alexmark1612
{
    public class alexmark1612Service : IRunService
    {
        public void RunTask1()
        {
            var a = new RationalNumbers(1, 2);
            Console.Write($"{a.ToString()}\n");
            var b = new RationalNumbers(1, 3);
            Console.Write($"{b.ToString()}\n");
            var sum = a + b;
            Console.Write($"{sum.ToString()}\n");
            var raz = a - b;
            Console.Write($"{raz.ToString()}\n");
            var raz2 = b - a;
            Console.Write($"{raz2.ToString()}\n");
            var ymn = a * b;
            Console.Write($"{ymn.ToString()}\n");
            var del = a / b;
            Console.Write($"{del.ToString()}\n");
            var del2 = b / a;
            Console.Write($"{del2.ToString()}\n");
            var antia = -a;
            Console.Write($"{antia.ToString()}\n");
            var c = new RationalNumbers(2, 4);
            Console.Write($"{c.ToString()}\n");
            var d = new RationalNumbers(2, 1);
            Console.Write($"{d.ToString()}\n");
            var e = new RationalNumbers(4, 2);
            Console.Write($"{e.ToString()}\n");
            var f = new RationalNumbers(7, -2);
            Console.Write($"{f.ToString()}\n");
            var g = new RationalNumbers(7, 0);
            Console.Write($"{g.ToString()}\n");
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
