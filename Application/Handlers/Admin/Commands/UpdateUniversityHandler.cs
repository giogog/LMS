using Application.Commands;
using Contracts;
using Domain.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Handlers;

public class UpdateUniversityHandler : IRequestHandler<UpdateUniversityCommand, Result<string>>
{
    private readonly IRepositoryManager _repositoryManager;

    public UpdateUniversityHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<Result<string>> Handle(UpdateUniversityCommand request, CancellationToken cancellationToken)
    {
        var university = await _repositoryManager.UniversityRepository.GetUniversity();
        if (university == null)
            return Result<string>.Failed("University data is not set up");
        
        university.CreditsToGraduate = request.CreditsToGraduate;
        university.SubjectPayment = request.SubjectPayment;
        university.SemesterPayment = request.SemesterPayment;
        university.Name = request.Name;

        try
        {
            _repositoryManager.UniversityRepository.UpdateUniversity(university);
            int saveResult = await _repositoryManager.SaveAsync();
            return Result<string>.SuccesfullySaved(saveResult, "");
        }
        catch (Exception ex)
        {
            return Result<string>.Failed(ex.Message);
        }
    }
}
