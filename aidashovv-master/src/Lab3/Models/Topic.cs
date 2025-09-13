using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class Topic
{
    private readonly Collection<IRecipient> _recipients = [];

    public Topic(string name)
    {
        Name = name;
    }

    public string? Name { get; private set; }

    public void AddRecipient(IRecipient target)
    {
        _recipients.Add(target);
    }

    public void RemoveRecipient(IRecipient target)
    {
        _recipients.Remove(target);
    }

    public void SendMessage(Message sendMessage)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.ReceiveMessage(sendMessage);
        }
    }
}