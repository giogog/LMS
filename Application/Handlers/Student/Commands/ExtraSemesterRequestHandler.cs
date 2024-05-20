using Application.Commands;
using Contracts;
using Domain.Models;
using MediatR;

namespace Application.Handlers;

public class ExtraSemesterRequestHandler : IRequestHandler<ExtraSemesterRequestCommand, Result<int>>
{
    private readonly IRepositoryManager _repositoryManager;

    public ExtraSemesterRequestHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<Result<int>> Handle(ExtraSemesterRequestCommand request, CancellationToken cancellationToken)
    {

        var semesterRequest = await _repositoryManager.ExtraSemesterRepository.GetExtraSemesterByStudentIdAsync(request.StudentId);
        if (semesterRequest != null)
            return Result<int>.Failed("Request is already Sent");
        var semester = new SemesterRequest
        {
            Credits = request.AmountofCredits,
            SubjectNumber = request.AmountofSubjects,
            StudentId = request.StudentId
        };

        await _repositoryManager.ExtraSemesterRepository.AddExtraSemesterAsync(semester);
        return Result<int>.Success(request.AmountofSubjects);
    }
}
