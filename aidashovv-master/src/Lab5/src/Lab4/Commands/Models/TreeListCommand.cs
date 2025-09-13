using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class TreeListCommand : ICommand
{
    private readonly FileSystemContext _context;
    private readonly string? _depth;

    public TreeListCommand(FileSystemContext context, string? depth)
    {
        _context = context;
        _depth = depth;
    }

    public void Execute()
    {
        _context.CurrentFileSystem?.ListDirectory(_depth, _context);
    }
}
