using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class UserRecipient : IRecipient
{
    private readonly User? _user;

    public UserRecipient(User? user)
    {
        _user = user;
    }

    public void ReceiveMessage(Message? receivedMessage)
    {
        _user?.ReceiveMessage(receivedMessage);
    }
}