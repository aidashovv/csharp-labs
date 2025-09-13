using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileShowCommandBuilder : ICommandBuilder<FileShowCommand>
{
    private FileSystemContext? _context;
    private string? _destinationPath;
    private string? _mode;

    public FileShowCommandBuilder()
    {
        _context = null;
        _destinationPath = null;
        _mode = null;
    }

    public FileShowCommandBuilder SetDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public FileShowCommandBuilder SetMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public FileShowCommandBuilder SetContext(FileSystemContext context)
    {
        _context = new FileSystemContext(context.CurrentFileSystem, context.CurrentPath);
        return this;
    }

    public FileShowCommand Build()
    {
        return new FileShowCommand(_context, _destinationPath, _mode);
    }
}