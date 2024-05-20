using Domain.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Infrastructure;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoClient client, string databaseName)
    {
        _database = client.GetDatabase(databaseName);
    }

    // Access collections like properties
    public IMongoCollection<SemesterRequest> SemesterRequests => _database.GetCollection<SemesterRequest>("SemesterRequests");
}
