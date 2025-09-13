namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Interfaces;

public interface IFileSystemElement
{
    void Accept(IFileSystemVisitor visitor, int depth);
}