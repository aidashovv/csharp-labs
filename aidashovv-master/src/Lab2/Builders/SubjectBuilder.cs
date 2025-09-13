using Itmo.ObjectOrientedProgramming.Lab2.Formats;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SubjectBuilder : IBuilder<Subject>
{
    private int _id;
    private string? _name;
    private IUser? _author;
    private IFormat? _format;
    private Collection<Lab> _labsList;
    private Collection<LectureMaterial> _lectureMaterialList;

    public SubjectBuilder()
    {
        _id = -1;
        _name = string.Empty;
        _author = new User(-1, string.Empty);
        _labsList = [];
        _lectureMaterialList = [];
    }

    public SubjectBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public SubjectBuilder SetName(string? name)
    {
        _name = name;
        return this;
    }

    public SubjectBuilder SetAuthor(IUser? author)
    {
        _author = author;
        return this;
    }

    public SubjectBuilder SetFormat(IFormat? format)
    {
        _format = format;
        return this;
    }

    public SubjectBuilder SetLabsList(Collection<Lab> labsList)
    {
        _labsList = new Collection<Lab>(labsList);
        return this;
    }

    public SubjectBuilder SetLectureMaterialsList(Collection<LectureMaterial> lectureMaterialsList)
    {
        _lectureMaterialList = new Collection<LectureMaterial>(lectureMaterialsList);
        return this;
    }

    public Subject Build()
    {
        return new Subject(_id, _name, _author, _format, _labsList, _lectureMaterialList);
    }
}