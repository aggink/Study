using Study.Lab1.Logic.Interfaces.brnvika.Task2;
using System.Text;

namespace Study.Lab1.Logic.brnvika.Task2;

public class AddNewSeparator : BaseDateDecorator
{
    private readonly char _symbol = ' ';

    public AddNewSeparator(IDateFormatter dateFormatter, char symbol) : base(dateFormatter)
    {
        _symbol = symbol;
    }

    public override string FormatDate(DateTime date)
    {
        var DecorateDate = new StringBuilder();
        var StringDate = _dateFormatter.FormatDate(date);

        int CountNum = 0;
        int fl = 0;

        for (int i = 0; i < StringDate.Length; i++)
        {
            IsNumber(StringDate[i], ref CountNum);
            DecorateDate.Append(StringDate[i]);
            if (CountNum == 2 && fl != 2)
            {
                DecorateDate.Append(_symbol);
                fl++;
                CountNum = 0;
                i++;
            }
        }

        return DecorateDate.ToString();
    }

    public override string FormatTime(DateTime date)
    {
        var DecorateTime = new StringBuilder();
        string StringDate = _dateFormatter.FormatTime(date);

        int CountNum = 0;
        int fl = 0;

        for (int i = 0; i < StringDate.Length; i++)
        {
            IsNumber(StringDate[i], ref CountNum);
            DecorateTime.Append(StringDate[i]);
            if (CountNum == 2 && fl != 2)
            {
                DecorateTime.Append(_symbol);
                fl++;
                CountNum = 0;
                i++;
            }
        }

        return DecorateTime.ToString();
    }

    private void IsNumber(char c, ref int count)
    {
        var numbers = "0123456789";

        for (int i = 0; i < 10; i++)
        {
            if (c == numbers[i])
            {
                count++;
                break;
            }
        }
    }
}
