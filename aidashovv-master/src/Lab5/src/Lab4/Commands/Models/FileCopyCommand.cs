using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class FileCopyCommand : ICommand
{
    private readonly FileSystemContext? _context;
    private readonly string? _sourcePath;
    private readonly string? _destinationPath;

    public FileCopyCommand(FileSystemContext? context, string? sourcePath, string? destinationPath)
    {
        _context = context;
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute()
    {
        _context?.CurrentFileSystem?.CopyFile(_sourcePath, _destinationPath);
    }
}