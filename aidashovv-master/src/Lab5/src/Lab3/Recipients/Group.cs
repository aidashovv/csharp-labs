using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class Group : IRecipient
{
    private readonly Collection<IRecipient> _recipients;

    public Group(Collection<IRecipient> recipients)
    {
        _recipients = new Collection<IRecipient>(recipients);
    }

    public void ReceiveMessage(Message? receivedMessage)
    {
        foreach (IRecipient r in _recipients) r.ReceiveMessage(receivedMessage);
    }
}