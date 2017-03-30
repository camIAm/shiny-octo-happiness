using System;
using System.IO;
using System.Collections.Generic;
using CSharpTree;

namespace ConsoleApplication
{
    public class FileSearcher
    {
        internal Stack<int> SlashPlacementStack{ get;set; }
        internal Queue<int> SlashPlacementQueue{ get;set; }
        internal string CurrentDirectory{ get; set; }
        public event EventHandler<FileFoundArgs> FileFound;
        internal event EventHandler<SearchDirectoryArgs> DirectoryChanged
            {
                add { directoryChanged += value; }
                remove { directoryChanged -= value; }
            }
        private EventHandler<SearchDirectoryArgs> directoryChanged;
        public FileSearcher()
        {
             SlashPlacementQueue = SlashPlacementQueue ?? new Queue<int>();
             SlashPlacementStack = SlashPlacementStack ?? new Stack<int>();
        }
        public void SearchDirectories(string directory, string searchPattern, bool searchSubDirs = true)
        {
            if (searchSubDirs)
            {
                var allDirectories = Directory.GetDirectories(directory, "*.*", SearchOption.AllDirectories);
                var completedDirs = 0;
                var totalDirs = allDirectories.Length + 1;
                foreach (var dir in allDirectories)
                {
                    //DirectoryInfo(directory,dir);
                    //int numOfSlashes = NumOfSlashesInPath(directory, dir);
                    //Stack<int> stackPlacement = BuildDirectoryTree()
                    //System.Console.WriteLine($"Total numOfSlashes: {numOfSlashes}");
                    directoryChanged?.Invoke(this,
                                new SearchDirectoryArgs(dir, totalDirs, completedDirs++));
                    // Recursively search this child directory:
                    SearchFilesInDirectory(dir, searchPattern);
                }
                // Include the Current Directory:
                directoryChanged?.Invoke(this,
                            new SearchDirectoryArgs(directory, totalDirs, completedDirs++));
                SearchFilesInDirectory(directory, searchPattern);
            }
            else
            {
                SearchFilesInDirectory(directory, searchPattern);
            }
        }

        internal void SearchFilesInDirectory(string directory, string searchPattern)
        {
            foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
            {
                char[] charArray = GetDirectoryCharArray(CurrentDirectory, file);
                var fileToArrayComparison = file.Substring(CurrentDirectory.LastIndexOf('/'));
                if(charArray.Length != fileToArrayComparison.Length){
                    System.Console.WriteLine("charArray does not include of of file");// use comparer to determine which variable doesnt include which
                }
                Queue<int> queueSlashPlacement = BuildDirectoryTreeViaQueue(charArray);
                Queue<string> pathQueue = GetCharArrayBySlicesQueue(charArray, queueSlashPlacement);
                PathComposition pathComposition = new PathComposition(pathQueue);
                TreeNode<string> treeRoot = pathComposition.PathBuilder();
                foreach (TreeNode<string> node in treeRoot)
                {
                    Console.WriteLine((node.Data ?? "null")); // Testing purposes
                }
                while(queueSlashPlacement.Count>0)
                {
                    int stackIndex = queueSlashPlacement.Dequeue();
                    System.Console.WriteLine($"StackIndex {stackIndex}");
                }
                int numOfSlashes = NumOfSlashesInPath(charArray);
                var args = new FileFoundArgs(file, numOfSlashes);
                FileFound?.Invoke(this, args);
                //if (args.CancelRequested)
                  //  break;
            }
        }
        internal Queue<string> GetCharArrayBySlicesQueue(char[] charArray, Queue<int> slashPlacement)
        {
            int start = 0;
            int capacity = slashPlacement.Count;
            Queue<string> pathQueue = new Queue<string>();
            List<string> wordsBetweenSlashes = new List<string>();
            System.Console.WriteLine(charArray);
            for(int i = 0; i < capacity;i++)
            {
                string wasCharArray = new String(charArray);
                int length = wasCharArray.Length;
                int pop = slashPlacement.Dequeue();
                if(pop != 0)
                {
                    System.Console.WriteLine(wasCharArray.Substring(start + 1, pop - start -1));
                    wordsBetweenSlashes.Add(wasCharArray.Substring(start + 1, pop - start - 1));
                    pathQueue.Enqueue(wasCharArray.Substring(start + 1, pop - start - 1));
                    start = pop;
                }
                if(slashPlacement.Count==0)
                {
                    wordsBetweenSlashes.Add(wasCharArray.Substring(start + 1));
                    System.Console.WriteLine(wasCharArray.Substring(start + 1));
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
        internal Stack<int> BuildDirectoryTree(char[] directoryInfoSubstringToCharArray)
        {
            for(int i = 0; i < directoryInfoSubstringToCharArray.Length; i++)
            {
                char current = directoryInfoSubstringToCharArray[i];
                if(current.Equals('/'))
                {
                    if(current.Equals(null)){break;}
                    SlashPlacementStack.Push(i);
                }
            }
            return SlashPlacementStack;
        }
        internal void GetCharArrayBySlices(char[] charArray, Stack<int> stackPlacement)
        {
            int pop = 0;
            string wasCharArray = charArray.ToString();
            for(int i = pop; i<stackPlacement.Count; i++)
            {
                pop = stackPlacement.Pop();
                if(pop != 0){
                string folderOrFile = wasCharArray.Substring(i, pop);
                i = pop;
                }
            }
        }
        internal void DirectoryInfo(string directory,string dir)
        {
            var lastIndexOf = directory.LastIndexOf("/");
            System.Console.WriteLine($"directory: {directory}");
            System.IO.DirectoryInfo directoryInfo = System.IO.Directory.GetParent(dir);
            System.Console.WriteLine($"directoryInfo: {directoryInfo}");
            string directoryInfoString = directoryInfo.ToString();
            string directoryInfoSubstring = directoryInfoString.Substring(lastIndexOf);
            System.Console.WriteLine($"directoryInfoSubstring: {directoryInfoSubstring}");
        }
        /*     
        public void SearchCurrentDirectory(string currentDirectory)
        {
            IEnumerable<String> enumerableDict = Directory.EnumerateDirectories(currentDirectory);
            foreach(var dict in enumerableDict)
            {
                var args = new FileFoundArgs(dict);
                FileFound?.Invoke(this, args);
                if(args.CancelRequested)
                {
                    break;
                }
            }
        }
        
        (public void Search(string directory, string searchPattern)
            foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
            {
                FileFound?.Invoke(this, new FileFoundArgs(file));
            }
        }
        public void Search(string directory)
        {
            foreach (var file in Directory.EnumerateFiles(directory))
            {
                FileFound?.Invoke(this, new FileFoundArgs(file));
            }
        }
        */
    }
}