using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.DisplayDriver;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly string _filePath;
    private Color _currentColor;

    public FileDisplayDriver(string filePath, Color color)
    {
        _filePath = filePath;
        _currentColor = color;
    }

    public void Clear()
    {
        File.WriteAllText(_filePath, string.Empty);
    }

    public void SetColor(Color color)
    {
        _currentColor = color;
    }

    public void WriteText(ILogger? logger, Message? message)
    {
        string coloredText = $"[Color: {_currentColor.Name}] {message?.Header}\n{message?.Body}";
        logger?.Log(message);
        File.AppendAllText(_filePath, coloredText + Environment.NewLine);
    }
}