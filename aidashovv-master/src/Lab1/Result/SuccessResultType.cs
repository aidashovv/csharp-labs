namespace Itmo.ObjectOrientedProgramming.Lab1.Result;

public class SuccessResultType : IResultType
{
    public bool IsSuccess { get; } = true;

    public double Time { get; }

    public SuccessResultType(double time)
    {
        Time = time;
    }
}