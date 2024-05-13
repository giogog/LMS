using Domain.Dtos;
using Domain.Models;

namespace Contracts;

public interface ILectureService
{
    Task<Result<LectureDto>> RegisterLecture(LectureDto lectureDto);
}
