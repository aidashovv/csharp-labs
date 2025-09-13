using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility.Handlers;

public class FileShowCommandHandler : AbstractHandler
{
    private readonly FileSystemContext _fileSystemContext;

    public FileShowCommandHandler(FileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] == "file"
            && args[1] == "show"
            && args[3] == "-m"
            && args[4] == "console")
        {
            string destinationPath = args[2];
            string mode = args[4];
            FileShowCommandBuilder builder = new FileShowCommandBuilder()
                .SetDestinationPath(destinationPath)
                .SetMode(mode)
                .SetContext(_fileSystemContext);

            return builder.Build();
        }

        if (args[0] == "file" && args[1] == "show")
        {
            string destinationPath = args[2];
            string mode = "console";
            FileShowCommandBuilder builder = new FileShowCommandBuilder()
                .SetDestinationPath(destinationPath)
                .SetMode(mode)
                .SetContext(_fileSystemContext);

            return builder.Build();
        }

        return base.Handle(args);
    }
}
