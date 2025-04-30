namespace Study.Lab1.Logic.Interfaces.neijrr.Task3
{
    /// <summary>
    /// Интерфейс, реализующий узел дерева с одним типом значений
    /// </summary>
    public interface ITreeNode<T> : ITreeObject, IList<ITreeNode<T>>
    {
        /// <value> Значение данного узла </value>
        T Value { get; set; }

        /// <summary>
        /// Добавить дочерний узел
        /// </summary>
        /// <param name="value"> Значение дочернего узла </param>
        public void Add(T value);

        /// <summary>
        /// Вставить дочерний узел
        /// </summary>
        /// <param name="index"> Позиция нового узла </param>
        /// <param name="value"> Значение дочернего узла </param>
        public void Insert(int index, T value);

        /// <summary>
        /// Удалить первый дочерний узел с указанным значением
        /// </summary>
        /// <param name="value"> Значение дочернего узла </param>
        public void RemoveValue(T value);
    }
}
