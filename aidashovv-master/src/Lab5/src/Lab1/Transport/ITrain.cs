using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Result;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Transport;

public interface ITrain
{
    public Mass Mass { get; }

    public double Speed { get; set; }

    public double Acceleration { get; set; }

    public double MaxForce { get; set; }

    public ResultType CalculateResultTime(IRouteSegment routeSegment);
}