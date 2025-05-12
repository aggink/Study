using Study.Lab1.Logic.Interfaces.katty.Task2;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.katty.Task_2
{
    public class StartDecorator : DateTimeDecorator
    {
        private readonly string _start;

        public StartDecorator(IDateTimeFormatter formatter, string start) : base(formatter)
        {
            _start = start;
        }

        public override string FormatDateTime(DateTime dateTime)
        {
            StringBuilder tmp = new StringBuilder();
            tmp.Append(_start);
            tmp.Append(_formatter.FormatDateTime(dateTime));
            return tmp.ToString();
        }
    }

}
