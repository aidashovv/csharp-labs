using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class ConsoleLog : ILogger
{
    public void Log(Message? message)
    {
        Console.WriteLine($"[Console] {message?.Header}{Environment.NewLine}, {message?.Body}{Environment.NewLine}");
    }
}