using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileMoveCommandBuilder : ICommandBuilder<FileMoveCommand>
{
    private FileSystemContext? _context;
    private string? _sourcePath;
    private string? _destinationPath;

    public FileMoveCommandBuilder()
    {
        _context = null;
        _sourcePath = null;
        _destinationPath = null;
    }

    public FileMoveCommandBuilder SetSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileMoveCommandBuilder SetDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public FileMoveCommandBuilder SetContext(FileSystemContext context)
    {
        _context = new FileSystemContext(context.CurrentFileSystem, context.CurrentPath);
        return this;
    }

    public FileMoveCommand Build()
    {
        return new FileMoveCommand(_context, _sourcePath, _destinationPath);
    }
}