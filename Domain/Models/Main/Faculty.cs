namespace Domain.Models;

public class Faculty
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UniversityId { get; set; }
    public University University { get; set; }
    public ICollection<Subject> Subjects { get; set; }
    public ICollection<Student> Students { get; set; }
}
