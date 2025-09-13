using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class LoggingDecorator : IRecipient
{
    private readonly IRecipient _decoratedRecipient;
    private readonly ILogger _logger;

    public LoggingDecorator(IRecipient decoratedRecipient, ILogger logger)
    {
        _decoratedRecipient = decoratedRecipient;
        _logger = logger;
    }

    public void ReceiveMessage(Message? receivedMessage)
    {
        _logger.Log(receivedMessage);
        _decoratedRecipient.ReceiveMessage(receivedMessage);
    }
}
