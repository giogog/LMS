using Domain.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Queries;

public record GetUnivesityDataQuery() : IRequest<Result<UniversityDto>>;
//public record GetUnassignedUsers() : 