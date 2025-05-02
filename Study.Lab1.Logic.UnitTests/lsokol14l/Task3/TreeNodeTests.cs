using System.Text;
using Study.Lab1.Logic.lsokol14l.Task3;

namespace Study.Lab1.Logic.UnitTests.lsokol14l.Task3;

[TestFixture]
public class TreeNodeTests
{
    [Test]
    public void Test1()
    {
        var parent1 = new TreeNode<string>("Parent");
        var child11 = new TreeNode<string>("Child 1");
        var child12 = new TreeNode<string>("Child 2");

        var grandChild1 = new TreeNode<string>("Grandchild 1");
        var grandGrandChild11 = new TreeNode<string>("GrandGrandchild 1.1");
        var grandGrandChild12 = new TreeNode<string>("GrandGrandchild 1.2");

        var grandChild2 = new TreeNode<string>("Grandchild 2");
        var grandGrandChild21 = new TreeNode<string>("GrandGrandchild 2.1");

        grandChild1.Add(grandGrandChild11);
        grandChild1.Add(grandGrandChild12);
        grandChild2.Add(grandGrandChild21);

        child11.Add(grandChild1);
        child12.Add(grandChild2);

        parent1.Add(child11);
        parent1.Add(child12);

        var result = parent1.GetAllChildrenValues();

        var sb = new StringBuilder();
        sb.AppendLine("  -> Child 1");
        sb.AppendLine("    -> Grandchild 1");
        sb.AppendLine("      -> GrandGrandchild 1.1");
        sb.AppendLine("      -> GrandGrandchild 1.2");
        sb.AppendLine("  -> Child 2");
        sb.AppendLine("    -> Grandchild 2");
        sb.AppendLine("      -> GrandGrandchild 2.1");

        Assert.That(result, Is.EqualTo(sb.ToString()));
    }

    [Test]
    public void NewNode_HasEmptyChildrenList()
    {
        var node = new TreeNode<string>("Root");

        Assert.That(node.Children, Is.Empty);
    }

    [Test]
    public void Add_AddsChildToChildrenList()
    {
        var root = new TreeNode<string>("Root");
        var child = new TreeNode<string>("Child");

        root.Add(child);

        Assert.That(root.Children.Count, Is.EqualTo(1));
        Assert.That(root.Children[0], Is.EqualTo(child));
    }

    [Test]
    public void Add_MultipleChildren_AddsAllToChildrenList()
    {
        var root = new TreeNode<string>("Root");
        var child1 = new TreeNode<string>("Child1");
        var child2 = new TreeNode<string>("Child2");
        var child3 = new TreeNode<string>("Child3");

        root.Add(child1);
        root.Add(child2);
        root.Add(child3);

        Assert.That(root.Children.Count, Is.EqualTo(3));
        Assert.That(root.Children, Does.Contain(child1));
        Assert.That(root.Children, Does.Contain(child2));
        Assert.That(root.Children, Does.Contain(child3));
    }

    [Test]
    public void Value_CanBeSetAndRetrieved()
    {
        var node = new TreeNode<int>(5);

        node.Value = 10;

        Assert.That(node.Value, Is.EqualTo(10));
    }
}
