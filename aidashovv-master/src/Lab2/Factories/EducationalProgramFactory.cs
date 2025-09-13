using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class EducationalProgramFactory : IFactory<EducationalProgram>
{
    private readonly IRepository<EducationalProgram> _repository;

    public EducationalProgramFactory(IRepository<EducationalProgram> repository)
    {
        _repository = repository;
    }

    public EducationalProgram CreateModel(IBuilder<EducationalProgram> builder)
    {
        EducationalProgram educationalProgram = builder.Build();

        _repository.Add(educationalProgram);

        return educationalProgram;
    }
}
