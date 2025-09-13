using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class PriorityFilterProxy : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly int _minImportanceLevel;

    public PriorityFilterProxy(IRecipient recipient, int minImportanceLevel)
    {
        _recipient = recipient;
        _minImportanceLevel = minImportanceLevel;
    }

    public void ReceiveMessage(Message? receivedMessage)
    {
        if (receivedMessage?.ImportanceLevel?.Level >= _minImportanceLevel)
        {
            _recipient.ReceiveMessage(receivedMessage);
        }
    }
}