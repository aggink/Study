using System.Collections;
using System.Text;

namespace Study.Lab1.Logic.lsokol14l.Task3;

public class TreeNode<T> : IEnumerable<TreeNode<T>>
{
    public T Value { get; set; }

    public TreeNode<T> Parent { get; private set; }

    private readonly List<TreeNode<T>> _children = new();

    public IReadOnlyList<TreeNode<T>> Children => _children;

    public TreeNode(T value)
    {
        Value = value;
    }

    public void Add(TreeNode<T> child)
    {
        if (child == null)
            throw new ArgumentNullException(nameof(child));

        child.Parent = this;
        _children.Add(child);
    }

    public bool Remove(TreeNode<T> child)
    {
        if (_children.Remove(child))
        {
            child.Parent = null;
            return true;
        }

        return false;
    }

    public void Clear()
    {
        foreach (var child in _children)
            child.Parent = null;

        _children.Clear();
    }

    public int ChildCount => _children.Count;
    public bool IsLeaf => _children.Count == 0;

    public TreeNode<T> this[int index] => _children[index];

    public int Depth
    {
        get
        {
            int depth = 0;
            var current = Parent;

            while (current != null)
            {
                depth++;
                current = current.Parent;
            }

            return depth;
        }
    }

    // Поиск первого узла по значению (pre-order)
    public TreeNode<T> Find(T value)
    {
        if (EqualityComparer<T>.Default.Equals(Value, value))
            return this;

        foreach (var child in _children)
        {
            var result = child.Find(value);
            if (result != null)
                return result;
        }

        return null;
    }

    // Pre-order traversal (рекурсивный)
    public IEnumerable<TreeNode<T>> PreOrder()
    {
        yield return this;

        foreach (var child in _children)
        {
            foreach (var node in child.PreOrder())
                yield return node;
        }
    }

    // Post-order traversal
    public IEnumerable<TreeNode<T>> PostOrder()
    {
        foreach (var child in _children)
        {
            foreach (var node in child.PostOrder())
                yield return node;
        }

        yield return this;
    }

    // Breadth-first (level-order) traversal
    public IEnumerable<TreeNode<T>> BreadthFirst()
    {
        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            yield return current;

            foreach (var child in current._children)
                queue.Enqueue(child);
        }
    }

    // Поддержка foreach (по умолчанию — pre-order)
    public IEnumerator<TreeNode<T>> GetEnumerator() => PreOrder().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // Вывод дерева в строку
    public string ToPrettyString(string indent = "")
    {
        var result = $"{indent}{Value}\n";
        foreach (var child in _children)
        {
            result += child.ToPrettyString(indent + "  ");
        }

        return result;
    }

    private void BuildString(StringBuilder sb, TreeNode<T> node, int level)
    {
        string indent = new string(' ', level * 2);
        sb.AppendLine($"{indent}-> {node.Value}");

        foreach (var child in node.Children)
        {
            BuildString(sb, child, level + 1);
        }
    }

    public string GetAllChildrenValues()
    {
        var sb = new StringBuilder();
        foreach (var child in Children)
        {
            BuildString(sb, child, 1);
        }

        return sb.ToString();
    }
}

