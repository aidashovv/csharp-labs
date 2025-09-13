using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class EducationalProgramRepository : IRepository<EducationalProgram>
{
    private readonly Dictionary<int, EducationalProgram> _educationalPrograms = [];

    public EducationalProgram GetById(int id)
    {
        return (_educationalPrograms.ContainsKey(id) ? _educationalPrograms[id] : null) ?? throw new InvalidOperationException();
    }

    public void Add(EducationalProgram model)
    {
        if (!_educationalPrograms.ContainsKey(model.Id))
            _educationalPrograms[model.Id] = model;
    }

    public void Update(EducationalProgram model)
    {
        if (_educationalPrograms.ContainsKey(model.Id))
            _educationalPrograms[model.Id] = model;
    }
}