namespace Lab5.Application.Models.ResultTypes;

public abstract class OperationResult<T>
{
    protected OperationResult() { }

    public sealed class SuccessValue : OperationResult<T>
    {
        public SuccessValue(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }

    public sealed class FailureWithCreateOperation(string message) : OperationResult<T>
    {
        public string Message { get; private set; } = message;
    }
}
