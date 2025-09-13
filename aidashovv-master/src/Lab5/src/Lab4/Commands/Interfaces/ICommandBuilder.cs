namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;

public interface ICommandBuilder<out T>
{
    T Build();
}