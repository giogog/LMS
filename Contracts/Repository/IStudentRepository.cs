using Domain.Models;
using System.Linq.Expressions;

namespace Contracts;

public interface IStudentRepository
{
    Task AddStudent(Student student);
    Task UpdateStudent(Student student);
    Task DeleteStudent(Student student);
    Task<Student> GetStudentById(int id);
    Task<IEnumerable<Student>> GetAllStudents();
    Task<IEnumerable<Student>> GetStudentsBySubjectId(int subjectId);
    Task<IEnumerable<Student>> GetStudentsByLectureId(int leactureid);
    Task<IEnumerable<Student>> GetStudentsBySeminarId(int seminarid);
    IQueryable<Student> GetByCondition(Expression<Func<Student, bool>> expression);


}
