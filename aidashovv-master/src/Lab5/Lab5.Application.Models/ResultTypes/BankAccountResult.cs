using Lab5.Application.Models.Entities;

namespace Lab5.Application.Models.ResultTypes;

public abstract class BankAccountResult<T> where T : BankAccount
{
    protected BankAccountResult() { }

    public sealed class SuccessValue : BankAccountResult<T>
    {
        public SuccessValue(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }

    public sealed class FailureWithAmount(string message) : BankAccountResult<T>
    {
        public string Message { get; private set; } = message;
    }

    public sealed class FailureWithCreateAccount(string message) : BankAccountResult<T>
    {
        public string Message { get; private set; } = message;
    }

    public sealed class FailureWithFindAccount(string message) : BankAccountResult<T>
    {
        public string Message { get; private set; } = message;
    }

    public sealed class FailureWithUpdate(string message) : BankAccountResult<T>
    {
        public string Message { get; private set; } = message;
    }
}