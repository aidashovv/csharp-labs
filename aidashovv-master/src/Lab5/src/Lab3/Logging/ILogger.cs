using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public interface ILogger
{
    void Log(Message? message);
}