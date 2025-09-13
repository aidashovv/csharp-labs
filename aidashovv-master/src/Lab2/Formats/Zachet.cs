using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formats;

public class Zachet : IFormat
{
    public Zachet(double minPoints)
    {
        MinRequiredPoints = new Points(minPoints);
    }

    public Points MinRequiredPoints { get; private set; }

    public ResultType CalculatePoints(Collection<Lab>? labsList)
    {
        if (labsList == null)
            throw new NullReferenceException("Lab not exist");

        double remainingPoints = labsList
            .Where(lab => lab.Points != null) // Фильтруем элементы с ненулевыми Points
            .Aggregate(MinRequiredPoints.PossiblePoints, (current, lab) =>
            {
                if (lab.Points != null) return current - lab.Points.PossiblePoints;
                return -1;
            });

        // Убедитесь, что всегда возвращается результат
        return new ResultType(remainingPoints <= 100);
    }

    public IFormat Copy()
    {
        return new Zachet(this.MinRequiredPoints.PossiblePoints);
    }
}