using Domain.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands;

public record UpdateUniversityCommand(string Name, int SemesterPayment, int CreditsToGraduate, int SubjectPayment):IRequest<Result<string>>;