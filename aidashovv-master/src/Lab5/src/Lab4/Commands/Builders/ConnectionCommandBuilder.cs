using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class ConnectionCommandBuilder : ICommandBuilder<ConnectionCommand>
{
    private string? _address;
    private string? _mode;
    private FileSystemContext? _context;

    public ConnectionCommandBuilder()
    {
       _address = null;
       _mode = null;
       _context = null;
    }

    public ConnectionCommandBuilder SetAddress(string address)
    {
        _address = address;
        return this;
    }

    public ConnectionCommandBuilder SetMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public ConnectionCommandBuilder SetContext(FileSystemContext context)
    {
        _context = new FileSystemContext(context.CurrentFileSystem, context.CurrentPath);
        return this;
    }

    public ConnectionCommand Build()
    {
        return new ConnectionCommand(_address, _mode, _context);
    }
}
