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
            us.Append(DateTime.Now.ToString("d", _culture));
            return us.ToString();
        }
    }

    public class AmericanDateFormatDecorator1 : IFormatDate
    {
        private readonly AmericanDateFormat _americanDateFormat;

        public AmericanDateFormatDecorator1(AmericanDateFormat format)
        {
            _americanDateFormat = format;
        }

        public string FormatDateTime()
        {
            return $"American date format: {_americanDateFormat.FormatDateTime()}";
        }
    }

    public class AmericanDateFormatDecorator2 : IFormatDate
    {
        private readonly IFormatDate _formatDate;

        public AmericanDateFormatDecorator2(IFormatDate formatDate)
        {
            _formatDate = formatDate;
        }

        public string FormatDateTime()
        {
            return $"[Decorated] {_formatDate.FormatDateTime()}";
        }
    }

    public class AmericanDateFormatDecorator3 : IFormatDate
    {
        private readonly IFormatDate _formatDate;

        public AmericanDateFormatDecorator3(IFormatDate formatDate)
        {
            _formatDate = formatDate;
        }

        public string FormatDateTime()
        {
            return $"*** {_formatDate.FormatDateTime()} ***";
        }
    }
}