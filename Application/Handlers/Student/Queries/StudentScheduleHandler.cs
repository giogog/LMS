using Application.Queries;
using AutoMapper;
using Contracts;
using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers;

public class StudentScheduleHandler : IRequestHandler<GetStudentScheduleQuery, Result<IEnumerable<ScheduleDto>>>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;
    public StudentScheduleHandler(IRepositoryManager repositoryManager, IServiceManager serviceManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _serviceManager = serviceManager;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<ScheduleDto>>> Handle(GetStudentScheduleQuery request, CancellationToken cancellationToken)
    {
        var activeEnrollmentsByStudent = await _repositoryManager.EnrollmentRepository
            .GetByCondition(en => en.StudentId == request.studentId && en.IsActive)
            .Include(en => en.Lecture)
            .Include(en => en.Seminar)
            .ToArrayAsync();
        var activeSubjectsbyStudent = await _serviceManager.SubjectService.GetActiveSubjectsByStudentId(request.studentId);

        if(activeSubjectsbyStudent.Count() != activeEnrollmentsByStudent.Count()) 
            return Result<IEnumerable<ScheduleDto>>.Failed("Enrollments doesn't match to activeSubjectsbyStudent");

        var schedules = new List<ScheduleDto>();


        int index = 0;
        foreach (var subject in activeSubjectsbyStudent)
        {

            var activities = new List<ActivityDto>();
            var LecturetimeDto = _mapper.Map<TimeDto>(activeEnrollmentsByStudent[index].Lecture.Schedule);
            activities.Add(new ActivityDto("Lecture", LecturetimeDto));
            if (activeEnrollmentsByStudent[index].Seminar != null)
            {
                var SeminartimeDto = _mapper.Map<TimeDto>(activeEnrollmentsByStudent[index].Seminar.Schedule);
                activities.Add(new ActivityDto("Seminar", SeminartimeDto)); 
            }
            schedules.Add(new ScheduleDto(subject.Name,activities));
            index++;
        }

        return Result<IEnumerable<ScheduleDto>>.Success(schedules);
    }
}
