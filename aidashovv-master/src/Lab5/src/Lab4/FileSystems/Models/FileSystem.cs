using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

public class FileSystem : IFileSystem
{
    public void MoveFile(string? sourcePath, string? destinationPath)
    {
        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException($"Source file not found: {sourcePath}.");
        }

        if (File.Exists(destinationPath))
        {
            throw new IOException($"File already exists in the destination path: {destinationPath}.");
        }

        if (destinationPath != null)
        {
            File.Move(sourcePath, destinationPath);
            Console.WriteLine($"File successfully moved from {sourcePath} to {destinationPath}.");
        }
    }

    public void CopyFile(string? sourcePath, string? destinationPath)
    {
        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException($"Source file not found: {sourcePath}.");
        }

        if (File.Exists(destinationPath))
        {
            throw new IOException($"File already exists in the destination path: {destinationPath}.");
        }

        if (destinationPath != null)
        {
            File.Copy(sourcePath, destinationPath);
            Console.WriteLine($"File successfully copied from {sourcePath} to {destinationPath}.");
        }
    }

    public void DeleteFile(string? path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File not found: {path}.");
        }

        File.Delete(path);
        Console.WriteLine($"File successfully deleted.");
    }

    public void RenameFile(string? path, string? newName)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File not found: {path}.");
        }

        string? directory = Path.GetDirectoryName(path);
        if (directory is null) return;

        if (newName != null)
        {
            string newFilePath = Path.Combine(directory, newName);
            if (File.Exists(newFilePath))
            {
                throw new IOException($"File with name {newName} already exists in the directory {directory}.");
            }

            File.Move(path, newFilePath);
            Console.WriteLine($"File successfully renamed to: {newFilePath}");
        }
    }

    public void ShowFile(string? path, string? mode)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File not found: {path}.");
        }

        if (mode == "console")
        {
            string fileContent = File.ReadAllText(path);
            Console.WriteLine(fileContent);
        }
    }

    public void GotoDirectory(string? path, FileSystemContext? context)
    {
        if (!Directory.Exists(path))
        {
            throw new DirectoryNotFoundException($"Directory not found at path: {path}.");
        }

        context?.StatusUpdate(path);
    }

    public void ListDirectory(string? depth, FileSystemContext? context)
    {
        if (string.IsNullOrEmpty(depth)
            || !depth.All(char.IsDigit)
            || !int.TryParse(depth, out int maxDepth) || maxDepth < 0)
        {
            Console.WriteLine("Incorrect depth parameter.");
            return;
        }

        string? currentPath = context?.CurrentPath;
        IFileSystemVisitor visitor = new FileSystemVisitor();
        WalkDirectory(currentPath, visitor, 0, maxDepth);
    }

    private void WalkDirectory(string? currentPath, IFileSystemVisitor visitor, int currentDepth, int maxDepth)
    {
        if (currentDepth > maxDepth) return;

        var directoryElement = new DirectoryElement(currentPath);
        directoryElement.Accept(visitor, currentDepth);

        if (currentPath == null) return;

        foreach (string file in Directory.GetFiles(currentPath))
        {
            var fileElement = new FileElement(file);
            fileElement.Accept(visitor, currentDepth + 1);
        }

        foreach (string directory in Directory.GetDirectories(currentPath))
            WalkDirectory(directory, visitor, currentDepth + 1, maxDepth);
    }
}