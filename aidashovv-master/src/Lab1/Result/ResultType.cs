namespace Itmo.ObjectOrientedProgramming.Lab1.Result;

public class ResultType
{
    public bool IsSuccess { get; }

    public double Time { get; }

    public ResultType(double time)
    {
        Time = time;
        if (Time != 0)
        {
            IsSuccess = true;
        }
        else
        {
            IsSuccess = false;
        }
    }
}