using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class LabBuilder : BaseMaterialBuilder<Lab>
{
    private Points? _points;

    public LabBuilder SetPoints(Points points)
    {
        _points = points;
        return this;
    }

    public override Lab Build()
    {
        return new Lab(Id, Name, Description, Content, _points, Author);
    }
}