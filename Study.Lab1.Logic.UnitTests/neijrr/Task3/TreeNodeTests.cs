using Study.Lab1.Logic.neijrr.Task3;

namespace Study.Lab1.Logic.UnitTests.neijrr.Task3;

[TestFixture]
public class TreeNodeTests
{
    [Test]
    public void Constructor()
    {
        // Условие
        var objectTree = new TreeNode("Корень дерева") {
            new TreeNode("Первый узел"),
            new TreeNode(2) {
                new TreeNode("Вложенный узел")
            }
        };

        // Проверка
        Assert.Multiple(() =>
        {
            Assert.That(objectTree.Value, Is.EqualTo("Корень дерева"), "Не задано значение для корня");
            Assert.That(objectTree[0].Value, Is.EqualTo("Первый узел"), "Не задано значение для первого узла (строка)");
            Assert.That(objectTree[1].Value, Is.EqualTo(2), "Не задано значение для второго узла (число)");
            Assert.That(objectTree[1][0].Value, Is.EqualTo("Вложенный узел"), "Не задано значение для узла 2-го уровня");
        });
    }

    [Test]
    public void ListOperations()
    {
        // Условие
        var firstNode = new TreeNode("Первый узел");
        var objectTree = new TreeNode("Корень дерева") {
            firstNode,
            new TreeNode(2) {
                new TreeNode("Вложенный узел")
            }
        };

        // Действие
        objectTree.Remove(firstNode);
        objectTree.Add(new TreeNode(42));
        objectTree.Insert(1, new TreeNode("Новый узел"));

        // Проверка
        Assert.Multiple(() =>
        {
            Assert.That(objectTree[0].Value, Is.Not.EqualTo("Первый узел"), "Ошибка при удалении узла");
            Assert.That(objectTree[1].Value, Is.EqualTo("Новый узел"), "Ошибка при вставке узла");
        });

        Assert.That(objectTree, Has.Count.EqualTo(3), "Ошибка при добавлении узла");
    }

    [Test]
    public void String()
    {
        // Условие
        var objectTree = new TreeNode("Корень дерева") {
            new TreeNode("Первый узел"),
            new TreeNode(2) {
                new TreeNode("Вложенный узел")
            }
        };

        const string childrenStr = """
            Корень дерева
            | Первый узел
            | 2
            """;
        const string treeStr = """
            Корень дерева
            | Первый узел
            | 2
            | | Вложенный узел
            """;

        // Действие
        var value = objectTree.ToString();
        var children = objectTree.ToString(1);
        var tree = objectTree.ToString(-1);

        // Проверка
        Assert.Multiple(() =>
        {
            Assert.That(value, Is.EqualTo("Корень дерева"), "Не работает преобразование в строку для значения узла");
            Assert.That(children, Is.EqualTo(childrenStr), "Не работает преобразование в строку для заданного уровня");
            Assert.That(tree, Is.EqualTo(treeStr), "Не работает преобразование в строку для всего дерева");
        });
    }
}
