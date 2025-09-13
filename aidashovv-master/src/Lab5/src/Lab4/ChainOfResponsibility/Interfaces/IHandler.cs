using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility.Interfaces;

public interface IHandler
{
    public IHandler SetNext(IHandler handler);

    ICommand? Handle(string[] args);
}