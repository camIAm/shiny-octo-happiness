using System.Collections.Generic;
using CSharpTree;

namespace ConsoleApplication
{
    public interface ITreeImpl
    {
        TreeNode<string> GetTreeImple(Queue<string> pathQueue);
    }
}