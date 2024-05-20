using Contracts.Repository;
using Domain.Models;
using MongoDB.Driver;
using System.Collections;

namespace Infrastructure.Repository;

public class ExtraSemesterRepository : IExtraSemesterRepository
{
    private readonly MongoDbContext _context;
    public ExtraSemesterRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task AddExtraSemesterAsync(SemesterRequest entity) => 
        await _context.SemesterRequests.InsertOneAsync(entity);

    public async Task UpdateExtraSemesterAsync(string id, SemesterRequest entity) => 
        await _context.SemesterRequests.ReplaceOneAsync(e => e.Id == id, entity);
    public async Task DeleteExtraSemesterAsync(string id) =>
        await _context.SemesterRequests.DeleteOneAsync(e => e.Id == id);
    public async Task<IEnumerable<SemesterRequest>> GetAllAsync() =>
        await _context.SemesterRequests.Find(_ => true).ToListAsync();

    public async Task<SemesterRequest> GetExtraSemesterByIdAsync(string id) =>
        await _context.SemesterRequests.Find(ex => ex.Id == id)
        .FirstOrDefaultAsync();

    public async Task<SemesterRequest> GetExtraSemesterByStudentIdAsync(int studentId) =>
        await _context.SemesterRequests.Find(ex => ex.StudentId == studentId)
        .FirstOrDefaultAsync();




}
