using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

public class SimpleRouteSegment : IRouteSegment
{
    public double Time { get; set; } = 0;

    public double Force { get; } = 0;

    public double SpeedLimit { get; } = 0;

    public Distance DistanceOfSegment { get; }

    public SimpleRouteSegment(Distance distanceOfSegment)
    {
        DistanceOfSegment = distanceOfSegment;
    }
}