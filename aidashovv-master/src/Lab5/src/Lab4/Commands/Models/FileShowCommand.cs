using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class FileShowCommand : ICommand
{
    private readonly FileSystemContext? _context;
    private readonly string? _destinationPath;
    private readonly string? _mode;

    public FileShowCommand(FileSystemContext? context, string? path, string? mode)
    {
        _context = context;
        _destinationPath = path;
        _mode = mode;
    }

    public void Execute()
    {
        _context?.CurrentFileSystem?.ShowFile(_mode, _destinationPath);
    }
}
