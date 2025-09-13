using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

public class FileSystemContext
{
    public FileSystemContext(IFileSystem? currentFileSystem, string? currentPath)
    {
        CurrentFileSystem = currentFileSystem;
        CurrentPath = currentPath;
    }

    public IFileSystem? CurrentFileSystem { get; private set; }

    public string? CurrentPath { get; private set; }

    public void Connect(string? path, string? mode)
    {
        if (mode == "local")
        {
            CurrentFileSystem = new FileSystem();
            CurrentPath = path;
        }
    }

    public void Disconnect()
    {
        CurrentPath = null;
        CurrentFileSystem = null;
    }

    public void StatusUpdate(string? newPath)
    {
        CurrentPath = newPath;
    }

    public bool IsActive()
    {
        return CurrentFileSystem != null;
    }
}