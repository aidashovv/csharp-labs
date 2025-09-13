using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility.Handlers;

public class FileDeleteCommandHandler : AbstractHandler
{
    private readonly FileSystemContext _fileSystemContext;

    public FileDeleteCommandHandler(FileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] != "file"
            || args[1] != "delete")
        {
            return base.Handle(args);
        }

        string sourcePath = args[2];

        FileDeleteCommandBuilder builder = new FileDeleteCommandBuilder()
            .SetSourcePath(sourcePath)
            .SetContext(_fileSystemContext);

        return builder.Build();
    }
}
