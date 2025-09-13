using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

public class FileElement : IFileSystemElement
{
    private readonly string? _path;

    public FileElement(string? path)
    {
        _path = path;
    }

    public void Accept(IFileSystemVisitor visitor, int depth)
    {
        visitor.VisitFile(_path, depth);
    }
}