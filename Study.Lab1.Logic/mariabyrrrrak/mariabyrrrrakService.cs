using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.mariabyrrrrak.Task1;

namespace Study.Lab1.Logic.mariabyrrrrak;

public class mariabyrrrrakService : IRunService
{
    public void RunTask1()
    {
        RationalNumber number = new RationalNumber(1, 1);
        Console.WriteLine(number);
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