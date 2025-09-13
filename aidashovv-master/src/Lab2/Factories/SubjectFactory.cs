using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Formats;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class SubjectFactory : IFactory<Subject>
{
    private readonly IRepository<Subject> _repository;

    public SubjectFactory(IRepository<Subject> repository)
    {
        _repository = repository;
    }

    public Subject CreateModel(IBuilder<Subject> builder)
    {
        Subject currentSubject = builder.Build();

        _repository.Add(currentSubject);

        return currentSubject;
    }

    public ResultType UpdateModel(
        IUser author,
        int idModel,
        IFormat? format = null,
        string? name = null,
        Collection<LectureMaterial>? lectureMaterialsList = null)
    {
        Subject subject = _repository.GetById(idModel) ?? throw new KeyNotFoundException("Subject not found");

        if (subject.Author != author) return new ResultType(false);
        if (name != null)
            subject.SetName(name);

        if (format != null)
            subject.SetFormat(format);

        if (lectureMaterialsList != null)
        {
            subject.SetLectureMaterialList(lectureMaterialsList);
        }

        _repository.Update(subject);

        return new ResultType(true);
    }
}