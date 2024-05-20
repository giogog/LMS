using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models;

public class SemesterRequest
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("SubjectNumber")]
    public int SubjectNumber { get; set; }
    [BsonElement("Credits")]
    public int Credits { get; set; }
    public int StudentId { get; set; }
}
