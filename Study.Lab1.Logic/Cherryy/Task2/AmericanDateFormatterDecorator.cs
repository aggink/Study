using Study.Lab1.Logic.Interfaces.Cherryy.Task2;

namespace Study.Lab1.Logic.Cherryy.Task2
{
    public class AmericanDateFormatterDecorator : IFormatDate
    {
        private AmericanDateTimeFormatter _timeFormatter;

        public AmericanDateFormatterDecorator(AmericanDateTimeFormatter timeFormatter)
        {
            _timeFormatter = timeFormatter;
        }

        public string FormatDateTime(DateTime dateTime)
        {
            var text = _timeFormatter.FormatDateTime(dateTime);
            return $"American; {text}";
        }
    }
}
