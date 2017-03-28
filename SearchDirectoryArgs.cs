using System;

namespace ConsoleApplication
{
    internal class SearchDirectoryArgs : EventArgs
{
    internal string CurrentSearchDirectory { get; }
    internal int TotalDirs { get; }
    internal int CompletedDirs { get; }

    internal SearchDirectoryArgs(string dir, int totalDirs, int completedDirs)//, int slashesFromDirectoryRoot)
    {
        CurrentSearchDirectory = dir;
        TotalDirs = totalDirs;
        CompletedDirs = completedDirs;
        //SlashesFromDirectoryRoot = slashesFromDirectoryRoot;
    }
}
}