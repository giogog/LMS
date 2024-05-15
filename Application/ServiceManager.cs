using Application.Services;
using AutoMapper;
using Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Application;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthorizationService> _authorizationService;
    private readonly Lazy<IEmailService> _emailService;
    private readonly Lazy<ISubjectService> _subjectService;
    private readonly Lazy<IGradeService> _gradeService;
    private readonly Lazy<ISeminarService> _seminarService;
    private readonly Lazy<ILectureService> _lectureService;
    private readonly Lazy<IAcademicService> _academicService;
    public ServiceManager(
        IRepositoryManager repositoryManager,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        ITokenGenerator tokenGenerator,
        IEmailSender emailSender,
        IMapper mapper
        )
    {
        _authorizationService = new Lazy<IAuthorizationService>(() => new AuthorizationService(roleManager, tokenGenerator, repositoryManager));
        _emailService = new Lazy<IEmailService>(() => new EmailService(userManager, emailSender, repositoryManager, tokenGenerator));
        _subjectService = new Lazy<ISubjectService>(() => new SubjectService(repositoryManager,mapper));
        _gradeService = new Lazy<IGradeService>(() => new GradeService(repositoryManager));
        _seminarService = new Lazy<ISeminarService>(() => new SeminarService(repositoryManager, mapper));
        _lectureService = new Lazy<ILectureService>(() => new LectureService(repositoryManager,mapper));
        _academicService = new Lazy<IAcademicService>(() => new AcademicService(repositoryManager));
    }
    public IAuthorizationService AuthorizationService => _authorizationService.Value;
    public IEmailService EmailService => _emailService.Value;
    public ISubjectService SubjectService => _subjectService.Value;
    public IGradeService GradeService => _gradeService.Value;
    public ILectureService LectureService => _lectureService.Value;
    public ISeminarService SeminarService => _seminarService.Value;
    public IAcademicService AcademicService => _academicService.Value;
}
