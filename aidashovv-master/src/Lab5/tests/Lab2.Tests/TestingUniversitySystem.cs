using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Formats;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab2.Tests;

public class TestingUniversitySystem
{
    [Fact]
    public void Test1()
    {
        // arrange
        IUser user1 = new User(1, "Amir");

        // create repositories
        var labsRepository = new LabRepository();
        var lectureMaterialRepository = new LectureMaterialRepository();
        var subjectsRepository = new SubjectRepository();
        var educationalProgramRepository = new EducationalProgramRepository();

        // create lab
        var labBuilder = new LabBuilder();
        labBuilder.SetId(10);
        labBuilder.SetName("Lab-1");
        labBuilder.SetAuthor(user1);
        labBuilder.SetContent(new Content("Some criteria"));
        labBuilder.SetDescription(new Content("Some description"));
        labBuilder.SetPoints(new Points(20));

        var factoryLab = new LabFactory(labsRepository);

        Lab firstLab = factoryLab.CreateModel(labBuilder);

        // create lecture materials
        var lectureMaterialBuilder = new LectureMaterialBuilder();
        lectureMaterialBuilder.SetId(11);
        lectureMaterialBuilder.SetName("Material-1");
        lectureMaterialBuilder.SetAuthor(user1);
        lectureMaterialBuilder.SetDescription(new Content("Some description"));
        lectureMaterialBuilder.SetContent(new Content("Some content"));

        var factoryLectureMaterial = new LectureMaterialFactory(lectureMaterialRepository);

        LectureMaterial firstLectureMaterial = factoryLectureMaterial.CreateModel(lectureMaterialBuilder);

        // create subjects
        var subjectBuilder = new SubjectBuilder();
        subjectBuilder.SetId(18);
        subjectBuilder.SetName("Subject-1");
        subjectBuilder.SetAuthor(user1);
        subjectBuilder.SetFormat(new Zachet(60));
        subjectBuilder.SetLabsList([firstLab]);
        subjectBuilder.SetLectureMaterialsList([firstLectureMaterial]);

        var factorySubject = new SubjectFactory(subjectsRepository);

        Subject firstSubject = factorySubject.CreateModel(subjectBuilder);

        // create education program
        var educationProgramBuilder = new EducationalProgramBuilder();
        educationProgramBuilder.SetId(19);
        educationProgramBuilder.SetName("IS-1");
        educationProgramBuilder.SetAuthor(user1);

        Collection<SemesterSubjects> semesterSubjects = [new SemesterSubjects(1, [firstSubject])];
        educationProgramBuilder.SetSubjectList(semesterSubjects);

        var factoryEducationalProgram = new EducationalProgramFactory(educationalProgramRepository);

        EducationalProgram firstEducationalProgram = factoryEducationalProgram.CreateModel(educationProgramBuilder);

        // try to update lab by not author
        IUser user2 = new User(2, "Bob");
        ResultType result = factoryLab.UpdateModel(user2, firstLab.Id, "Lab-1.1");

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void Test2()
    {
        // arrange
        IUser user1 = new User(1, "Amir");

        // create repositories
        var labsRepository = new LabRepository();

        // create lab-1
        var labBuilder = new LabBuilder();
        labBuilder.SetId(10);
        labBuilder.SetName("Lab-1");
        labBuilder.SetAuthor(user1);
        labBuilder.SetContent(new Content("Some criteria"));
        labBuilder.SetDescription(new Content("Some description"));
        labBuilder.SetPoints(new Points(20));

        var factoryLab = new LabFactory(labsRepository);

        Lab firstLab = factoryLab.CreateModel(labBuilder);

        // create lab-2 by cloned
        Lab secondLab = firstLab.Clone(20);

        // assert
        Assert.Equal(firstLab.Id, secondLab.BasedOnId);
    }

    [Fact]
    public void Test3()
    {
        // arrange
        IUser user1 = new User(1, "Amir");

        // create repositories
        var labsRepository = new LabRepository();
        var lectureMaterialRepository = new LectureMaterialRepository();
        var subjectsRepository = new SubjectRepository();
        var educationalProgramRepository = new EducationalProgramRepository();

        // create labs
        var labBuilder1 = new LabBuilder();
        labBuilder1.SetId(10);
        labBuilder1.SetName("Lab-1");
        labBuilder1.SetAuthor(user1);
        labBuilder1.SetContent(new Content("Some criteria"));
        labBuilder1.SetDescription(new Content("Some description"));
        labBuilder1.SetPoints(new Points(50));

        var factoryLab = new LabFactory(labsRepository);

        Lab firstLab = factoryLab.CreateModel(labBuilder1);

        var labBuilder2 = new LabBuilder();
        labBuilder2.SetId(10);
        labBuilder2.SetName("Lab-1");
        labBuilder2.SetAuthor(user1);
        labBuilder2.SetContent(new Content("Some criteria"));
        labBuilder2.SetDescription(new Content("Some description"));
        labBuilder2.SetPoints(new Points(50));

        Lab secondLab = factoryLab.CreateModel(labBuilder2);

        // create lecture materials
        var lectureMaterialBuilder = new LectureMaterialBuilder();
        lectureMaterialBuilder.SetId(11);
        lectureMaterialBuilder.SetName("Material-1");
        lectureMaterialBuilder.SetAuthor(user1);
        lectureMaterialBuilder.SetDescription(new Content("Some description"));
        lectureMaterialBuilder.SetContent(new Content("Some content"));

        var factoryLectureMaterial = new LectureMaterialFactory(lectureMaterialRepository);

        LectureMaterial firstLectureMaterial = factoryLectureMaterial.CreateModel(lectureMaterialBuilder);

        // create subjects
        var subjectBuilder = new SubjectBuilder();
        subjectBuilder.SetId(18);
        subjectBuilder.SetName("Subject-1");
        subjectBuilder.SetAuthor(user1);
        subjectBuilder.SetFormat(new Zachet(60));
        subjectBuilder.SetLabsList([firstLab, secondLab]);
        subjectBuilder.SetLectureMaterialsList([firstLectureMaterial]);

        var factorySubject = new SubjectFactory(subjectsRepository);

        Subject firstSubject = factorySubject.CreateModel(subjectBuilder);

        // create education program
        var educationProgramBuilder = new EducationalProgramBuilder();
        educationProgramBuilder.SetId(19);
        educationProgramBuilder.SetName("IS-1");
        educationProgramBuilder.SetAuthor(user1);

        Collection<SemesterSubjects> semesterSubjects = [new SemesterSubjects(1, [firstSubject])];
        educationProgramBuilder.SetSubjectList(semesterSubjects);

        var factoryEducationalProgram = new EducationalProgramFactory(educationalProgramRepository);

        EducationalProgram firstEducationalProgram = factoryEducationalProgram.CreateModel(educationProgramBuilder);

        // act
        ResultType? result = firstSubject.Format?.CalculatePoints(firstSubject.LabsList);

        // assert
        Assert.True(result?.IsSuccess);
    }
}