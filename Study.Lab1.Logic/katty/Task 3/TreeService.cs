using Study.Lab1.Logic.Interfaces.katty.Task3;

namespace Study.Lab1.Logic.katty.Task_3;

public class TreeService : ITreeService
{
    public ITreeNode Root { get; private set; }

    public void ConfigureTree()
    {
        Root = new TreeNode("Корень");

        var child1 = new TreeNode("Первый потомок");
        var child2 = new TreeNode("Второй потомок");

        Root.AddChild(child1);
        Root.AddChild(child2);

        var grandChild1 = new TreeNode("Первый внук");
        var grandChild2 = new TreeNode("Второй внук");

        child1.AddChild(grandChild1);
        child1.AddChild(grandChild2);

        var grandGrandChild = new TreeNode("Правнук");
        grandChild2.AddChild(grandGrandChild);
    }

    public bool HasCycles()
    {
        return CheckForCycles(Root, new HashSet<ITreeNode>());
    }

    private bool CheckForCycles(ITreeNode node, HashSet<ITreeNode> visited)
    {
        if (visited.Contains(node))
            return true;

        visited.Add(node);

        foreach (var child in node.Children)
        {
            if (CheckForCycles(child, new HashSet<ITreeNode>(visited)))
                return true;
        }

        return false;
    }
}