using System;
using System.Collections.Generic;
using CSharpTree;

namespace ConsoleApplication
{
    public class PathDecomposition
    {
        private string _file;
        public string CurrentDirectory { get; set; }
        internal Queue<int> SlashPlacementQueue{ get;set; }
        public PathDecomposition(){}
        public PathDecomposition(string file, string currentDirectory)
        {
            SlashPlacementQueue = SlashPlacementQueue ?? new Queue<int>();
            _file = file;
            CurrentDirectory = currentDirectory;
        }
        internal void PuttingItTogether()
        {
                char[] charArray = GetDirectoryCharArray(CurrentDirectory, _file);
                var fileToArrayComparison = _file.Substring(CurrentDirectory.LastIndexOf('/'));
                if(charArray.Length != fileToArrayComparison.Length)
                {
                    System.Console.WriteLine("charArray does not include of of file");// use comparer to determine which variable doesnt include which
                }
                Queue<int> queueSlashPlacement = BuildDirectoryTreeViaQueue(charArray);
                Queue<string> pathQueue = GetCharArrayBySlicesQueue(charArray, queueSlashPlacement);

                TreeFactory treeFactory = new TreeFactory(); // Factory
                int pathQueueCount = pathQueue.Count;
                ITreeImpl treeModel = treeFactory.GetTreeKind(pathQueueCount);
                TreeNode<string> treeNode = treeModel.GetTreeImple(pathQueue);
                              
                foreach (TreeNode<string> node in treeNode)
                {
                    Console.WriteLine((node.Data ?? "null")); // Testing purposes
                }
        }
        internal Queue<string> GetCharArrayBySlicesQueue(char[] charArray, Queue<int> slashPlacement)
        {
            int start = 0;
            int capacity = slashPlacement.Count;
            Queue<string> pathQueue = new Queue<string>();
            System.Console.WriteLine(charArray);
            
            for(int i = 0; i < capacity; i++)
            {
                string wasCharArray = new String(charArray);
                int length = wasCharArray.Length;
                int pop = slashPlacement.Dequeue();
                if(pop != 0)
                {
                    pathQueue.Enqueue(wasCharArray.Substring(start + 1, pop - start - 1));
                    start = pop;
                }
                if(slashPlacement.Count==0)
                {
                    pathQueue.Enqueue(wasCharArray.Substring(start + 1));
                }
            }
            return pathQueue;
        }
        internal char[] GetDirectoryCharArray(string directory, string dir)
        {
            var lastIndexOf = directory.LastIndexOf("/");
            var directoryInfoSubstring = dir.Substring(45);
            var directoryInfoSubstringToCharArray = directoryInfoSubstring.ToCharArray();
            return directoryInfoSubstringToCharArray;
        }
        internal int NumOfSlashesInPath(char[] directoryInfoSubstringToCharArray)
        {
            int numOfSlashes = 0;
            for(int i = 0; i < directoryInfoSubstringToCharArray.Length; i++)
            {
                char current = directoryInfoSubstringToCharArray[i];
                if(current.Equals('/'))
                {
                    if(current.Equals(null))
                    {
                        break;
                    }
                    ++numOfSlashes;
                }
            }
            return numOfSlashes;
        }
        internal Queue<int> BuildDirectoryTreeViaQueue(char[] directoryInfoSubstringToCharArray)
        {
            for(int i = 0; i < directoryInfoSubstringToCharArray.Length; i++)
            {
                char current = directoryInfoSubstringToCharArray[i];
                if(current.Equals('/'))
                {
                    if(current.Equals(null)){break;}
                    SlashPlacementQueue.Enqueue(i);
                }
            }
            return SlashPlacementQueue;
        }
    }
}