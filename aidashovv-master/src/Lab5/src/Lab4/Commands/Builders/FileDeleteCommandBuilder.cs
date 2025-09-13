using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileDeleteCommandBuilder : ICommandBuilder<FileDeleteCommand>
{
    private FileSystemContext? _context;
    private string? _sourcePath;

    public FileDeleteCommandBuilder()
    {
        _context = null;
        _sourcePath = null;
    }

    public FileDeleteCommandBuilder SetSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileDeleteCommandBuilder SetContext(FileSystemContext context)
    {
        _context = new FileSystemContext(context.CurrentFileSystem, context.CurrentPath);
        return this;
    }

    public FileDeleteCommand Build()
    {
        return new FileDeleteCommand(_context, _sourcePath);
    }
}