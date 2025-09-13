using Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility.Handlers;

public abstract class AbstractHandler : IHandler
{
    private IHandler? _nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual ICommand? Handle(string[] args)
    {
        return _nextHandler?.Handle(args);
    }
}
