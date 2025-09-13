using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public abstract class BaseMaterialFactory<T> : IFactory<T> where T : class, IMaterial, new()
{
    protected IRepository<T> Repository { get; private set; }

    protected BaseMaterialFactory(IRepository<T> repository)
    {
        Repository = repository;
    }

    public abstract T CreateModel(IBuilder<T> builder);

    public ResultType UpdateModel(
        IUser author,
        int idModel,
        string? name = null,
        Content? description = null,
        Content? content = null)
    {
        T material = Repository.GetById(idModel) ?? throw new KeyNotFoundException($"{typeof(T).Name} not found");

        if (material.Author != author) return new ResultType(false);

        if (name != null)
            material.Name = name;

        if (description != null)
            material.Description = description;

        if (content != null)
            material.Content = content;

        Repository.Update(material);

        return new ResultType(true);
    }
}
