using Study.Lab1.Logic.Interfaces.katty.Task3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.katty.Task_3
{
    public class TreeNode : ITreeNode
    {
        public string Value { get; set; }
        public IList<ITreeNode> Children { get; } = new List<ITreeNode>();

        public TreeNode(string value)
        {
            Value = value;
        }

        public void AddChild(ITreeNode node)
        {
            Children.Add(node);
        }

        public void PrintChildrenValues()
        {
            Console.WriteLine($"Узел '{Value}' имеет потомков:");
            PrintChildrenRecursive(this, 1);
        }

        private void PrintChildrenRecursive(ITreeNode node, int level)
        {
            foreach (var child in node.Children)
            {
                Console.WriteLine($"{new string(' ', level * 2)}- {child.Value}");
                PrintChildrenRecursive(child, level + 1);
            }
        }
    }

}
