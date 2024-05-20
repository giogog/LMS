using Contracts.Repository;

namespace Contracts;

public interface IRepositoryManager
{
    IUserRepository UserRepository { get; }
    IStudentRepository StudentRepository { get; }
    ITeacherRepository TeacherRepository { get; }
    ISubjectRepository SubjectRepository { get; }
    ILectureRepository LectureRepository { get; }
    ISeminarRepository SeminarRepository { get; }   
    IEnrollmentRepository EnrollmentRepository { get; }
    IExtraSemesterRepository ExtraSemesterRepository { get; }
    IUniversityRepository UniversityRepository { get; }
    Task<int> SaveAsync();
}
