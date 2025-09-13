using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class LectureMaterialFactory : BaseMaterialFactory<LectureMaterial>
{
    public LectureMaterialFactory(IRepository<LectureMaterial> repository) : base(repository) { }

    public override LectureMaterial CreateModel(IBuilder<LectureMaterial> builder)
    {
        LectureMaterial currentLectureMaterial = builder.Build();

        Repository.Add(currentLectureMaterial);

        return currentLectureMaterial;
    }
}