namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Mass
{
    public double Value { get; }

    public Mass(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Mass is bigger than 0!");
        }

        Value = value;
    }
}