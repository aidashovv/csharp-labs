using Itmo.ObjectOrientedProgramming.Lab3.Models.DisplayDriver;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class Display
{
    public Message? ReceivedMessage { get; private set; }

    public Color Color { get; private set; }

    public IDisplayDriver? DisplayDriver { get; private set; }

    public Display(Color color, IDisplayDriver? displayDriver)
    {
        Color = color;
        DisplayDriver = displayDriver;
    }

    public void ReceiveMessage(Message? receivedMessage)
    {
        ReceivedMessage = receivedMessage;
    }
}