using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class LectureMaterialRepository : IRepository<LectureMaterial>
{
    private readonly Dictionary<int, LectureMaterial> _lectureMaterials = [];

    public LectureMaterial GetById(int id)
    {
        return (_lectureMaterials.ContainsKey(id) ? _lectureMaterials[id] : null) ?? throw new InvalidOperationException();
    }

    public void Add(LectureMaterial model)
    {
        if (!_lectureMaterials.ContainsKey(model.Id))
            _lectureMaterials[model.Id] = model;
    }

    public void Update(LectureMaterial model)
    {
        if (_lectureMaterials.ContainsKey(model.Id))
            _lectureMaterials[model.Id] = model;
    }
}