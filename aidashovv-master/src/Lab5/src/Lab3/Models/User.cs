using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class User
{
    private Message? _receivedMessage;

    public void ReceiveMessage(Message? receivedMessage)
    {
        _receivedMessage = receivedMessage;
    }

    public bool MarkMessageAsRead()
    {
        if (_receivedMessage?.ImportanceLevel is { IsRead: false })
        {
            _receivedMessage.ImportanceLevel.ChangeStatus();
            return true;
        }

        return false;
    }
}