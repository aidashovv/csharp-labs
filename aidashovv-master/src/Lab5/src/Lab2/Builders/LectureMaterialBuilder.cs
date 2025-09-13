using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class LectureMaterialBuilder : BaseMaterialBuilder<LectureMaterial>
{
    public override LectureMaterial Build()
    {
        return new LectureMaterial(Id, Name, Description, Content, Author);
    }
}