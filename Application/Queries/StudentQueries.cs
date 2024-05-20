using Domain.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Queries;

public record GetStudentCardQuery(int studentId):IRequest<Result<AcademicCardDto>>;
public record GetStudentScheduleQuery(int studentId):IRequest<Result<IEnumerable<ScheduleDto>>>;
public record GetStudentDataQuery(int studentId):IRequest<Result<StudentDto>>;
