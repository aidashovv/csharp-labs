namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class Points
{
    public double PossiblePoints { get; set; }

    public Points(double points)
    {
        if (points < 0)
        {
            throw new ArgumentException("Points aren't being negative");
        }

        PossiblePoints = points;
    }

    public Points Copy()
    {
        return new Points(this.PossiblePoints);
    }
}