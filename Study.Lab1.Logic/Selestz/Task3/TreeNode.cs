using System.Text;
using Study.Lab1.Logic.Interfaces.Selestz.Task3;

namespace Study.Lab1.Logic.Selestz.Task3;

public class TreeNode<T> : ITreeNode<T>
{
    public T Value { get; set; }

    private readonly List<ITreeNode<T>> _children = new();

    public TreeNode(T value)
    {
        Value = value;
    }

    public IReadOnlyList<ITreeNode<T>> Children => _children.AsReadOnly();

    public void Add(ITreeNode<T> child)
    {
        _children.Add(child);
    }

    public string GetTree()
    {
        var sb = new StringBuilder();

        foreach (var child in Children)
            AppendNodeValue(sb, child, 1);

        return sb.ToString();
    }

    private void AppendNodeValue(StringBuilder sb, ITreeNode<T> node, int level)
    {
        sb.AppendLine($"{new string('-', level * 2)}→ {node.Value}");

        foreach (var child in node.Children)
            AppendNodeValue(sb, child, level + 1);
    }
}