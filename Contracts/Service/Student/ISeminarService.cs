using Domain.Dtos;
using Domain.Models;

namespace Contracts;

public interface ISeminarService
{
    Task<Result<SeminarDto>> RegisterSeminar(SeminarDto seminar);
}
