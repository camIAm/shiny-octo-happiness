using System;
using System.IO;

namespace ConsoleApplication
{
    public class FileSearcher
    {
        internal string CurrentDirectory{ get; set; }
        public event EventHandler<FileFoundArgs> FileFound;
        internal event EventHandler<SearchDirectoryArgs> DirectoryChanged
            {
                add { directoryChanged += value; }
                remove { directoryChanged -= value; }
            }
        private EventHandler<SearchDirectoryArgs> directoryChanged;
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
                    int numOfSlashes = numOfSlashesInPath(directory, dir);
                    System.Console.WriteLine($"Total numOfSlashes: {numOfSlashes}");
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
                //DirectoryInfo(CurrentDirectory,file);
                int numOfSlashes = numOfSlashesInPath(CurrentDirectory, file);
                var args = new FileFoundArgs(file, numOfSlashes);
                FileFound?.Invoke(this, args);
                //if (args.CancelRequested)
                  //  break;
            }
        }
        internal int numOfSlashesInPath(string directory,string dir)
        {
            var lastIndexOf = directory.LastIndexOf("/");
            System.IO.DirectoryInfo directoryInfo = System.IO.Directory.GetParent(dir);
            string directoryInfoString = directoryInfo.ToString();
            string directoryInfoSubstring = directoryInfoString.Substring(lastIndexOf);
            var directoryInfoSubstringToCharArray = directoryInfoSubstring.ToCharArray();
            int numOfSlashes = 0;
            //int totalNumOfSlashes = 0;
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