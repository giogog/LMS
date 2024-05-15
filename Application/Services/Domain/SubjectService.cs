using Contracts;
using Domain.Dtos;
using Domain.Enums;
using Domain.Models;
using Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Services;

public class SubjectService:ISubjectService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public SubjectService(IRepositoryManager repositoryManager,IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Subject>> GetActiveSubjectsByStudentId(int studentId)
    {
        return await _repositoryManager.EnrollmentRepository
            .GetByCondition(en => en.IsActive && en.StudentId == studentId)
            .Select(s => s.Lecture.Subject)
            .ToArrayAsync();

    }

    public async Task<IEnumerable<Subject>> GetPassedSubjectsByStudentId(int studentId)
    {
        var studentEnrollments = await _repositoryManager.EnrollmentRepository
            .GetByCondition(en => en.StudentId == studentId)
            .Include(en => en.Lecture).ThenInclude(l=>l.Subject).ToArrayAsync();

        return studentEnrollments.Select(en => en.Lecture.Subject);
    }

    public async Task<IEnumerable<Subject>> GetSubjectsByStudentId(int studentId)
    {
        return await _repositoryManager.EnrollmentRepository
            .GetByCondition(en => en.StudentId == studentId)
            .Select(s => s.Lecture.Subject)
            .ToArrayAsync();

    }

    public async Task<Result<SubjectDto>> RegisterNewSubject(SubjectDto subjectDto)
    {
        string[] gradeSystem = Enum.GetNames(typeof(GradeSystem));
        bool containsAll = subjectDto.gradeTypes.All(item => gradeSystem.Contains(item));

        if (!containsAll) return Result<SubjectDto>.Failed("Ivalid Grade Type");

        Array.Sort(subjectDto.gradeTypes);
        subjectDto.gradeTypes.ChangeRepeatedItemsNames();
        var subject = _mapper.Map<Subject>(subjectDto);

        try
        {
            _repositoryManager.SubjectRepository.AddSubject(subject);
            var saveResult = await _repositoryManager.SaveAsync();
            return Result<SubjectDto>.SuccesfullySaved(saveResult, subjectDto);
        }
        catch (Exception ex) 
        {
            return Result<SubjectDto>.Failed(ex.Message);
        }
    }
}
