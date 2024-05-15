using Contracts;
using Domain.Dtos;
using Domain.Models;

namespace Contracts;

public interface IPaymentService
{
    Task<Result<decimal>> PayForSemester(PaymentDto paymentDto);
}
