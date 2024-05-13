using MediatR;
using System.Collections.Generic;
namespace Application.Commands;
public class CreateStudentCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public int UserId { get; set; }
    public double GPA { get; set; }
    public int AllCredits { get; set; }
    public decimal SemesterPay { get; set; }
    public int YearlyAvailableCredits { get; set; }

    // Additional properties or methods as needed
}