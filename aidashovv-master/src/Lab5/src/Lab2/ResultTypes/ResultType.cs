namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public class ResultType
{
    public bool IsSuccess { get; }

    public ResultType(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }
}