using Study.Lab1.Logic.brnvika.Task3;
using Study.Lab1.Logic.Interfaces;
namespace Study.Lab1.Logic.brnvika;

public class brnvikaService : IRunService
{
    public void RunTask1() { }
    public void RunTask2() { }
    public void RunTask3()
    {
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
            Console.WriteLine("Дерево <string>:");
            Console.WriteLine(parent1.GetAllChildrenValues());


            var parent2 = new TreeNode<int>(1);
            var child21 = new TreeNode<int>(11);
            var child22 = new TreeNode<int>(12);
            var child23 = new TreeNode<int>(13);
            var grandChild21 = new TreeNode<int>(121);
            var grandChild22 = new TreeNode<int>(122);
            var grandChild31 = new TreeNode<int>(131);
            var grandGrandChild31 = new TreeNode<int>(1311);
            var grandGrandChild32 = new TreeNode<int>(1312);
            grandChild31.Add(grandGrandChild31);
            grandChild31.Add(grandGrandChild32);
            child22.Add(grandChild21);
            child22.Add(grandChild22);
            child23.Add(grandChild31);
            parent2.Add(child21);
            parent2.Add(child22);
            parent2.Add(child23);
            Console.WriteLine("Дерево <int>:");
            Console.WriteLine(parent2.GetAllChildrenValues());
        }
    }
}
