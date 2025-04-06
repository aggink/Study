using System.Text;
using Study.Lab1.Logic.Interfaces.lsokol14l.Task2;

namespace Study.Lab1.Logic.lsokol14l.Task2
{
    public class AddPrefixDecorator : DateTimeDecoratorBase
    {
        private readonly string _prefix;
        /// <summary>
        ///     
        /// </summary>
        /// <param name="wrappedFormatter">Принимает в себя ссылку на обьект реализующий 
        ///     интерфейс IDatetimeFormatter
        /// </param>
        public AddPrefixDecorator(IDateFormatter wrappedFormatter, string prefix) : base(wrappedFormatter)
        {
            _prefix = prefix;
        }

        public override string FormatDate(DateTime date)
        {
            var sb = new StringBuilder();
            sb.Append(_prefix);
            sb.Append(WrappedFormatter.FormatDate(date));

            return sb.ToString();
        }
        public override string FormatTime(DateTime time)
        {
            var sb = new StringBuilder();
            sb.Append(_prefix);
            sb.Append(WrappedFormatter.FormatTime(time));

            return sb.ToString();
        }

    }
}
