using Study.Lab1.Logic.Interfaces.kinkiss1.task2;
using System.Globalization;
using System.Text;

namespace Study.Lab1.Logic.kinkiss1.Task2
{
    public class AmericanDateFormat : IFormatDate
    {
        private readonly CultureInfo _culture = new("en-US");

        public string FormatDateTime()
        {
            var us = new StringBuilder();
            us.Append(DateTime.Now.ToString("g", _culture)); // Добавлено время
            return us.ToString();
        }
    }
}