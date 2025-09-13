using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;

public class Message
{
    public string? Header { get; private set; }

    public string? Body { get; private set; }

    public ImportanceLevel? ImportanceLevel { get; private set; }

    public Message(string? header, string? body, ImportanceLevel? level)
    {
        Header = header;
        Body = body;
        ImportanceLevel = level;
    }
}