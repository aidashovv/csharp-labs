using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility.Handlers;

public class TreeListCommandHandler : AbstractHandler
{
    private readonly FileSystemContext _fileSystemContext;

    public TreeListCommandHandler(FileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] == "tree"
            && args[1] == "list"
            && args[2] == "-d")
        {
            string depth = args[3];
            TreeListCommandBuilder builder = new TreeListCommandBuilder()
                .SetContext(_fileSystemContext)
                .SetDepth(depth);

            return builder.Build();
        }

        if (args[0] == "tree"
            && args[1] == "list")
        {
            TreeListCommandBuilder builder = new TreeListCommandBuilder()
                .SetContext(_fileSystemContext)
                .SetDepth("1");

            return builder.Build();
        }

        return base.Handle(args);
    }
}