namespace Itmo.ObjectOrientedProgramming.Lab1.Result;

public interface IResultType
{
    bool IsSuccess { get; }

    double Time { get; }
}