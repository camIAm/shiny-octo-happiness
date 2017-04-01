using System;
using System.Collections.Generic;
using System.Text;
using CSharpTree;

namespace ConsoleApplication
{
    public class PathDecomposition
    {
        private static int indentation = 2;
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
                // Probably shouldn't use lazy initialization for the senario
                // benchmark regular vs lazy dict
                var discountsDictionary = new Dictionary<PathEnum, Lazy<ITreeImpl>>
                {
                    {PathEnum.Root,new Lazy<ITreeImpl>(()=> new RootNode())},
                    {PathEnum.One, new Lazy<ITreeImpl>(()=> new OneChildNode())},
                    {PathEnum.Two, new Lazy<ITreeImpl>(()=> new TwoChildNode())},
                    {PathEnum.Three, new Lazy<ITreeImpl>(()=> new ThreeChildNode())},
                    {PathEnum.Four, new Lazy<ITreeImpl>(()=> new FourChildNode())},
                    {PathEnum.Five, new Lazy<ITreeImpl>(()=> new FiveChildNode())},
                    {PathEnum.Six, new Lazy<ITreeImpl>(()=> new SixChildNode())},
                    {PathEnum.Seven, new Lazy<ITreeImpl>(()=> new SeventhChildNode())},
                };

                TreeFactory treeFactory = new TreeFactory(discountsDictionary); // Factory
                int pathQueueCount = pathQueue.Count;
                ITreeImpl treeModel = treeFactory.GetTreeKind(pathQueueCount);
                TreeNode<string> treeNode = treeModel.GetTreeImple(pathQueue);
                              
                int lengthAfter = 0;
                foreach (TreeNode<string> node in treeNode)
                {
                    int length;
                    Console.WriteLine(Indent(node, lengthAfter, out length));
                    //Console.WriteLine(Indent(node.Level, out length) + (node.Data ?? "null")); // Testing purposes
                    //System.Console.WriteLine($"Lenght {length}");
                    lengthAfter = length;
                }
        }
        public static string Indent(TreeNode<string> node,int lengthAfter, out int length)
        {

            int count = node.Level;
            StringBuilder sb = new StringBuilder();
            if(count>0)
            {
                int space = (count==1 ? 0 : count-1);
                sb.Append(' ', space * indentation + (2*space));                
                sb.Append("|_");
                sb.Append('_', indentation);
            }
            sb.Append(node.Data);
            length = count;
            return sb.ToString();
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