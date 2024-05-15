using Application.Queries;
using AutoMapper;
using Contracts;
using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers;

public class StudentCardHandler : IRequestHandler<GetStudentCardQuery, Result<AcademicCardDto>>
{
    private readonly IServiceManager _serviceManage;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public StudentCardHandler(IServiceManager serviceManage,IMapper mapper,IRepositoryManager repositoryManager)
    {
        _serviceManage = serviceManage;
        _mapper = mapper;
        _repositoryManager = repositoryManager;
    }

    public async Task<Result<AcademicCardDto>> Handle(GetStudentCardQuery request, CancellationToken cancellationToken)
    {
        var studentSubjects = await _serviceManage.SubjectService.GetSubjectsByStudentId(request.studentId);
        var studentEnrollments = await _repositoryManager.EnrollmentRepository.GetByCondition(en => en.StudentId == request.studentId).ToArrayAsync();
        var GPA = await _serviceManage.AcademicService.CalculateStudentGpa(request.studentId);
        var PassedCredits = await _serviceManage.AcademicService.CalculateAchievedCredits(request.studentId);

        if (studentEnrollments.Count() != studentSubjects.Count()) return Result<AcademicCardDto>.Failed("Enrollments doesn't match to subjects");


        Dictionary<string,EnrollmentsInCardDto> generated = new Dictionary<string, EnrollmentsInCardDto>();


        int index = 0;
        foreach(var studentSubject in studentSubjects)
        {
            generated.Add(studentSubject.Name, new EnrollmentsInCardDto(studentEnrollments[index].FullGrade, studentEnrollments[index].Mark));
            index++;
        }

        var card = new AcademicCardDto(generated, GPA, studentSubjects.Sum(s => s.Credits));



        return Result<AcademicCardDto>.Success(card);
    }
}
