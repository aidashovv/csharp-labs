namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository<T>
{
    T GetById(int id);

    void Add(T model);

    void Update(T model);
}