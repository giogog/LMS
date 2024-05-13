using AutoMapper;
using Contracts;
using Domain.Dtos;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class SeminarService : ISeminarService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public SeminarService(IRepositoryManager repositoryManager,IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    public async Task<Result<SeminarDto>> RegisterSeminar(SeminarDto seminarDto)
    {
        var subject = await _repositoryManager.SubjectRepository
            .GetByCondition(s => s.Id == seminarDto.SubjectId)
            .Include(s => s.Seminars)
            .FirstOrDefaultAsync();
        if (subject.Lectures.Count >= subject.MaxSeminars)
            return Result<SeminarDto>.Failed("Can't Add Another Seminar");

        var seminar = _mapper.Map<Lecture>(seminarDto);

        try
        {
            _repositoryManager.LectureRepository.AddLecture(seminar);
            var saveResult = await _repositoryManager.SaveAsync();
            return Result<SeminarDto>.SuccesfullySaved(saveResult, seminarDto);
        }
        catch (Exception ex)
        {
            return Result<SeminarDto>.Failed("An error occurred while saving the seminar.");
        }
    }
}
