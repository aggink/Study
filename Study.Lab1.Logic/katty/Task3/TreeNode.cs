using Study.Lab1.Logic.Interfaces.katty.Task3;
using System.Text;

namespace Study.Lab1.Logic.katty.Task3;

public class TreeNode : ITreeNode
{
    private readonly List<ITreeNode> _children = new();

    public string Value { get; }

    public TreeNode(string value)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public IReadOnlyList<ITreeNode> Children => _children.AsReadOnly();

    public void AddChild(ITreeNode node)
    {
        if (node == null)
            throw new ArgumentNullException(nameof(node));

        _children.Add(node);
    }

    public string GetTreeAsString()
    {
        var sb = new StringBuilder();
        BuildTreeString(this, 0, sb);
        return sb.ToString();
    }

    public IEnumerable<string> GetAllValues()
    {
        yield return Value;

        foreach (var child in Children)
        {
            foreach (var value in child.GetAllValues())
            {
                yield return value;
            }
        }
    }

    private static void BuildTreeString(ITreeNode node, int depth, StringBuilder sb)
    {
        sb.AppendLine($"{new string(' ', depth * 2)}{node.Value}");

        foreach (var child in node.Children)
        {
            BuildTreeString(child, depth + 1, sb);
        }
    }
}