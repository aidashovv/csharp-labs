using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class LabFactory : BaseMaterialFactory<Lab>
{
    public LabFactory(IRepository<Lab> repository) : base(repository) { }

    public override Lab CreateModel(IBuilder<Lab> builder)
    {
        Lab currentLab = builder.Build();

        Repository.Add(currentLab);

        return currentLab;
    }
}
