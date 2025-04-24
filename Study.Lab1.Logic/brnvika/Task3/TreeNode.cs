using Study.Lab1.Logic.Interfaces.brnvika.Task3;
using System.Text;
namespace Study.Lab1.Logic.brnvika.Task3;

public class TreeNode<T>(T value) : ITreeNode<T>
{
    public T Value { get; set; } = value;
    public IReadOnlyList<ITreeNode<T>> Children => _children.AsReadOnly();
    private readonly List<ITreeNode<T>> _children = new();

    public void Add(ITreeNode<T> child)
    {
        _children.Add(child);
    }

    public string GetAllChildrenValues()
    {
        var result = new StringBuilder();

        foreach (var child in Children)
            AppendNodeValue(result, child, 1);

        return result.ToString();
    }

    private void AppendNodeValue(StringBuilder sb, ITreeNode<T> node, int level)
    {
        sb.AppendLine($"{new string(' ', level * 2)}-> {node.Value}");
        foreach (var child in node.Children)
            AppendNodeValue(sb, child, level + 1);
    }
}
