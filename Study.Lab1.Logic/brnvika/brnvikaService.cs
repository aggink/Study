using Study.Lab1.Logic.brnvika.Task1;
using Study.Lab1.Logic.Interfaces;

namespace Study.Lab1.Logic.brnvika
{
    public class brnvikaService : IRunService
    {
        public void RunTask1()
        {
            var num = new RationalNumbers(1, 1);
            Console.WriteLine("num = {0}", num.ToString());

            var num2 = new RationalNumbers(10, 2);
            Console.WriteLine("num2 = {0}", num2.ToString());

            var num3 = new RationalNumbers(5, 10);
            Console.WriteLine("num3 = {0}", num3.ToString());

            var num4 = new RationalNumbers(1, -3);
            Console.WriteLine("num4 = {0}", num4.ToString());

            var num5 = new RationalNumbers(-6, 8);
            Console.WriteLine("num5 = {0}", num5.ToString());

            var num6 = new RationalNumbers(12, 5);
            Console.WriteLine("num6 = {0}", num6.ToString());

            Console.WriteLine("num + num3 = {0}", (num + num3).ToString());
            Console.WriteLine("num2 - num3 = {0}", (num2 - num3).ToString());
            Console.WriteLine("num5 * num4 = {0}", (num5 * num4).ToString());
            Console.WriteLine("num6 / num5 = {0}", (num6 / num5).ToString());
            Console.WriteLine("-num4 = {0}", (-num4).ToString());
            Console.WriteLine("num == num3 - {0}", (num == num3).ToString());
            Console.WriteLine("num != num6 - {0}", (num != num6).ToString());
            Console.WriteLine("num2 > num3 - {0}", (num2 > num3).ToString());
            Console.WriteLine("num2 >= num6 - {0}", (num2 >= num6).ToString());
            Console.WriteLine("num2 < num3 - {0}", (num2 < num3).ToString());
            Console.WriteLine("num2 <= num6 - {0}", (num2 <= num6).ToString());
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
