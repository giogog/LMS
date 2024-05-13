﻿using Contracts;
using Domain.Models;
using Infrastructure.DataConnection;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly DomainDataContext _context;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<IStudentRepository> _studentRepository;
    private readonly Lazy<ITeacherRepository> _teacherRepository;
    private readonly Lazy<ISubjectRepository> _subjectRepository;
    private readonly Lazy<ILectureRepository> _lectureRepository;
    private readonly Lazy<ISeminarRepository> _seminarRepository;
    private readonly Lazy<IEnrollmentRepository> _enrollmentRepository;
    public RepositoryManager(DomainDataContext context,UserManager<User> userManager)
    {
        _context = context;
        _userRepository = new(() => new UserRepository(userManager));
        _studentRepository = new(() => new StudentRepository(context));
        _teacherRepository = new(() => new TeacherRepository(context));
        _subjectRepository = new(() => new SubjectRepository(context));
        _lectureRepository = new(() => new LectureRepository(context));
        _seminarRepository = new(() => new SeminarRepository(context));
        _enrollmentRepository = new(() => new EnrollmentRepository(context));
        
    }
    public IUserRepository UserRepository => _userRepository.Value;
    public IStudentRepository StudentRepository => _studentRepository.Value;
    public ISubjectRepository SubjectRepository => _subjectRepository.Value;
    public ITeacherRepository TeacherRepository => _teacherRepository.Value;
    public ISeminarRepository SeminarRepository => _seminarRepository.Value;
    public ILectureRepository LectureRepository => _lectureRepository.Value;
    public IEnrollmentRepository EnrollmentRepository => _enrollmentRepository.Value;
    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
}
