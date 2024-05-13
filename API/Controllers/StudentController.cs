using Contracts;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IServiceManager _serviceManager;

        public StudentController(IRepositoryManager repositoryManager, IServiceManager serviceManager)
        {
            _repositoryManager = repositoryManager;
            _serviceManager = serviceManager;
        }
        [HttpGet("{studentid}")]
        public async Task<ActionResult<Student>> GetStudents(int studentid)
        {
            var students = await _repositoryManager.StudentRepository.GetStudentById(studentid);

            return Ok(students);

            //var subjects = await _repositoryManager.SubjectRepository.GetAllSubjects();

            //return Ok(subjects);

            //var students = await _serviceManager.SubjectService.GetSubjectsByStudentId(studentid);

            //return Ok(students);


        }

        [HttpGet("{teacherId}/{studentId}")]
        public async Task<ActionResult<StudentEnrollment>> GetEnrollments(int teacherId, int studentId)
        {

            var Lecture = await _repositoryManager.TeacherRepository
                .GetByCondition(t => t.Id == teacherId)
                .SelectMany(t => t.Lectures)
                .SelectMany(l => l.StudentEnrollments)
                .Where(en => en.StudentId == studentId)
                .FirstOrDefaultAsync();


            return Ok("Lecture");

        }
        [HttpPost("{subjectId}")]
        public async Task<ActionResult<Dictionary<string, double>>> AddGrade(int subjectId, [FromBody] GradeDto gradeDto)
        {
            var result = await _serviceManager.GradeService.AddGradeToStudent(subjectId, gradeDto);
            if(!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }
            var Result = await _serviceManager.GradeService.GetGrades(gradeDto.StudentId, subjectId);

            return Ok(Result.Data);

        }
    }
}
