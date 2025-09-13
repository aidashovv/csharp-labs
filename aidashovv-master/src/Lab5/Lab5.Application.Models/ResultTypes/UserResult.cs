namespace Lab5.Application.Models.ResultTypes;

public class UserResult<T>
{
    protected UserResult() { }

    public sealed class Success : UserResult<T> { }

    public sealed class SuccessValue : UserResult<T>
    {
        public SuccessValue(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }

    public sealed class Failure(string message) : UserResult<T>
    {
        public string Message { get; private set; } = message;
    }
}