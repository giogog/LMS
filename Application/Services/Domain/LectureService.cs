using AutoMapper;
using Contracts;
using Domain.Dtos;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class LectureService : ILectureService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    public LectureService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<Result<LectureDto>> RegisterLecture(LectureDto lectureDto)
    {
        var subject = await _repositoryManager.SubjectRepository
            .GetByCondition(s => s.Id == lectureDto.SubjectId)
            .Include(s => s.Lectures)
            .FirstOrDefaultAsync();
        if (subject.Lectures.Count >= subject.MaxLectures)
            return Result<LectureDto>.Failed("Can't Add Another Lecture");

        var lecture = _mapper.Map<Lecture>(lectureDto);

        try
        {
            _repositoryManager.LectureRepository.AddLecture(lecture);
            var saveResult = await _repositoryManager.SaveAsync();
            return Result<LectureDto>.SuccesfullySaved(saveResult, lectureDto);
        }
        catch (Exception ex)
        {
            return Result<LectureDto>.Failed("An error occurred while saving the lecture.");
        }

    }
}
