namespace Lab5.Application.Models.Entities;

public class Operation
{
    public Operation(Guid id, Guid ownerId, string name, double amount)
    {
        Id = id;
        OwnerId = ownerId;
        Name = name;
        Amount = amount;
    }

    public Guid Id { get; private set; }

    public Guid OwnerId { get; private set; }

    public string Name { get; private set; }

    public double Amount { get; private set; }
}