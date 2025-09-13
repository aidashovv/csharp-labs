using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility.Handlers;

public class TreeGotoCommandHandler : AbstractHandler
{
    private readonly FileSystemContext _fileSystemContext;

    public TreeGotoCommandHandler(FileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] != "tree"
            || args[1] != "goto")
        {
            return base.Handle(args);
        }

        string path = args[2];
        TreeGotoCommandBuilder builder = new TreeGotoCommandBuilder()
            .SetDestinationPath(path)
            .SetContext(_fileSystemContext);

        return builder.Build();
    }
}