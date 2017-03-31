using System;

namespace ConsoleApplication
{
    public class FileFoundArgs : EventArgs
    {
        public string File { get; }
        //internal int SlashesFromDirectoryRoot { get; set; }
        //public bool CancelRequested { get; set; }
        public FileFoundArgs(string fileName)//, int slashesFromDirectoryRoot)
        {
            File = fileName;
            //SlashesFromDirectoryRoot = slashesFromDirectoryRoot;
        }
        //public IEnumerable<String> FoundDirectories{ get; }
        /* 
        public FileFoundArgs(IEnumerable<string> fileName)
        {
            FoundDirectories = fileName;
        }
        */
    }
}