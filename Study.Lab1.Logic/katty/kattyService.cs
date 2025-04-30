using Study.Lab1.Logic.Interfaces;

namespace Study.Lab1.Logic.katty;

public class kattyService : IRunService
{
    public void RunTask1()
    {
        var fraction1 = new Fraction(1, 1);
        Console.WriteLine(fraction1.ToString());
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
