using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

public class FileSystemVisitor : IFileSystemVisitor
{
    public void VisitFile(string? filePath, int depth)
    {
        Console.WriteLine($"{new string(' ', depth * 2)}{Path.GetFileName(filePath)}");
    }

    public void VisitDirectory(string? directoryPath, int depth)
    {
        Console.WriteLine($"{new string(' ', depth * 2)}{Path.GetFileName(directoryPath)}");
    }
}