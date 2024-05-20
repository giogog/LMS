using Domain.Enums;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Dtos;

public record LoginDto(string Username,string Password);
public record LoginResponseDto(string Username, string Token);
public record RegisterDto(string PersonalID, string Email, string Password);
public record AssignRoleDto(string Username, string[] Roles);
public record PaymentDto(decimal Ammount, string PID);
public record StundentEnrollDto();
public record StudentDto(string Fullname, string PhoneNumber, string Email, int CurrentSemester, string Status,string Grant);
public record SubjectDto(string SubjectName, int Credits, int MaxLectures, int MaxSeminars, Semester Semester, string[] gradeTypes);
public record GradeDto(int TeacherId, int StudentId, string GradeType, double Grade);

public record ActivityDto(string activityName, TimeDto time);
public record ScheduleDto(string SubjectName, IEnumerable<ActivityDto> Activities);
public record TimeDto(DayOfWeek DayOfWeek,TimeSpan StartTime,TimeSpan EndTime);
public record LectureDto(int SubjectId, int TeacherId, int LectureCapacity, TimeDto timeDto);
public record SeminarDto(int SubjectId, int TeacherId, int LectureCapacity, TimeDto timeDto);
public record EnrollmentsInCardDto(double FullGrade, char Mark);

public record SubjectsInCardDto(string SubjectName);
public record AcademicCardDto(Dictionary<string, EnrollmentsInCardDto> subjects, double GPA, int FullCredits);

public record ExtraSemesterDto(int CreditsNum,int SubjectsNum,int studentId);

public record FacultyDto(string Name);
public record UniversityDto(string Name, int SemesterPayment,int CreditsToGraduate,int SubjectPayment, IEnumerable<FacultyDto> Faculties);

//public record UpdateUniversityDto(string Name, int SemesterPayment, int CreditsToGraduate, int SubjectPayment);