using Study.Lab1.Logic.neijrr.Task3;

namespace Study.Lab1.Logic.UnitTests.neijrr.Task3;

[TestFixture]
public class TypedTreeNodeTests
{
    [Test]
    public void BasicFunctions()    // Создание класса и доступ к значениям
    {
        // Условие
        var stringTree = new TreeNode<string>("Корень дерева") {
            "Первый узел",
            new TreeNode<string>("Второй узел") {
                "Вложенный узел"
            }
        };

        // Проверка
        Assert.Multiple(() =>
        {
            Assert.That(stringTree.Value, Is.EqualTo("Корень дерева"), "Не задано значение для корня");
            Assert.That(stringTree[0].Value, Is.EqualTo("Первый узел"), "Не задано значение для первого узла (строка)");
            Assert.That(stringTree[1].Value, Is.EqualTo("Второй узел"), "Не задано значение для второго узла (число)");
            Assert.That(stringTree[1][0].Value, Is.EqualTo("Вложенный узел"), "Не задано значение для узла 2-го уровня");
        });
    }

    [Test]
    public void ListOperations()
    {
        // Условие
        var firstNode = new TreeNode<string>("Первый узел");
        var stringTree = new TreeNode<string>("Корень дерева") {
            firstNode,
            new TreeNode<string>("Второй узел") {
                "Вложенный узел"
            },
            "Третий узел"
        };

        // Действие
        stringTree.Remove(firstNode);
        stringTree.RemoveValue("Третий узел");
        stringTree.Add("42");
        stringTree.Insert(1, "Новый узел");

        // Проверка
        Assert.Multiple(() =>
        {
            Assert.That(stringTree[0].Value, Is.Not.EqualTo("Первый узел"), "Ошибка при удалении узла");
            Assert.That(stringTree[1].Value, Is.EqualTo("Новый узел"), "Ошибка при вставке узла");
        });
        Assert.That(stringTree, Has.Count.EqualTo(3), "Ошибка при добавлении узла");
    }

    //[Test]
    //public void String()
    //{
    //    // Условие
    //    var stringTree = new TreeNode<string>("Корень дерева") {
    //        "Первый узел",
    //        new TreeNode<string>("Второй узел") {
    //            "Вложенный узел"
    //        }
    //    };
    //    const string childrenStr = """
    //        Корень дерева
    //        | Первый узел
    //        | Второй узел
    //        """;
    //    const string treeStr = """
    //        Корень дерева
    //        | Первый узел
    //        | Второй узел
    //        | | Вложенный узел
    //        """;

    //    // Действие
    //    var value = stringTree.ToString();
    //    var children = stringTree.ToString(1);
    //    var tree = stringTree.ToString(-1);

    //    // Проверка
    //    Assert.Multiple(() =>
    //    {
    //        Assert.That(value, Is.EqualTo("Корень дерева"), "Не работает преобразование в строку для значения узла");
    //        Assert.That(children, Is.EqualTo(childrenStr), "Не работает преобразование в строку для заданного уровня");
    //        Assert.That(tree, Is.EqualTo(treeStr), "Не работает преобразование в строку для всего дерева");
    //    });
    //}
}
