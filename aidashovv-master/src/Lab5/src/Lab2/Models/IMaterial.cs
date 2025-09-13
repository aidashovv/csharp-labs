using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IMaterial
{
    string? Name { get; set; }

    Content? Description { get; set; }

    Content? Content { get; set; }

    IUser? Author { get; set; }
}