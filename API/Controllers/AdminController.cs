using Application.Commands;
using Application.Queries;
using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class AdminController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet("University/data")]
    public async Task<ActionResult<Result<UniversityDto>>> GetUniversity()
    {
        var result = await mediator.Send(new GetUnivesityDataQuery());
        if(!result.IsSuccess)
            return NotFound(result.Message);
        return Ok(result.Data);

    }

    [HttpPut("University/update")]
    public async Task<ActionResult<string>> UpdateUniversityData([FromBody] UpdateUniversityCommand updateUniversityCommand)
    {
        var result = await mediator.Send(updateUniversityCommand);
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        return Ok("Updated Succesfully");

    }
}
