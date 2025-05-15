namespace Study.Lab1.Logic.Interfaces.katty.Task3;

public interface ITreeNode
{
    string Value { get; }

    IReadOnlyList<ITreeNode> Children { get; }

    void AddChild(ITreeNode node);

    string GetTreeAsString();

    IEnumerable<string> GetAllValues();
}
