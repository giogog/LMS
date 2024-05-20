using Contracts;
using Domain.Dtos;
using Domain.Models;

namespace Contracts;

public interface IPaymentService
{
    Task<Result<decimal>> PayForSemester(PaymentDto paymentDto);
    Task<Result<decimal>> SetStudentStatus(int studentid, decimal calculatedPayment);
    Task<Result<decimal>> CalculatePaymentAmount(int studentId);
}
