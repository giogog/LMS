using Domain.Models;
using System.Linq.Expressions;

namespace Contracts.Repository;

public interface IUniversityRepository
{
    Task AddUniversity(University university);
    Task DeleteUniversity(University university);
    Task UpdateUniversity(University university);
    Task<University> GetUniversity();
}
