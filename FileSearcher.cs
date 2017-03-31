using System;
using System.IO;

namespace ConsoleApplication
{
    public class FileSearcher
    {
        public string CurrentDirectory { get; set; }
        public event EventHandler<FileFoundArgs> FileFound;
        internal event EventHandler<SearchDirectoryArgs> DirectoryChanged
            {
                add { directoryChanged += value; }
                remove { directoryChanged -= value; }
            }
        private EventHandler<SearchDirectoryArgs> directoryChanged;
        public FileSearcher(){}
        public void SearchDirectories(string directory, string searchPattern, bool searchSubDirs = true)
        {
            if (searchSubDirs)
            {
                var allDirectories = Directory.GetDirectories(directory, "*.*", SearchOption.AllDirectories);
                var completedDirs = 0;
                var totalDirs = allDirectories.Length + 1;
                foreach (var dir in allDirectories)
                {
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
                PathDecomposition pathDecomp = new PathDecomposition(file, CurrentDirectory);
                pathDecomp.PuttingItTogether();
                var args = new FileFoundArgs(file);  
                FileFound?.Invoke(this, args);
                //if (args.CancelRequested)
                  //  break;
            }
        }
    }
}