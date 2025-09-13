namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User : IUser
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public IUser Copy()
    {
        return new User(Id, Name);
    }
}