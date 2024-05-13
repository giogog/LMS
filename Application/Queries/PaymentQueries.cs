using Domain.Models;
using MediatR;

namespace Application.Queries;

public record GetPaymentAmmountQueries(int studentId):IRequest<Result<decimal>>;
