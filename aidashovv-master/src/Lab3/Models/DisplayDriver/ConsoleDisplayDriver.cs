using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.DisplayDriver;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private Color _currentColor;

    public ConsoleDisplayDriver(Color color)
    {
        _currentColor = color;
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        _currentColor = color;
    }

    public void WriteText(ILogger? logger, Message? message)
    {
        Console.ForegroundColor = MapColorToConsoleColor(_currentColor);
        logger?.Log(message);
        Console.WriteLine($"[ConsoleDisplay] {message?.Header}\n{message?.Body}");
        Console.ResetColor();
    }

    private ConsoleColor MapColorToConsoleColor(Color color)
    {
        return color switch
        {
            { R: > 200, G: > 200, B: > 200 } => ConsoleColor.White,
            { R: > 200, G: < 100, B: < 100 } => ConsoleColor.Red,
            { R: < 100, G: > 200, B: < 100 } => ConsoleColor.Green,
            { R: < 100, G: < 100, B: > 200 } => ConsoleColor.Blue,
            _ => ConsoleColor.Gray,
        };
    }
}