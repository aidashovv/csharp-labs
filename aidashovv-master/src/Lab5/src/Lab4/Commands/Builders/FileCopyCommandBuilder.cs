using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileCopyCommandBuilder : ICommandBuilder<FileCopyCommand>
{
    private FileSystemContext? _context;
    private string? _sourcePath;
    private string? _destinationPath;

    public FileCopyCommandBuilder()
    {
        _context = null;
        _sourcePath = null;
        _destinationPath = null;
    }

    public FileCopyCommandBuilder SetSourcePath(string? sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileCopyCommandBuilder SetDestinationPath(string? destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public FileCopyCommandBuilder SetContext(FileSystemContext context)
    {
        _context = new FileSystemContext(context.CurrentFileSystem, context.CurrentPath);
        return this;
    }

    public FileCopyCommand Build()
    {
        return new FileCopyCommand(_context, _sourcePath, _destinationPath);
    }
}
