using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.SlavicSquat.Task1;

namespace Study.Lab1.Logic.SlavicSquat
{
    public class SlavicSquatService : IRunService
    {
        public void RunTask1()
        {
            var num1 = new RationalNumber(1, 2);
            var num2 = new RationalNumber(1, 3);
            var num3 = new RationalNumber(-1, 5);

            Console.WriteLine($"num1 = {num1}");
            Console.WriteLine($"num2 = {num2}");
            Console.WriteLine($"num3 = {num3}\n");

            var prod = num1 * num2;
            Console.WriteLine($"Умножение: {num1} * {num2} = {prod}");

            var summ = num1 + num2;
            Console.WriteLine($"Сложение: {num1} + {num2} = {summ}");

            var minn = num1 - num2;
            Console.WriteLine($"Вычитание: {num1} - {num2} = {minn}");

            var del = num1 / num2;
            Console.WriteLine($"Деление: {num1} / {num2} = {del}\n");

            var equality = num1 == num1;
            Console.WriteLine($"Сравнение (num1 == num1): {equality}");

            var equality2 = num1 == num2;
            Console.WriteLine($"Сравнение (num1 == num2): {equality2}");

            var equality3 = num1 <= num3;
            Console.WriteLine($"Сравнение (num1 <= num3): {equality3}");
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
