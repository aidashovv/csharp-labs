using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public abstract class BaseMaterialBuilder<T> : IBuilder<T> where T : new()
{
    protected int Id { get; private set; }

    protected string? Name { get; private set; }

    protected Content? Description { get; private set; }

    protected Content? Content { get; private set; }

    protected IUser? Author { get; private set; }

    public BaseMaterialBuilder<T> SetId(int id)
    {
        Id = id;
        return this;
    }

    public BaseMaterialBuilder<T> SetName(string name)
    {
        Name = name;
        return this;
    }

    public BaseMaterialBuilder<T> SetDescription(Content description)
    {
        Description = description;
        return this;
    }

    public BaseMaterialBuilder<T> SetContent(Content content)
    {
        Content = content;
        return this;
    }

    public BaseMaterialBuilder<T> SetAuthor(IUser author)
    {
        Author = author;
        return this;
    }

    public abstract T Build();
}