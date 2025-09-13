using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class EducationalProgram
{
    public EducationalProgram(int id, string? name, IUser? programDirector, Collection<SemesterSubjects> subjectsBySemester)
    {
        Id = id;
        Name = name;
        ProgramDirector = programDirector;
        SubjectsBySemester = new Collection<SemesterSubjects>(subjectsBySemester);
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public IUser? ProgramDirector { get; set; }

    public Collection<SemesterSubjects> SubjectsBySemester { get; private set; } = [];

    public void AddSubject(int semester, Subject subject)
    {
        SemesterSubjects? semesterSubjects = SubjectsBySemester.FirstOrDefault(s => s.Semester == semester);

        if (semesterSubjects == null)
        {
            semesterSubjects = new SemesterSubjects(semester, []);
            SubjectsBySemester.Add(semesterSubjects);
        }

        semesterSubjects.Subjects.Add(subject);
    }
}