using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class ConnectionCommand : ICommand
{
    private readonly string? _address;
    private readonly string? _mode;
    private readonly FileSystemContext? _context;

    public ConnectionCommand(string? address, string? mode, FileSystemContext? context)
    {
        _address = address;
        _mode = mode;
        _context = context;
    }

    public void Execute()
    {
        _context?.Connect(_address, _mode);
    }
}