using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class SubjectRepository : IRepository<Subject>
{
    private readonly Dictionary<int, Subject> _subjects = [];

    public Subject GetById(int id)
    {
        return (_subjects.ContainsKey(id) ? _subjects[id] : null) ?? throw new InvalidOperationException();
    }

    public void Add(Subject model)
    {
        if (!_subjects.ContainsKey(model.Id))
            _subjects[model.Id] = model;
    }

    public void Update(Subject model)
    {
        if (_subjects.ContainsKey(model.Id))
            _subjects[model.Id] = model;
    }
}
