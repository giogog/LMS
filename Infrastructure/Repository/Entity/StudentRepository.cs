using Contracts;
using Domain.Models;
using Infrastructure.DataConnection;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository;

public class StudentRepository(DomainDataContext context) : BaseRepository<Student>(context), IStudentRepository
{
    public async Task AddStudent(Student student) => 
        Create(student);

    public async Task DeleteStudent(Student student) => 
        Delete(student);

    public async Task UpdateStudent(Student student) => 
        Update(student);
    public async Task<IEnumerable<Student>> GetAllStudents() => 
        await FindAll().OfType<Student>().Include(s=>s.Enrollments).ToArrayAsync();

    public async Task<Student> GetStudentById(int id) => 
        await FindByCondition(p=>p.Id == id).OfType<Student>()
        .FirstOrDefaultAsync();

    public async Task<IEnumerable<Student>> GetStudentsBySubjectId(int subjectId) => 
        await FindAll().OfType<Student>()
            .SelectMany(l => l.Enrollments)
            .Where(en => en.Lecture.SubjectId == subjectId)
            .Select(en => en.Student)
            .AsNoTracking()
            .ToArrayAsync();

    public async Task<IEnumerable<Student>> GetStudentsBySeminarId(int seminarid) =>
        await FindAll().OfType<Student>()
            .SelectMany(l => l.Enrollments)
            .Where(en => en.SeminarId == seminarid)
            .Select(en => en.Student)
            .AsNoTracking()
            .ToArrayAsync();
    public async Task<IEnumerable<Student>> GetStudentsByLectureId(int leactureid) =>
        await FindAll().OfType<Student>()
            .SelectMany(l => l.Enrollments)
            .Where(en => en.LectureId == leactureid)
            .Select(en => en.Student)
            .AsNoTracking()
            .ToArrayAsync();

    public IQueryable<Student> GetByCondition(Expression<Func<Student, bool>> expression) => FindByCondition(expression);
}
