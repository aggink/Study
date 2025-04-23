using Study.Lab1.Logic.Interfaces;

namespace Study.Lab1.Logic.neijrr
{
    public class neijrrService : IRunService
    {
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
