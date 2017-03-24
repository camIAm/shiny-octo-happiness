using System;

namespace ConsoleApplication
{
    public class FileLister
    {
        public FileLister(FileSearcher lister)
        {
            lister.FileFound += onFileFound;
            lister.DirectoryChanged += onDirectoryChanged;
        }
        EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
        {
            Console.WriteLine($"\t {eventArgs.File}");
           // eventArgs.CancelRequested = true;
        };
        EventHandler<SearchDirectoryArgs> onDirectoryChanged = (sender, eventArgs) =>
        {
            Console.Write($"Entering '{eventArgs.CurrentSearchDirectory}'.");
            Console.WriteLine($" {eventArgs.CompletedDirs} of {eventArgs.TotalDirs} completed...");
        };
    }
}