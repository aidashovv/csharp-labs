using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility.Handlers;

public class ConnectionCommandHandler : AbstractHandler
{
    private readonly FileSystemContext _fileSystemContext;

    public ConnectionCommandHandler(FileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] != "connect"
            || args[2] != "-m"
            || args[3] != "local")
        {
            return base.Handle(args);
        }

        string mode = args[3];
        string address = args[1];

        ConnectionCommandBuilder builder = new ConnectionCommandBuilder()
            .SetAddress(address)
            .SetMode(mode)
            .SetContext(_fileSystemContext);

        return builder.Build();
    }
}