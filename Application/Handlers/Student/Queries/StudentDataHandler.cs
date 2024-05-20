using Application.Queries;
using AutoMapper;
using Contracts;
using Domain.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Handlers;

public class StudentDataHandler : IRequestHandler<GetStudentDataQuery, Result<StudentDto>>
{
    private readonly IRepositoryManager _repositoryManager;

    public StudentDataHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<Result<StudentDto>> Handle(GetStudentDataQuery request, CancellationToken cancellationToken)
    {
        var user = await _repositoryManager.UserRepository.GetUser(user => user.Id == request.studentId);
        if (user == null) return Result<StudentDto>.Failed("User not Found");
        var student = await _repositoryManager.StudentRepository.GetStudentById(user.Id);
        if (student == null) return Result<StudentDto>.Failed("there is not student on this account");

        string status = student.IsActive ? "active" : "inactive";
        string grant = (student.Grant * 100).ToString() + "%";

        var studentDto = new StudentDto(user.Person.Name + " " + user.Person.Name,
            user.PhoneNumber,
            user.Email,
            student.CurrentSemester,
            status,
            grant);

        return Result<StudentDto>.Success(studentDto);

    }
}
