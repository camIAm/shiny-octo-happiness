using System;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string rootDirectory = Directory.GetDirectoryRoot(currentDirectory);
            System.Console.WriteLine($"currentDirectory: {currentDirectory} \n");
            //System.Console.WriteLine($"rootDirectory: {rootDirectory} \n");
            FileSearcher fileSearcher = new FileSearcher();
            new FileLister(fileSearcher); 
            fileSearcher.SearchDirectories(currentDirectory,"*.*");
            //fileSearcher.SearchDirectory(currentDirectory,"*.*");
        }
    }
}
