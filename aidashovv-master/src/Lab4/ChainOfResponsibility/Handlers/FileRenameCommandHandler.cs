using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility.Handlers;

public class FileRenameCommandHandler : AbstractHandler
{
    private readonly FileSystemContext _fileSystemContext;

    public FileRenameCommandHandler(FileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] != "file"
            || args[1] != "rename")
        {
            return base.Handle(args);
        }

        string path = args[2];
        string newName = args[3];

        FileRenameCommandBuilder builder = new FileRenameCommandBuilder()
            .SetSourcePath(path)
            .SetNewName(newName)
            .SetContext(_fileSystemContext);

        return builder.Build();
    }
}
