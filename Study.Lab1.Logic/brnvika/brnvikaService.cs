using Study.Lab1.Logic.brnvika.Task1;
using Study.Lab1.Logic.brnvika.Task2;
using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.Interfaces.brnvika.Task2;

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
            var currentDateTime = DateTime.Now;
            IDateFormatter DateTimeFormatter = new AmericanDateFormatter();

            bool fl = true;

            Console.WriteLine("Программа по работе с форматом даты и времени\n0) Взять текущую дату и время\n1) Изменить разделитель\n2) Обособить символами с обоих сторон\n3) Перевести в европейский стиль\n4) Перевести в американский стиль\n5) Вывести дату и время\n6) Завершить работу программы\n");

            while (fl)
            {
                Console.WriteLine("Введите номер инструкции: ");
                int instruction = Convert.ToInt32(Console.ReadLine());
                switch (instruction)
                {
                    case 0:
                        currentDateTime = DateTime.Now;
                        break;
                    case 1:
                        Console.WriteLine("Введите символ-разделитель: ");
                        char symbol = Convert.ToChar(Console.ReadLine());
                        DateTimeFormatter = new AddNewSeparator(DateTimeFormatter, symbol);
                        break;
                    case 2:
                        Console.WriteLine("Введите символ или набор символов для обособления: ");
                        string str = Console.ReadLine();
                        DateTimeFormatter = new IsolateLine(DateTimeFormatter, str);
                        break;
                    case 3:
                        DateTimeFormatter = new EuropeanDateFormatter();
                        break;
                    case 4:
                        DateTimeFormatter = new AmericanDateFormatter();
                        break;
                    case 5:
                        Console.WriteLine($"Date: {DateTimeFormatter.FormatDate(currentDateTime)}");
                        Console.WriteLine($"Time: {DateTimeFormatter.FormatTime(currentDateTime)}");
                        break;
                    case 6:
                        Console.WriteLine("Работа завершена.");
                        fl = false;
                        break;
                    default:
                        Console.WriteLine("Неверный номер инструкции!");
                        break;
                }
            }
        }

        public void RunTask3()
        {
            throw new NotImplementedException();
        }
    }
}
