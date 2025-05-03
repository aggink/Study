namespace Study.Lab1.Logic.Interfaces.lsokol14l.Task3;

public interface ITreeNode<T> : IEnumerable<ITreeNode<T>>
{
    /// <summary>
    /// Значение, хранящееся в узле.
    /// </summary>
    T Value { get; set; }

    /// <summary>
    /// Родительский узел (если есть).
    /// </summary>
    ITreeNode<T>? Parent { get; }

    /// <summary>
    /// Коллекция дочерних узлов (только для чтения).
    /// </summary>
    IReadOnlyList<ITreeNode<T>> Children { get; }

    /// <summary>
    /// Добавление дочернего узла.
    /// </summary>
    void Add(ITreeNode<T> child);

    /// <summary>
    /// Удаление дочернего узла.
    /// </summary>
    bool Remove(ITreeNode<T> child);

    /// <summary>
    /// Очистка всех дочерних узлов.
    /// </summary>
    void Clear();

    /// <summary>
    /// Возвращает true, если узел является листом (не имеет потомков).
    /// </summary>
    bool IsLeaf { get; }

    /// <summary>
    /// Глубина узла в дереве (0 для корня).
    /// </summary>
    int Depth { get; }

    /// <summary>
    /// Доступ к дочернему узлу по индексу.
    /// </summary>
    ITreeNode<T> this[int index] { get; }

    /// <summary>
    /// Поиск первого узла по значению (обход в глубину, pre-order).
    /// </summary>
    ITreeNode<T>? Find(T value);

    /// <summary>
    /// Возвращает все узлы в порядке обхода (по умолчанию pre-order).
    /// </summary>
    IEnumerable<ITreeNode<T>> PreOrder();

    /// <summary>
    /// Возвращает все узлы в порядке обратного обхода.
    /// </summary>
    IEnumerable<ITreeNode<T>> PostOrder();

    /// <summary>
    /// Возвращает все узлы в порядке обхода в ширину.
    /// </summary>
    IEnumerable<ITreeNode<T>> BreadthFirst();
}