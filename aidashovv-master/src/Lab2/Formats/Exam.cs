using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formats;

public class Exam : IFormat
{
    public Exam(double examPoints)
    {
        Points = new Points(examPoints);
    }

    public Points Points { get; private set; }

    public ResultType CalculatePoints(Collection<Lab>? labsList)
    {
        if (labsList == null) throw new NullReferenceException("Lab not exist");

        double totalPossiblePoints = labsList
            .Where(lab => lab.Points != null)
            .Sum(lab =>
            {
                if (lab.Points != null)
                    return lab.Points.PossiblePoints;
                return -1;
            });

        Points.PossiblePoints += totalPossiblePoints;

        return new ResultType(Points.PossiblePoints <= 100);
    }

    public IFormat Copy()
    {
        return new Exam(Points.PossiblePoints);
    }
}