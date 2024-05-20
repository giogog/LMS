using Domain.Models;
using MediatR;

namespace Application.Commands;


public record ExtraSemesterRequestCommand(int AmountofCredits, int AmountofSubjects, int StudentId) : IRequest<Result<int>>;

