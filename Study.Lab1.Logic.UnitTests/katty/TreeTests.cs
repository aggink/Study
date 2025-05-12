using Study.Lab1.Logic.katty.Task_3;

namespace Study.Lab1.Logic.UnitTests.katty
{
    [TestFixture]
    public class TreeTests
    {
        [Test]
        public void Tree_Should_Have_Root_Node()
        {
            // Arrange
            var treeService = new TreeService();

            // Act
            treeService.ConfigureTree();

            // Assert
            Assert.That(treeService.Root, Is.Not.Null);
            Assert.That(treeService.Root.Value, Is.EqualTo("Корень"));
        }

        [Test]
        public void Tree_Should_Not_Have_Cycles()
        {
            // Arrange
            var treeService = new TreeService();
            treeService.ConfigureTree();

            // Act
            var hasCycles = treeService.HasCycles();

            // Assert
            Assert.That(hasCycles, Is.False);
        }

        [Test]
        public void Node_Should_Print_Children_Correctly()
        {
            // Arrange
            var treeService = new TreeService();
            treeService.ConfigureTree();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            treeService.Root.PrintChildrenValues();
            var output = stringWriter.ToString();

            // Assert
            Assert.That(output, Does.Contain("Первый потомок"));
            Assert.That(output, Does.Contain("Второй потомок"));
            Assert.That(output, Does.Contain("Первый внук"));
            Assert.That(output, Does.Contain("Второй внук"));
            Assert.That(output, Does.Contain("Правнук"));
        }

        [Test]
        public void Adding_Child_Should_Work_Correctly()
        {
            // Arrange
            var parent = new TreeNode("Родитель");
            var child = new TreeNode("Ребенок");

            // Act
            parent.AddChild(child);

            // Assert
            Assert.That(parent.Children, Has.Count.EqualTo(1));
            Assert.That(parent.Children[0].Value, Is.EqualTo("Ребенок"));
        }

        [Test]
        public void Tree_Should_Have_Correct_Structure()
        {
            // Arrange
            var treeService = new TreeService();
            treeService.ConfigureTree();

            // Act
            var root = treeService.Root;

            // Assert
            Assert.That(root.Children, Has.Count.EqualTo(2));
            Assert.That(root.Children[0].Value, Is.EqualTo("Первый потомок"));
            Assert.That(root.Children[1].Value, Is.EqualTo("Второй потомок"));

            // Проверяем первого потомка
            var firstChild = root.Children[0];
            Assert.That(firstChild.Children, Has.Count.EqualTo(2));
            Assert.That(firstChild.Children[0].Value, Is.EqualTo("Первый внук"));
            Assert.That(firstChild.Children[1].Value, Is.EqualTo("Второй внук"));

            // Проверяем второго внука
            var secondGrandChild = firstChild.Children[1];
            Assert.That(secondGrandChild.Children, Has.Count.EqualTo(1));
            Assert.That(secondGrandChild.Children[0].Value, Is.EqualTo("Правнук"));
        }
    }
}