using Itmo.ObjectOrientedProgramming.Lab2.Formats;
using Itmo.ObjectOrientedProgramming.Lab2.Prototypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Subject : IItem<Subject>
{
    public Subject(int basedOnId)
    {
        BasedOnId = basedOnId;
    }

    public Subject(int id, string? name, IUser? author, IFormat? format, Collection<Lab> labsList, Collection<LectureMaterial> lectureMaterialsList)
    {
        Id = id;
        Name = name;
        Author = author;
        Format = format;
        LabsList = new Collection<Lab>(labsList);
        LectureMaterialsList = new Collection<LectureMaterial>(lectureMaterialsList);
    }

    public int BasedOnId { get; private set; } = -1;

    public int Id { get; private set; }

    public string? Name { get; private set; }

    public IUser? Author { get; private set; }

    public IFormat? Format { get; private set; }

    public Collection<Lab> LabsList { get; private set; } = [];

    public Collection<LectureMaterial> LectureMaterialsList { get; private set; } = [];

    public void AddLab(Lab lab)
    {
        if (lab == null)
            throw new ArgumentNullException(nameof(lab), "Lab can't be null");

        if (LabsList != null && LabsList.Any(l => l.Id == lab.Id))
            throw new InvalidOperationException("This lab is already added to the subject");

        LabsList?.Add(lab);
    }

    public void AddLectureMaterial(LectureMaterial lectureMaterial)
    {
        if (lectureMaterial == null)
            throw new ArgumentNullException(nameof(lectureMaterial), "Lecture material can't be null");

        if (LectureMaterialsList != null && LectureMaterialsList.Any(l => l.Id == lectureMaterial.Id))
            throw new InvalidOperationException("This lecture material is already added to the subject");

        LectureMaterialsList?.Add(lectureMaterial);
    }

    public Subject Clone(int id)
    {
        var clonedSubject = new Subject(Id)
        {
            Id = id,
            Name = Name,
            Author = Author?.Copy(),
            Format = Format?.Copy(),
            LabsList = [],
            LectureMaterialsList = [],
        };

        foreach (Lab lab in LabsList)
        {
            clonedSubject.LabsList.Add(lab.Clone(lab.Id));
        }

        foreach (LectureMaterial lectureMaterial in LectureMaterialsList)
        {
            clonedSubject.LectureMaterialsList.Add(lectureMaterial.Clone(lectureMaterial.Id));
        }

        return clonedSubject;
    }

    public void SetName(string? name)
    {
        Name = name;
    }

    public void SetFormat(IFormat? format)
    {
        Format = format;
    }

    public void SetLectureMaterialList(Collection<LectureMaterial> lectureMaterialsList)
    {
        LectureMaterialsList = new Collection<LectureMaterial>(lectureMaterialsList);
    }
}