using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

public class PoweredRouteSegment : IRouteSegment
{
    public double Time { get; set; } = 0;

    public double Force { get; }

    public double SpeedLimit { get; } = 0;

    public Distance DistanceOfSegment { get; }

    public PoweredRouteSegment(double force, Distance distanceOfSegment)
    {
        Force = force;
        DistanceOfSegment = distanceOfSegment;
    }
}