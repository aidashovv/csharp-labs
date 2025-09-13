using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;

public class MessageBuilder
{
    public string? Header { get; private set; }

    public string? Body { get; private set; }

    public ImportanceLevel? ImportanceLevel { get; private set; }

    public MessageBuilder()
    {
        Header = string.Empty;
        Body = string.Empty;
        ImportanceLevel = new ImportanceLevel(-1);
    }

    public MessageBuilder WithHeader(string header)
    {
        Header = header;
        return this;
    }

    public MessageBuilder WithBody(string body)
    {
        Body = body;
        return this;
    }

    public MessageBuilder WithImportanceLevel(ImportanceLevel importanceLevel)
    {
        ImportanceLevel = importanceLevel;
        return this;
    }

    public Message Build()
    {
        return new Message(Header, Body, ImportanceLevel);
    }
}