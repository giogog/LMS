using Application.Commands;
using Application.Queries;
using AutoMapper;
using Contracts;
using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class StudentController(IServiceManager serviceManager, IMediator mediator) : ApiController(serviceManager, mediator)
    {
        [HttpGet("data/{studentId}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int studentId)
        {
            var result = await mediator.Send(new GetStudentDataQuery(studentId));
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet("card/{studentId}")]
        public async Task<ActionResult<AcademicCardDto>> GetStudentAcademicCard(int studentId)
        {
            var result = await mediator.Send(new GetStudentCardQuery(studentId));
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }

        [HttpGet("schedule/{studentId}")]
        public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetStudentSchedule(int studentId)
        {
            var result = await mediator.Send(new GetStudentScheduleQuery(studentId));
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }

        [HttpGet("extra-semester")]
        public async Task<ActionResult<Result<int>>> RequestExtraSemester([FromBody] ExtraSemesterDto extraSemesterDto)
        {
            var result = await mediator.Send(new ExtraSemesterRequestCommand(extraSemesterDto.CreditsNum,extraSemesterDto.SubjectsNum,extraSemesterDto.studentId));
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok($"Subjects requested: {result.Data}");
        }

    }
}
