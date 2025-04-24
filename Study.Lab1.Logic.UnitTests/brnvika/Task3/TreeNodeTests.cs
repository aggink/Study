using Study.Lab1.Logic.brnvika.Task3;

namespace Study.Lab1.Logic.UnitTests.brnvika.Task3;

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

        Assert.That(result, Is.EqualTo("  -> Child 1\r\n    -> Grandchild 1\r\n      -> GrandGrandchild 1.1\r\n      -> GrandGrandchild 1.2\r\n  -> Child 2\r\n    -> Grandchild 2\r\n      -> GrandGrandchild 2.1\r\n"));
    }
}
