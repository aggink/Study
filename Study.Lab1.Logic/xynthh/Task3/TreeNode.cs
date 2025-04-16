using System.Text;
using Study.Lab1.Logic.Interfaces.xynthh.Task3;

namespace Study.Lab1.Logic.xynthh.Task3;

public class TreeNode<T> : ITreeNode<T>
{
    public TreeNode(T value)
    {
        Value = value;
    }

    #region Properties

    public T Value { get; set; }

    public IReadOnlyList<ITreeNode<T>> Children => _children.AsReadOnly();

    private readonly List<ITreeNode<T>> _children = new();

    #endregion

    #region Methods

    public void Add(ITreeNode<T> child)
    {
        _children.Add(child);
    }

    public string GetAllChildrenValues()
    {
        var sb = new StringBuilder();

        foreach (var child in Children)
            AppendNodeValue(sb, child, 1);

        return sb.ToString();
    }

    /// <summary>
    /// Рекурсивно добавляет в StringBuilder значение узла и всех его потомков с отступами,
    /// зависящими от уровня вложенности.
    /// </summary>
    /// <param name="sb">StringBuilder в который будет помещен отформатированный вывод</param>
    /// <param name="node">Узел дерева, значение которого необходимо добавить</param>
    /// <param name="level">Уровень вложенности узла, определяющий отступ</param>
    private void AppendNodeValue(StringBuilder sb, ITreeNode<T> node, int level)
    {
        sb.AppendLine($"{new string(' ', level * 2)}- {node.Value}");
        foreach (var child in node.Children)
            AppendNodeValue(sb, child, level + 1);
    }

    #endregion
}