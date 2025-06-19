using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Lab1.Logic.baldfromazzers.Task1;
using Study.Lab1.Logic.Interfaces;

namespace Study.Lab1.Logic.baldfromazzers
{
    public class baldfromazzersService : IRunService
    {
        public void RunTask1()
        {
            var a = new RationalNumber(2, 4);
            var b = new RationalNumber(2, 6);
            var c = new RationalNumber(2, 8);
            var d = new RationalNumber(7, 3);
            var e = new RationalNumber(-10, -1);

            var sum = a + b;
            var difference = a - b;
            var product = a * b;
            var quotient = a / b;
            var areEqual = a == b; 

            Console.Write($"a: {a}, b: {b}, c:2/8\n" +
                          $"a + b = {sum}\n" +
                          $"a - b = {difference}\n" +
                          $"a * b = {product}\n" +
                          $"a / b = {quotient}\n" +
                          $"a == b ? {areEqual}\n" +
                          $"c: {c}\n" +
                          $"d: {d}\n" +
                          $"e: {e}\n" +
                          $"-e: {-e}\n" +
                          $"a>b: {a > b}\n" +
                          $"b<a: {b < a}\n" +
                          $"c<=b: {c <= b}\n" +
                          $"d>=b: {d >= b}\n"
            );


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
