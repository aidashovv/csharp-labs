using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formats;

public interface IFormat
{
    public ResultType CalculatePoints(Collection<Lab>? labsList);

    public IFormat Copy();
}