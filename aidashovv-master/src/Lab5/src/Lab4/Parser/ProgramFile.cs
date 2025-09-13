using Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class ProgramFile
{
    private readonly List<AbstractHandler> _handlers;

    public ProgramFile(FileSystemContext fileSystemContext)
    {
        _handlers =
        [
            new ConnectionCommandHandler(fileSystemContext),
            new DisconnectionCommandHandler(fileSystemContext),
            new FileCopyCommandHandler(fileSystemContext),
            new FileMoveCommandHandler(fileSystemContext),
            new FileDeleteCommandHandler(fileSystemContext),
            new FileRenameCommandHandler(fileSystemContext),
            new FileShowCommandHandler(fileSystemContext),
            new TreeListCommandHandler(fileSystemContext),
            new TreeGotoCommandHandler(fileSystemContext)
        ];

        for (int i = 0; i < _handlers.Count - 1; i++)
        {
            _handlers[i].SetNext(_handlers[i + 1]);
        }
    }

    public ICommand? ParseCommand(string input)
    {
        string[] args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (args.Length == 0)
        {
            Console.WriteLine("Error: empty string.");
            return null;
        }

        return _handlers[0].Handle(args);
    }
}