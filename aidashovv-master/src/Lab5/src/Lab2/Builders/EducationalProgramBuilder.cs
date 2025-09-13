using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class EducationalProgramBuilder : IBuilder<EducationalProgram>
{
    private int _id;
    private string? _name;
    private IUser? _programDirector;
    private Collection<SemesterSubjects> _subjectsBySemester;

    public EducationalProgramBuilder()
    {
        _id = -1;
        _name = string.Empty;
        _programDirector = new User(-1, string.Empty);
        _subjectsBySemester = [];
    }

    public EducationalProgramBuilder SetId(int id)
    {
       _id = id;
       return this;
    }

    public EducationalProgramBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public EducationalProgramBuilder SetAuthor(IUser author)
    {
        _programDirector = author;
        return this;
    }

    public EducationalProgramBuilder SetSubjectList(Collection<SemesterSubjects> subjectsBySemester)
    {
        _subjectsBySemester = new Collection<SemesterSubjects>(subjectsBySemester);
        return this;
    }

    public EducationalProgram Build()
    {
        return new EducationalProgram(_id, _name, _programDirector, _subjectsBySemester);
    }
}