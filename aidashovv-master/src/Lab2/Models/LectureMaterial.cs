using Itmo.ObjectOrientedProgramming.Lab2.Prototypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class LectureMaterial : IItem<LectureMaterial>, IMaterial
{
    public LectureMaterial() { }

    public LectureMaterial(int basedOnId)
    {
        BasedOnId = basedOnId;
    }

    public LectureMaterial(int id, string? name, Content? description, Content? content, IUser? author)
    {
        Id = id;
        Name = name;
        Description = description;
        Content = content;
        Author = author;
    }

    public int BasedOnId { get; private set; } = -1;

    public int Id { get; set; }

    public string? Name { get; set; }

    public Content? Description { get; set; }

    public Content? Content { get; set; }

    public IUser? Author { get; set; }

    public LectureMaterial Clone(int id)
    {
        var clonedLectureMaterial = new LectureMaterial(Id)
        {
            Id = id,
            Name = Name,
            Description = Content?.Copy(),
            Content = Content?.Copy(),
            Author = Author?.Copy(),
        };

        return clonedLectureMaterial;
    }
}