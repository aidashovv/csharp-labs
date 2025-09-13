using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.DisplayDriver;

public interface IDisplayDriver
{
    void Clear();

    void SetColor(Color color);

    void WriteText(ILogger? logger, Message? message);
}
