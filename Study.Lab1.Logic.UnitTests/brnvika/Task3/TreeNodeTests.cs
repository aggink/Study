using Study.Lab1.Logic.brnvika.Task3;
using System.Text;

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
}
