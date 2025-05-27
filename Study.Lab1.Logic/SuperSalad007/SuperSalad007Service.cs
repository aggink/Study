using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.SuperSalad007.Task1;

namespace Study.Lab1.Logic.SuperSalad007;

public class SuperSalad007Service : IRunService
{
    public void RunTask1()
    {
        {
            var A = new FracNumber(13, 26);
            var B = new FracNumber(22, 44);
            var C = new FracNumber(7, 14);
            var D = new FracNumber(74, 13);
            var E = new FracNumber(-121, -11);

            var sum = A + B; // Используем перегруженный оператор +
            var diff = A - B; // Используем перегруженный оператор -
            var mult = A * B; // Используем перегруженный оператор *
            var quotient = A / B; // Используем перегруженный оператор /
            var equality = A == B; // Используем перегруженный оператор ==

            Console.Write($"a: {A}, b: {B}\n" +
                          $"a + b = {sum}\n" +
                          $"a - b = {diff}\n" +
                          $"a * b = {mult}\n" +
                          $"a / b = {quotient}\n" +
                          $"a == b ? {equality}\n" +
                          $"c: {C}\n" +
                          $"d: {D}\n" +
                          $"e: {E}\n" +
                          $"-e: {-E}\n" +
                          $"a>b: {A > B}\n" +
                          $"b<a: {B < A}\n" +
                          $"d>=c: {D >= C}\n" +
                          $"c<=b: {C <= B}\n" +
                          $"d>=b: {D >= B}\n" +
                          $"a<=c: {A <= C}\n" +
                          $"a == d: {A == C}\n"
            );

            
        }
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
