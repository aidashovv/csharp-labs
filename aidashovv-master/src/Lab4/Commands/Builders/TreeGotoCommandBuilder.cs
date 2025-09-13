using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class TreeGotoCommandBuilder : ICommandBuilder<TreeGotoCommand>
{
    private FileSystemContext? _context;
    private string? _destinationPath;

    public TreeGotoCommandBuilder()
    {
        _context = null;
        _destinationPath = null;
    }

    public TreeGotoCommandBuilder SetDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public TreeGotoCommandBuilder SetContext(FileSystemContext context)
    {
        _context = new FileSystemContext(context.CurrentFileSystem, context.CurrentPath);
        return this;
    }

    public TreeGotoCommand Build()
    {
        return new TreeGotoCommand(_context, _destinationPath);
    }
}