namespace Study.Lab1.Logic.Interfaces.lsokol14l.Task3
{
    interface ITree<T>
    {
        void OutputChildern();

        void Add(ITree<T> child);
    }
}
