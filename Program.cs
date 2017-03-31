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
            fileSearcher.CurrentDirectory = currentDirectory; // set this property in new class
            fileSearcher.SearchDirectories(currentDirectory,"*.*");
            
            //PathDecomposition pathDecomp = new PathDecomposition();
            //pathDecomp.CurrentDirectory = currentDirectory;

            //fileSearcher.SearchDirectory(currentDirectory,"*.*");
        }
    }
}
