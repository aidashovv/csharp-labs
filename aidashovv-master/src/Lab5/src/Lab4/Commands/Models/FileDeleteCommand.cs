using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class FileDeleteCommand : ICommand
{
    private readonly FileSystemContext? _context;
    private readonly string? _sourcePath;

    public FileDeleteCommand(FileSystemContext? context, string? path)
    {
        _context = context;
        _sourcePath = path;
    }

    public void Execute()
    {
        _context?.CurrentFileSystem?.DeleteFile(_sourcePath);
    }
}