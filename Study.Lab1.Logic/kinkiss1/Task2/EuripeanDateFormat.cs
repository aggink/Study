using Study.Lab1.Logic.Interfaces.kinkiss1.task2;
using System.Globalization;
using System.Text;

namespace Study.Lab1.Logic.kinkiss1.Task2
{
    public class EurepeanDateFormat : IFormatDate
    {
        private readonly CultureInfo _culture = new("fr-FR");

        public string FormatDateTime()
        {
            var fr = new StringBuilder();
            fr.Append(DateTime.Now.ToString("d", _culture));
            return fr.ToString();
        }
    }


    public class EurepeanDateFormatDecorator1 : IFormatDate
    {
        private readonly EurepeanDateFormat _europeanDateFormat;

        public EurepeanDateFormatDecorator1(EurepeanDateFormat format)
        {
            _europeanDateFormat = format;
        }

        public string FormatDateTime()
        {
            return $"European date format: {_europeanDateFormat.FormatDateTime()}";
        }
    }
    public class EuropeanDateFormatDecorator2 : IFormatDate
    {
        private readonly IFormatDate _formatDate;

        public EuropeanDateFormatDecorator2(IFormatDate formatDate)
        {
            _formatDate = formatDate;
        }

        public string FormatDateTime()
        {
            return $"[Decorated] {_formatDate.FormatDateTime()}";
        }
    }

    public class EuropeanDateFormatDecorator3 : IFormatDate
    {
        private readonly IFormatDate _formatDate;

        public EuropeanDateFormatDecorator3(IFormatDate formatDate)
        {
            _formatDate = formatDate;
        }

        public string FormatDateTime()
        {
            return $"*** {_formatDate.FormatDateTime()} ***";
        }
    }
}