using Domain.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Queries;

public record GetStudentCardQuery(int studentId):IRequest<Result<AcademicCardDto>>;
public record GetStudentSchedule(int studentId):IRequest<Result<ScheduleDto>>;
public record GetStudentData(int studentId):IRequest<Result<StudentDto>>;
