namespace Domain.Models;

public class Teacher:Person
{
    public ICollection<Lecture> Lectures { get; set; }
    public ICollection<Seminar> Seminars { get; set; }

}
