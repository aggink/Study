namespace Study.Lab1.Logic.Interfaces.neijrr.Task3;

/// <summary>
/// Интерфейс, реализующий вывод в виде узлов дерева
/// </summary>
public interface ITreeObject
{
    /// <summary>
    /// Вывод узлов
    /// </summary>
    /// <param name="level"> Глубина вывода узлов </param>
    /// <remarks>
    /// При <paramref name="level"/> = 0 или отсутствии дочерних узлов эквивалентно Value.ToString()
    /// При <paramref name="level"/> < 0 выводятся все узлы
    /// </remarks>
    /// <returns>
    /// Строка с значением данного узла и дочерних узлов до указанной глубины
    /// </returns>
    string ToString(int level);

    /// <summary>
    /// Вывод узлов
    /// </summary>
    /// <param name="recursive"> Нужно ли выводить значения дочерних узлов </param>
    /// <remarks>
    /// При <paramref name="recursive"/> = false или отсутствии дочерних узлов эквивалентно Value.ToString()
    /// </remarks>
    /// <returns>
    /// Строка с значением данного узла и (при <paramref name="recursive"/> = true) дочерних узлов
    /// </returns>
    string ToString(bool recursive);
}
