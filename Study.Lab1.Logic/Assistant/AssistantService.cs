using Study.Lab1.Logic.Assistant.Task2;
using Study.Lab1.Logic.Interfaces;

namespace Study.Lab1.Logic.Assistant
{
    public class AssistantService : IRunService
    {
        public void RunTask1()
        {
            throw new NotImplementedException();
        }

        public void RunTask2()
        {
            var currentDateTime = DateTime.Now;
            var americanFormatter = new AmericanDateFormatter();

            var formattedDate = americanFormatter.FormatDate(currentDateTime);
            Console.WriteLine($"Date: {formattedDate}");

            var formattedTime = americanFormatter.FormatTime(currentDateTime);
            Console.WriteLine($"Time: {formattedTime}");
        }

        public void RunTask3()
        {
            throw new NotImplementedException();
        }
    }
}
