using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class DisconnectionCommand : ICommand
{
    private readonly FileSystemContext? _context;

    public DisconnectionCommand(FileSystemContext? context)
    {
        _context = context;
    }

    public void Execute()
    {
        _context?.Disconnect();
    }
}