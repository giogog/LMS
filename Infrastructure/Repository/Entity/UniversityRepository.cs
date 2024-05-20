using Contracts.Repository;
using Domain.Models;
using Infrastructure.DataConnection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class UniversityRepository(DomainDataContext context) : BaseRepository<University>(context), IUniversityRepository
{
    public async Task AddUniversity(University university) => Create(university);

    public async Task DeleteUniversity(University university) => Delete(university);

    public async Task<University> GetUniversity() => FindAll().Include(u => u.Faculties).FirstOrDefault();

    public async Task UpdateUniversity(University university) => Update(university);
}
