using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility.Handlers;

public class DisconnectionCommandHandler : AbstractHandler
{
    private readonly FileSystemContext _fileSystemContext;

    public DisconnectionCommandHandler(FileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] != "disconnect") return base.Handle(args);

        DisconnectionCommandBuilder builder = new DisconnectionCommandBuilder()
            .SetContext(_fileSystemContext);

        return builder.Build();
    }
}
