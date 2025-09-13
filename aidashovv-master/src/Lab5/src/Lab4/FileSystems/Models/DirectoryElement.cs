using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

public class DirectoryElement : IFileSystemElement
{
    private readonly string? _path;

    public DirectoryElement(string? path)
    {
        _path = path;
    }

    public void Accept(IFileSystemVisitor visitor, int depth)
    {
        visitor.VisitDirectory(_path, depth);
    }
}