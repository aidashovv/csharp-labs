namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Distance
{
    public double Meters { get; }

    public double Precision { get; }

    public Distance(double meters, double precision)
    {
        if (meters < 0)
        {
            throw new ArgumentException("Distance isn't being negative");
        }

        Meters = meters;

        if (precision < 0)
        {
            throw new ArgumentException("Precision isn't being negative");
        }

        Precision = precision;
    }
}