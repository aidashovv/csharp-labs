using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class MessengerRecipient : IRecipient
{
    private readonly ILogger _logger;

    public MessengerRecipient(ILogger logger)
    {
        _logger = logger;
    }

    public void ReceiveMessage(Message? receivedMessage)
    {
        if (receivedMessage == null)
        {
            _logger.Log(new Message("Warning", "Received null message. Skipping...", null));
            return;
        }

        _logger.Log(new Message("Messenger", $"{receivedMessage.Header}\n{receivedMessage.Body}", receivedMessage.ImportanceLevel));
    }
}