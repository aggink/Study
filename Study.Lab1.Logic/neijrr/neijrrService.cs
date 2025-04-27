using Study.Lab1.Logic.Interfaces;
using Study.Lab1.Logic.neijrr.Task2;
using Study.Lab1.Logic.neijrr.Task3;

namespace Study.Lab1.Logic.neijrr
{
    public class neijrrService : IRunService
    {
        /// <summary>
        /// Находит наибольший общий делитель
        /// </summary>
        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public void RunTask1()
        {
            var a = new Fraction(2, 3);
            var b = new Fraction(1, 6);
            var c = a + b;

            Console.WriteLine($"{a} + {b} = {c}");
        }

        public void RunTask2()
        {
            var euFormatter = new EuropeanDateTimeFormatter();
            var euDateFormatter = new PrefixDecorator(euFormatter, "Сегодня ");
            var euTimeFormatter = new SuffixDecorator(new PrefixDecorator(euFormatter, "Время: ["), "]");

            var amFormatter = new AmericanDateTimeFormatter();
            var amDateFormatter = new PrefixDecorator(amFormatter, "Сегодня ");
            var amTimeFormatter = new SuffixDecorator(new PrefixDecorator(amFormatter, "Время: ["), "]");

            Console.WriteLine("Европейский формат:");
            Console.WriteLine(euDateFormatter.Date());
            Console.WriteLine(euTimeFormatter.Date());

            Console.WriteLine("Американский формат:");
            Console.WriteLine(amDateFormatter.Date());
            Console.WriteLine(amTimeFormatter.Date());

            Console.WriteLine("Unix epoch:");
            Console.WriteLine($"Европейский формат: {euFormatter.DateTime(DateTime.UnixEpoch)}");
            Console.WriteLine($"Американский формат: {amFormatter.DateTime(DateTime.UnixEpoch)}");
        }

        public void RunTask3()
        {
            var objectTree = new TreeNode("Корень дерева")
            {
                new TreeNode("Это дерево может содержать узлы с значением разных типов") {
                    new TreeNode("Этот узел вложен в дочерний узел")
                },
                new TreeNode(0.5),
                new TreeNode(2)
            };

            Console.WriteLine($"Значение начала дерева: {objectTree}");
            Console.WriteLine("1-й уровень:");
            Console.WriteLine(objectTree.ToString(1));
            Console.WriteLine("Полная репрезентация:");
            Console.WriteLine(objectTree.ToString(true));

            var stringTree = new TreeNode<string>("Корень дерева строк") {
                "Дерево определённого типа",

                "Эта строка будет удалена",

                "поддерживает операции",
                new TreeNode<string>("с данным типом") {
                    "При этом в объекте хранятся"
                }
            };
            stringTree.RemoveValue("Эта строка будет удалена");
            stringTree[2].Add("только объекты типа TreeNode<T>");

            Console.WriteLine(stringTree.ToString(-1)); // Всё равно что ToString(true)
        }
    }
}
