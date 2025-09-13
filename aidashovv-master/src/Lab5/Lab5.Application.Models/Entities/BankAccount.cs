namespace Lab5.Application.Models.Entities;

public class BankAccount
{
    public BankAccount(Guid id, Guid ownerId, string pin, int balance)
    {
        Id = id;
        OwnerId = ownerId;
        Pin = pin;
        Balance = balance;
    }

    public Guid Id { get; private set; }

    public Guid OwnerId { get; private set; }

    public string Pin { get; private set; }

    public int Balance { get; private set; }

    public void ChangeBalance(int value)
    {
        Balance = value;
    }
}
