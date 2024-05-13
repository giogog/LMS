using Domain.Dtos;
using MediatR;

namespace Application.Queries;

public record GetStudentCardQuery(int studentId):IRequest<AcademicCardDto>;
public record GetStudentSchedule(int studentId):IRequest<ScheduleDto>;
public record GetStudentData(int studentId):IRequest<StudentDto>;
