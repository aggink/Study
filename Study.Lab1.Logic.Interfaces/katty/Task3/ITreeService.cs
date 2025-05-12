using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.Interfaces.katty.Task3
{

    public interface ITreeService
    {
        ITreeNode Root { get; }
        void ConfigureTree();
        bool HasCycles();
    }
}
