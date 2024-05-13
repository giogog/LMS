using Domain.Enums;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Dtos;

public record LoginDto(string Username,string Password);
public record LoginResponseDto(string Username, string Token);

//public record RegisterDto(string Name, string Surname, string Username, string Email, string Password);

public record RegisterDto(string Username, string Email, string Password);
public record AssignRoleDto(string Username, string[] Roles);
public record PaymentDto(decimal Ammount, string PID);
public record StundentEnrollDto();
public record StudentDto();
public record SubjectDto(string SubjectName, int Credits, int MaxLectures, int MaxSeminars, Semester Semester, string[] gradeTypes);
public record GradeDto(int TeacherId, int StudentId, string GradeType, double Grade);
public record ScheduleDto();
public record TimeDto(DayOfWeek DayOfWeek,TimeSpan StartTime,TimeSpan EndTime);
public record LectureDto(int SubjectId, int TeacherId, int LectureCapacity, TimeDto timeDto);
public record SeminarDto(int SubjectId, int TeacherId, int LectureCapacity, TimeDto timeDto);
public record AcademicCardDto(IEnumerable<SubjectDto> subjects, double GPA, int FullCredits);