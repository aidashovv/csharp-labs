using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class DisplayRecipient : IRecipient
{
    public Display? Display { get; private set; }

    public DisplayRecipient(Display? display)
    {
        Display = display;
    }

    public void ReceiveMessage(Message? receivedMessage)
    {
        Display?.ReceiveMessage(receivedMessage);
    }
}