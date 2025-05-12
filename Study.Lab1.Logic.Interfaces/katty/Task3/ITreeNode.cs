using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.Interfaces.katty.Task3
{
    public interface ITreeNode
    {
        string Value { get; set; }
        IList<ITreeNode> Children { get; }
        void PrintChildrenValues();
        void AddChild(ITreeNode node);
    }
}
