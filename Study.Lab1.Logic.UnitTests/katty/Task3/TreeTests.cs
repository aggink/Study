using Study.Lab1.Logic.Interfaces.katty.Task3;
using Study.Lab1.Logic.katty.Task_3;

namespace Study.Lab1.Logic.UnitTests.katty.Task3;

[TestFixture]
public class TreeTests
{
    private ITreeService _treeService;

    [SetUp]
    public void Setup()
    {
        _treeService = new TreeService();
        _treeService.BuildSampleTree();
    }

    [Test]
    public void BuildSampleTree_Should_Create_Correct_Root()
    {
        Assert.That(_treeService.Root, Is.Not.Null);
        Assert.That(_treeService.Root.Value, Is.EqualTo("Корень"));
    }

    [Test]
    public void Tree_Should_Not_Have_Cycles()
    {
        Assert.That(_treeService.HasCycles(), Is.False);
    }

    [Test]
    public void IsValidTree_Should_Return_True_For_Valid_Tree()
    {
        Assert.That(_treeService.IsValidTree(), Is.True);
    }

    [Test]
    public void GetTreeAsString_Should_Return_Correct_Structure()
    {
        var result = _treeService.Root.GetTreeAsString();

        Assert.That(result, Does.Contain("Корень"));
        Assert.That(result, Does.Contain("Первый потомок"));
        Assert.That(result, Does.Contain("Второй внук"));
        Assert.That(result, Does.Contain("Правнук"));
    }

    [Test]
    public void GetAllValues_Should_Return_All_Nodes()
    {
        var values = _treeService.Root.GetAllValues().ToList();

        Assert.That(values, Has.Count.EqualTo(6));
        Assert.That(values, Does.Contain("Корень"));
        Assert.That(values, Does.Contain("Правнук"));
    }

    [Test]
    public void AddChild_Should_Throw_When_Null()
    {
        var node = new TreeNode("Тест");
        Assert.Throws<ArgumentNullException>(() => node.AddChild(null));
    }
}