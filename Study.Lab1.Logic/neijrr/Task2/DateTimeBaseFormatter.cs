using System.Text;
using Study.Lab1.Logic.Interfaces.neijrr.Task2;

namespace Study.Lab1.Logic.neijrr.Task2
{
    public abstract class DateTimeBaseFormatter : IDateTimeFormatter
    {
        public abstract StringBuilder DateTimeStringBuilder(DateTime? datetime);

        public abstract StringBuilder DateStringBuilder(DateTime? datetime);

        public abstract StringBuilder TimeStringBuilder(DateTime? datetime, bool includeSeconds);

        public string DateTime(DateTime? datetime = null) => DateTimeStringBuilder(datetime).ToString();

        public string Date(DateTime? datetime = null) => DateStringBuilder(datetime).ToString();

        public string Time(DateTime? datetime = null, bool includeSeconds = true) => TimeStringBuilder(datetime, includeSeconds).ToString();
    }
}
