using Study.Lab1.Logic.Interfaces.katty.Task2;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.katty.Task_2
{
    public class NextDecorator : DateTimeDecorator
    {
        private readonly string _next;

        public NextDecorator(IDateTimeFormatter formatter, string next) : base(formatter)
        {
            _next = next;
        }

        public override string FormatDateTime(DateTime dateTime)
        {
            StringBuilder tmp = new StringBuilder();
            tmp.Append(_formatter.FormatDateTime(dateTime));
            tmp.Append(_next);
            return tmp.ToString();
        }
    }
}
