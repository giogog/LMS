using Domain.Dtos;
using Domain.Models;

namespace Contracts;

public interface IGradeService
{
    Task<Result<GradeDto>> AddGradeToStudent(int SubjectId,GradeDto gradeDto);
    Task<Result<Dictionary<string, double>>> GetGrades(int studentId, int subjectId);

}
