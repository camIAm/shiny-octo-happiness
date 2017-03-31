using System;
using System.Text;

namespace ConsoleApplication
{
    public class FileLister
    {
        private const byte padding = 3;
        public FileLister(FileSearcher lister)
        {
            lister.FileFound += onFileFound;
            lister.DirectoryChanged += onDirectoryChanged;
        }
        EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
        {
            Console.WriteLine($"{eventArgs.File}");
           // eventArgs.CancelRequested = true;
        };
        EventHandler<SearchDirectoryArgs> onDirectoryChanged = (sender, eventArgs) =>
        {
            Console.Write($"Entering '{eventArgs.CurrentSearchDirectory}'.");
            Console.WriteLine($" {eventArgs.CompletedDirs} of {eventArgs.TotalDirs} completed...");
        };
        public static string Indent(int count)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i<count-1; i++)
            {
                sb.Append("-");
            }
            return sb.ToString();
        }
    }
}