using Itmo.ObjectOrientedProgramming.Lab2.Prototypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Lab : IItem<Lab>, IMaterial
{
    public Lab() { }

    public Lab(int basedOnId)
    {
        BasedOnId = basedOnId;
    }

    public Lab(int id, string? name, Content? description, Content? content, Points? points, IUser? author)
    {
        Id = id;
        Name = name;
        Description = description;
        Content = content;
        Points = points;
        Author = author;
    }

    public int BasedOnId { get; private set; } = -1;

    public int Id { get; set; }

    public string? Name { get; set; }

    public Content? Description { get; set; }

    public Content? Content { get; set; }

    public Points? Points { get; set; }

    public IUser? Author { get; set; }

    public Lab Clone(int id)
    {
        var clonedLab = new Lab(Id)
        {
            Id = id,
            Name = Name,
            Description = Content?.Copy(),
            Content = Content?.Copy(),
            Points = Points?.Copy(),
            Author = Author?.Copy(),
        };

        return clonedLab;
    }
}