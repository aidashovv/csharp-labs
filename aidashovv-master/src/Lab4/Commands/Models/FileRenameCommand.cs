using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class FileRenameCommand : ICommand
{
    private readonly FileSystemContext? _context;
    private readonly string? _sourcePath;
    private readonly string? _newName;

    public FileRenameCommand(FileSystemContext? context, string? path, string? newName)
    {
        _context = context;
        _sourcePath = path;
        _newName = newName;
    }

    public void Execute()
    {
        _context?.CurrentFileSystem?.RenameFile(_sourcePath, _newName);
    }
}