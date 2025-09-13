namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public interface IUser
{
    public int Id { get; }

    public string Name { get; }

    public IUser Copy();
}