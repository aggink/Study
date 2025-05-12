namespace Study.Lab1.Logic.Interfaces.katty.Task3;
public interface ITreeService
{
    ITreeNode Root { get; }
    void ConfigureTree();
    bool HasCycles();
}