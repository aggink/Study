namespace Study.Lab1.Logic.Interfaces.Selestz.Task3;

public interface ITreeNode<T>
{
    /// <summary>
    /// Значение узла.
    /// </summary>
    T Value { get; set; }

    /// <summary>
    /// Список нижних узлов
    /// </summary>
    IReadOnlyList<ITreeNode<T>> Children { get; }

    /// <summary>
    /// Добавление нижнего узла
    /// </summary>
    /// <param name="child"></param>
    void Add(ITreeNode<T> child);

    /// <summary>
    /// Вывод всех нижестоящих узлов
    /// </summary>
    /// <returns>Строка с нижествоящими узлами</returns>
    string GetTree();
}