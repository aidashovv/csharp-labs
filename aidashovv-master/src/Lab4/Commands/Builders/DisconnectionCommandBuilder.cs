using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class DisconnectionCommandBuilder : ICommandBuilder<DisconnectionCommand>
{
    private FileSystemContext? _context;

    public DisconnectionCommandBuilder()
    {
        _context = null;
    }

    public DisconnectionCommandBuilder SetContext(FileSystemContext context)
    {
        _context = new FileSystemContext(context.CurrentFileSystem, context.CurrentPath);
        return this;
    }

    public DisconnectionCommand Build()
    {
        return new DisconnectionCommand(_context);
    }
}
