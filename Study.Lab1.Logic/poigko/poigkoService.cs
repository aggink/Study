using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.poigko.Task1;

namespace Study.Lab1.Logic.poigko
{
    public class poigkoService : IRunService
    {
        public void RunTask1()
        {
            var a = new RationalNumber(3, 7);
            var b = new RationalNumber(1, -5);
            Console.WriteLine(b);
            Console.WriteLine(a / b);
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
