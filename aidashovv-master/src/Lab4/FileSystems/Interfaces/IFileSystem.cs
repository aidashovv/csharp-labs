using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Interfaces;

public interface IFileSystem
{
    void MoveFile(string? sourcePath, string? destinationPath);

    void CopyFile(string? sourcePath, string? destinationPath);

    void DeleteFile(string? path);

    void RenameFile(string? path, string? newName);

    void ShowFile(string? path, string? mode);

    void GotoDirectory(string? path, FileSystemContext context);

    void ListDirectory(string? depth, FileSystemContext context);
}