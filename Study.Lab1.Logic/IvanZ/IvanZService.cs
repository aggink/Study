using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.IvanZ.task1;

namespace Study.Lab1.Logic.IvanZ
{
    public class IvanZService : IRunService
    {
        public void RunTask1()
        {
            RationalNumber a = new RationalNumber(1, 2);
            RationalNumber b = new RationalNumber(5, 13);
            RationalNumber c = new RationalNumber(23, 23);
            RationalNumber d = new RationalNumber(12, 85);
 	          RationalNumber sum = a + b;
            RationalNumber sub = a - c;
            RationalNumber multi = b * d;
            RationalNumber div = c / d;
           
            Console.WriteLine($"a: {a.ToString()}\n");
            Console.WriteLine($"b: {b.ToString()}\n");
	          Console.WriteLine($"c: {c.ToString()}\n");
            Console.WriteLine($"d: {d.ToString()}\n");
            Console.WriteLine($"Multi: {multi.ToString()}\n");
            Console.WriteLine($"Div: {div.ToString()}\n");
            Console.WriteLine($"Sum: {sum.ToString()}\n");
            Console.WriteLine($"Sub: {sub.ToString()}\n");

            Console.WriteLine($"a > b: {a > b}\n");
            Console.WriteLine($"b < c: {b < c}\n");
            Console.WriteLine($"b >= d: {b >= d}\n");
            Console.WriteLine($"c <= a: {c <= a}\n");
            Console.WriteLine($"a == d: {a == d}\n");
            Console.WriteLine($"c != d: {c != d}\n");
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
