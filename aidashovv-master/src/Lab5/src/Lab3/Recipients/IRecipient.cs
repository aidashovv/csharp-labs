using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public interface IRecipient
{
    void ReceiveMessage(Message? receivedMessage);
}