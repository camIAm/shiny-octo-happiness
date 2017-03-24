using System;

namespace ConsoleApplication
{
    public class FileFoundArgs : EventArgs
    {
        public string File { get; }
        //public bool CancelRequested { get; set; }
        public FileFoundArgs(string fileName)
        {
            File = fileName;
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