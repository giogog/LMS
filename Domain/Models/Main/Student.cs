using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Student:Person
{
    //[Range(0, 4)]
    //public double GPA { get; set; }
    //public double GPA
    //{
    //    get
    //    {
    //        var validEnrollments = Enrollments.Where(e => e.IsPassed).ToList();
    //        if (validEnrollments.Count == 0)
    //        {
    //            return 0; 
    //        }
    //        return validEnrollments.Sum(s => s.FullGrade) / validEnrollments.Count;
    //    }
    //}
    [Range(0, 400)]
    public int TotalCredits { get; set; } = 0;

    [Range(0, 50)]
    public int CurrentSemester { get; set; } = 0;

    [Column(TypeName = "decimal(18, 2)")]
    [Range(0.01, 10000.00, ErrorMessage = "Price must be between $0.01 and $10,000.00")]
    public decimal? SemesterPay {  get; set; }
    [Range(0, 70)]
    public int YearlyAvailableCredits { get; set; }

    [Range(0,1)]
    public double Grant {  get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    [Range(0.01, 10000.00, ErrorMessage = "Price must be between $0.01 and $10,000.00")]
    public decimal Balance { get; set; } = 0;
    public bool IsActive { get; set; } = false;
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public ICollection<StudentEnrollment> Enrollments { get; set; }
}
