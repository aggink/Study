using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.PresvyatoyKabachok.Task1;

namespace Study.Lab1.Logic.PresvyatoyKabachok;

public class PresvyatoyKabachokService : IRunService
{
    public void RunTask1()
    {
        {
            var A = new RationalNumber(12, 24);
            var B = new RationalNumber(33, 44);
            var C = new RationalNumber(7, 14);
            var D = new RationalNumber(82, 23);
            var E = new RationalNumber(-121, -11);

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

            // e.Denominator = 0; Ошибка => только для чтения;
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