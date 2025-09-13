using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileRenameCommandBuilder : ICommandBuilder<FileRenameCommand>
{
    private FileSystemContext? _context;
    private string? _sourcePath;
    private string? _newName;

    public FileRenameCommandBuilder()
    {
        _context = null;
        _sourcePath = null;
        _newName = null;
    }

    public FileRenameCommandBuilder SetSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileRenameCommandBuilder SetNewName(string newName)
    {
        _newName = newName;
        return this;
    }

    public FileRenameCommandBuilder SetContext(FileSystemContext context)
    {
        _context = new FileSystemContext(context.CurrentFileSystem, context.CurrentPath);
        return this;
    }

    public FileRenameCommand Build()
    {
        return new FileRenameCommand(_context, _sourcePath, _newName);
    }
}