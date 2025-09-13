using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public interface IFactory<T>
{
    T CreateModel(IBuilder<T> builder);
}