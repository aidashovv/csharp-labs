namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Interfaces;

public interface IFileSystemVisitor
{
    void VisitFile(string? filePath, int depth);

    void VisitDirectory(string? directoryPath, int depth);
}