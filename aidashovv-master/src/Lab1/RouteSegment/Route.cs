using Itmo.ObjectOrientedProgramming.Lab1.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

public class Route
{
    private double Time { get; set; }

    private Collection<IRouteSegment> RouteSegments { get; }

    private double RouteSpeedLimit { get; }

    public Route(Collection<IRouteSegment> routeSegments, double routeSpeedLimit)
    {
        RouteSegments = routeSegments;
        RouteSpeedLimit = routeSpeedLimit;
        Time = 0;
    }

    public ResultType LetsGoPassedPath(ITrain train)
    {
        foreach (IRouteSegment routeSegment in RouteSegments)
        {
            if (!train.CalculateResultTime(routeSegment).IsSuccess)
            {
                return new ResultType(0);
            }

            Time += train.CalculateResultTime(routeSegment).Time;
        }

        if (train.Speed > RouteSpeedLimit)
        {
            return new ResultType(0);
        }

        return new ResultType(Time);
    }
}