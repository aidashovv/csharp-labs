using Itmo.ObjectOrientedProgramming.Lab2.Models;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class SemesterSubjects
{
    public SemesterSubjects(int semester, Collection<Subject> subjects)
    {
        Semester = semester;
        Subjects = new Collection<Subject>(subjects);
    }

    public int Semester { get; private set; }

    public Collection<Subject> Subjects { get; private set; }
}
