namespace Study.Lab1.Logic.Interfaces.neijrr.Task3
{
    /// <summary>
    /// Интерфейс, реализующий узел дерева
    /// </summary>
    public interface ITreeNode : ITreeObject, IList<ITreeNode>
    {
        /// <value> Значение данного узла </value>
        object Value { get; set; }
    }
}
