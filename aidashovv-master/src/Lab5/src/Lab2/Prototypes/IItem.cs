namespace Itmo.ObjectOrientedProgramming.Lab2.Prototypes;

public interface IItem<out T>
{
    T Clone(int id);
}