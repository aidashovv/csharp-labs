using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class LabRepository : IRepository<Lab>
{
    private readonly Dictionary<int, Lab> _labs = [];

    public Lab GetById(int id)
    {
        return (_labs.ContainsKey(id) ? _labs[id] : null) ?? throw new InvalidOperationException();
    }

    public void Add(Lab model)
    {
        if (!_labs.ContainsKey(model.Id))
            _labs[model.Id] = model;
    }

    public void Update(Lab model)
    {
        if (_labs.ContainsKey(model.Id))
            _labs[model.Id] = model;
    }
}
