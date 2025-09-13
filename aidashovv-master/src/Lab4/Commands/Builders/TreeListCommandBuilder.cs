using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class TreeListCommandBuilder : ICommandBuilder<TreeListCommand>
{
    private FileSystemContext _context;
    private string? _depth;

    public TreeListCommandBuilder()
    {
        _depth = null;
        _context = new FileSystemContext(null, null);
    }

    public TreeListCommandBuilder SetDepth(string depth)
    {
        _depth = depth;
        return this;
    }

    public TreeListCommandBuilder SetContext(FileSystemContext context)
    {
        _context = new FileSystemContext(context.CurrentFileSystem, context.CurrentPath);
        return this;
    }

    public TreeListCommand Build()
    {
        return new TreeListCommand(_context, _depth);
    }
}
