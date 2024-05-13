using Contracts;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class GradeService : IGradeService
{
    private readonly IRepositoryManager _repositoryManager;

    public GradeService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<Result<GradeDto>> AddGradeToStudent(int SubjectId,GradeDto gradeDto)
    {
        var subject = await _repositoryManager.SubjectRepository.GetSubjectById(SubjectId);
        var Enrollment = await _repositoryManager.TeacherRepository
            .GetByCondition(t => t.Id == gradeDto.TeacherId)
            .SelectMany(t => t.Lectures)
            .SelectMany(l => l.StudentEnrollments)
            .Where(en => en.StudentId == gradeDto.StudentId && en.IsActive)
            .FirstOrDefaultAsync();

        if (subject == null)
            return Result<GradeDto>.Failed("Subject Not Found");

        bool containsItem = subject.gradeTypes.Any(item => item == gradeDto.GradeType);
        if (!containsItem)
            return Result<GradeDto>.Failed("Subject doesn't have this type of Grade");

        int index = Array.IndexOf(subject.gradeTypes, subject.gradeTypes.FirstOrDefault(item => item == gradeDto.GradeType));
        Enrollment.Grades[index] = gradeDto.Grade;

        try
        {
            _repositoryManager.EnrollmentRepository.UpdateEnrollment(Enrollment);
            var saveResult = await _repositoryManager.SaveAsync();
            return Result<GradeDto>.SuccesfullySaved(saveResult, gradeDto);
        }
        catch(Exception ex) 
        {
            return Result<GradeDto>.Failed(ex.Message);
        }
    }

    public async Task<Result<Dictionary<string, double>>> GetGrades(int studentId,int subjectId)
    {
        var Enrollment = await _repositoryManager.EnrollmentRepository.GetEnrollmentByIds(en => en.StudentId == studentId);
        var subject = await _repositoryManager.EnrollmentRepository
            .GetByCondition(en=>en.StudentId==studentId && en.Lecture.SubjectId == subjectId)
            .Select(en=>en.Lecture.Subject)
            .FirstOrDefaultAsync();
        if (Enrollment == null)
            return Result<Dictionary<string, double>>.Failed("Enrollment Not Found");
        if(subject == null)
            return Result<Dictionary<string, double>>.Failed("Subject Not Found");


        var grades = new Dictionary<string, double>();
        for(int i = 0;i < Enrollment.Grades.Length; i++)
        {
            grades[subject.gradeTypes[i]] = Enrollment.Grades[i];
        }

        return Result<Dictionary<string, double>>.Success(grades);

    }


}
