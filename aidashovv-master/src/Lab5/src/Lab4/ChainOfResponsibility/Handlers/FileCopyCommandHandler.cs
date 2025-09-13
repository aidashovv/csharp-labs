using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility.Handlers;

public class FileCopyCommandHandler : AbstractHandler
{
    private readonly FileSystemContext _fileSystemContext;

    public FileCopyCommandHandler(FileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] != "file"
            || args[1] != "copy")
        {
            return base.Handle(args);
        }

        string sourcePath = args[2];
        string destinationPath = args[3];

        FileCopyCommandBuilder builder = new FileCopyCommandBuilder()
            .SetSourcePath(sourcePath)
            .SetDestinationPath(destinationPath)
            .SetContext(_fileSystemContext);

        return builder.Build();
    }
}
