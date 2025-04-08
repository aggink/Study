namespace Study.Lab1.Logic.Interfaces.xynthh.Task3;

public interface ITreeNode<T>
{
    /// <summary>
    /// Значение узла.
    /// </summary>
    T Value { get; set; }

    /// <summary>
    /// Список дочерних узлов (IReadOnlyList вместо List потому что список потомков доступен только для чтения)
    /// </summary>
    IReadOnlyList<ITreeNode<T>> Children { get; }

    /// <summary>
    /// Добавление дочернего узла
    /// </summary>
    /// <param name="child"></param>
    void Add(ITreeNode<T> child);

    /// <summary>
    /// Вывод всех дочерних узлов в виде строки
    /// </summary>
    /// <returns>Строка с дочерними узлами</returns>
    string GetAllChildrenValues();
}