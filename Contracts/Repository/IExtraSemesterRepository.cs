using Domain.Models;

namespace Contracts.Repository;

public interface IExtraSemesterRepository
{
    Task<IEnumerable<SemesterRequest>> GetAllAsync();
    Task<SemesterRequest> GetExtraSemesterByIdAsync(string id);
    Task<SemesterRequest> GetExtraSemesterByStudentIdAsync(int studentId);
    Task AddExtraSemesterAsync(SemesterRequest entity);
    Task UpdateExtraSemesterAsync(string id,SemesterRequest entity);
    Task DeleteExtraSemesterAsync(string id);
}
