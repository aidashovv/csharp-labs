using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Log(Message? message)
    {
        File.AppendAllText(_filePath, $"[File] {message?.Header}{Environment.NewLine}, {message?.Body}{Environment.NewLine}");
    }
}