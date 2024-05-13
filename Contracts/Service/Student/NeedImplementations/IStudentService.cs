using Domain.Dtos;

namespace Contracts;

public interface IStudentService
{
    Task<AcademicCardDto> GetAcademicCardDto(int studentid);
    Task<IEnumerable<ScheduleDto>> GetSchedule(int studentid);
    Task<StudentDto> GetStudentData(int studentid);

}
