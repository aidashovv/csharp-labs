using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class TreeGotoCommand : ICommand
{
    private readonly FileSystemContext? _context;
    private readonly string? _destinationPath;

    public TreeGotoCommand(FileSystemContext? context, string? path)
    {
        _context = context;
        _destinationPath = path;
    }

    public void Execute()
    {
        _context?.CurrentFileSystem?.GotoDirectory(_destinationPath, _context);
    }
}