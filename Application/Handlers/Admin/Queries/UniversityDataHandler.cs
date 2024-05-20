using Application.Queries;
using AutoMapper;
using Contracts;
using Domain.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Handlers;

public class UniversityDataHandler : IRequestHandler<GetUnivesityDataQuery, Result<UniversityDto>>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public UniversityDataHandler(IRepositoryManager repositoryManager,IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    public async Task<Result<UniversityDto>> Handle(GetUnivesityDataQuery request, CancellationToken cancellationToken)
    {
        var university = await _repositoryManager.UniversityRepository.GetUniversity();
        if (university == null)
            return Result<UniversityDto>.Failed("University is not set up");

        var universityDto = _mapper.Map<UniversityDto>(university);

        return Result<UniversityDto>.Success(universityDto);
    }
}
