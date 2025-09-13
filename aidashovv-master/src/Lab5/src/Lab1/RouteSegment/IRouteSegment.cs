using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

public interface IRouteSegment
{
    public double Time { get; set; }

    public double Force { get; }

    public double SpeedLimit { get; }

    public Distance DistanceOfSegment { get; }
}