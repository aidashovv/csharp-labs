using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Result;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Transport;

public class Train : ITrain
{
    public Mass Mass { get; }

    public double Speed { get; set; }

    public double Acceleration { get; set; }

    public double MaxForce { get; set; }

    public Train(Mass mass, double speed, double acceleration, double maxForce)
    {
        Mass = mass;
        Speed = speed;
        Acceleration = acceleration;
        MaxForce = maxForce;
    }

    public ResultType CalculateResultTime(IRouteSegment routeSegment)
    {
        if (routeSegment.DistanceOfSegment.Meters == 0)
        {
            if (Speed > routeSegment.SpeedLimit)
            {
                return new ResultType(routeSegment.Time);
            }
        }

        if (routeSegment.Force != 0)
        {
            if (routeSegment.Force > MaxForce)
            {
                return new ResultType(routeSegment.Time);
            }

            Acceleration = routeSegment.Force / Mass.Value;

            double routeSegmentDistance = routeSegment.DistanceOfSegment.Meters;
            while (routeSegmentDistance >= 0)
            {
                if (Speed < 0)
                {
                    return new ResultType(routeSegment.Time);
                }

                Speed += Acceleration * routeSegment.DistanceOfSegment.Precision;
                routeSegmentDistance -= Speed * routeSegment.DistanceOfSegment.Precision;
                routeSegment.Time++;
            }
        }
        else
        {
            if (Speed <= 0)
            {
                return new ResultType(routeSegment.Time);
            }

            double routeSegmentDistance = routeSegment.DistanceOfSegment.Meters;
            while (routeSegmentDistance >= 0)
            {
                if (Speed < 0)
                {
                    return new ResultType(routeSegment.Time);
                }

                Speed += Acceleration * routeSegment.DistanceOfSegment.Precision;
                routeSegmentDistance -= Speed * routeSegment.DistanceOfSegment.Precision;
                routeSegment.Time++;
            }
        }

        return new ResultType(routeSegment.Time);
    }
}
