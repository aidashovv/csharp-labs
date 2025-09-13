using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

public class Station : IRouteSegment
{
    public double Time { get; set; }

    public Distance DistanceOfSegment { get; }

    public double Force { get; } = 0;

    public double SpeedLimit { get; }

    private int ComingOutPeople { get; }

    private int ComingInPeople { get; }

    public Station(int comingOutPeople, int comingInPeople, double speedLimit)
    {
        if ((comingOutPeople > 0 && comingInPeople >= 0)
            || (comingOutPeople >= 0 && comingInPeople > 0)
            || (comingOutPeople > 0 && comingInPeople > 0))
        {
            ComingOutPeople = comingOutPeople;
            ComingInPeople = comingInPeople;
            SpeedLimit = speedLimit;
            Time = ComingInPeople - ComingOutPeople;
        }

        DistanceOfSegment = new Distance(0, 0);
    }
}