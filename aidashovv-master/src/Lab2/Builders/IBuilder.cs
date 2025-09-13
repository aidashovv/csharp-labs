namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public interface IBuilder<out T>
{
    T Build();
}
