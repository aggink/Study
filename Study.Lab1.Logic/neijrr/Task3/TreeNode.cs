using Study.Lab1.Logic.Interfaces.neijrr.Task3;
using System.Text;

namespace Study.Lab1.Logic.neijrr.Task3;

public class TreeNode(object value) : List<ITreeNode>, ITreeNode
{
    public object Value { get; set; } = value;

    public string ToString(int level)
    {
        if (level == 0 || Count <= 0)
            return Value.ToString();
        else if (level < 0)
            return ToString(true);

        var sb = new StringBuilder(Value.ToString());
        sb.Append('\n');

        foreach (var node in this)
        {
            var lines = node.ToString(level - 1).Split('\n');
            foreach (var l in lines)
            {
                sb.Append("| ");
                sb.AppendLine(l);
            }
        }

        return sb.ToString().TrimEnd();
    }

    public string ToString(bool recursive = false)
    {
        if (!recursive || Count <= 0)
            return Value.ToString();

        var sb = new StringBuilder(Value.ToString());
        sb.Append('\n');

        foreach (var node in this)
        {
            var lines = node.ToString(true).Split('\n');
            foreach (var l in lines)
            {
                sb.Append("| ");
                sb.AppendLine(l);
            }
        }

        return sb.ToString().TrimEnd();
    }
}
