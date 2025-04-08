using Study.Lab1.Logic.xynthh.Task3;

namespace Study.Lab1.Logic.UnitTests.xynthh.Task3;

[TestFixture]
public class TreeNodeTests
{
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

    [Test]
    public void GetAllChildrenValues_NoChildren_ReturnsEmptyString()
    {
        var node = new TreeNode<string>("Root");

        var result = node.GetAllChildrenValues();

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void GetAllChildrenValues_WithChildren_ReturnsFormattedString()
    {
        var root = new TreeNode<string>("Root");
        var child1 = new TreeNode<string>("Child1");
        var child2 = new TreeNode<string>("Child2");

        root.Add(child1);
        root.Add(child2);

        var result = root.GetAllChildrenValues();

        var expected = $"  - Child1{Environment.NewLine}  - Child2{Environment.NewLine}";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetAllChildrenValues_WithNestedChildren_ReturnsCorrectHierarchy()
    {
        var root = new TreeNode<string>("Root");
        var child1 = new TreeNode<string>("Child1");
        var child2 = new TreeNode<string>("Child2");
        var grandchild1 = new TreeNode<string>("Grandchild1");
        var grandchild2 = new TreeNode<string>("Grandchild2");

        child1.Add(grandchild1);
        child1.Add(grandchild2);
        root.Add(child1);
        root.Add(child2);

        var result = root.GetAllChildrenValues();

        var expected =
            $"  - Child1{Environment.NewLine}" +
            $"    - Grandchild1{Environment.NewLine}" +
            $"    - Grandchild2{Environment.NewLine}" +
            $"  - Child2{Environment.NewLine}";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetAllChildrenValues_DeepNesting_IncrementsIndentationCorrectly()
    {
        var root = new TreeNode<string>("Root");
        var level1 = new TreeNode<string>("Level1");
        var level2 = new TreeNode<string>("Level2");
        var level3 = new TreeNode<string>("Level3");
        var level4 = new TreeNode<string>("Level4");

        level3.Add(level4);
        level2.Add(level3);
        level1.Add(level2);
        root.Add(level1);

        var result = root.GetAllChildrenValues();

        var expected =
            $"  - Level1{Environment.NewLine}" +
            $"    - Level2{Environment.NewLine}" +
            $"      - Level3{Environment.NewLine}" +
            $"        - Level4{Environment.NewLine}";

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetAllChildrenValues_ComplexTree_ReturnsCorrectStructure()
    {
        var root = new TreeNode<int>(1);
        var child1 = new TreeNode<int>(2);
        var child2 = new TreeNode<int>(3);
        var grandchild1 = new TreeNode<int>(4);
        var grandchild2 = new TreeNode<int>(5);
        var grandchild3 = new TreeNode<int>(6);

        child1.Add(grandchild1);
        child1.Add(grandchild2);
        child2.Add(grandchild3);
        root.Add(child1);
        root.Add(child2);

        var result = root.GetAllChildrenValues();

        var expected =
            $"  - 2{Environment.NewLine}" +
            $"    - 4{Environment.NewLine}" +
            $"    - 5{Environment.NewLine}" +
            $"  - 3{Environment.NewLine}" +
            $"    - 6{Environment.NewLine}";

        Assert.That(result, Is.EqualTo(expected));
    }
}