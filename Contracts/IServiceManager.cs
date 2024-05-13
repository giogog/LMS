namespace Contracts;

public interface IServiceManager
{
    IEmailService EmailService { get; }
    IAuthorizationService AuthorizationService { get; }
    ISubjectService SubjectService { get; }
    IGradeService GradeService { get; }
    ILectureService LectureService { get; }
    ISeminarService SeminarService { get; }
}
