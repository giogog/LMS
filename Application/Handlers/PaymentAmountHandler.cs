using Application.Queries;
using AutoMapper;
using Contracts;
using Domain.Constants;
using Domain.Models;
using MediatR;

namespace Application.Handlers;

public class PaymentAmountHandler : IRequestHandler<GetPaymentAmmountQueries, Result<decimal>>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IServiceManager _serviceManager;

    public PaymentAmountHandler(IRepositoryManager repositoryManager,IServiceManager serviceManager)
    {
        _repositoryManager = repositoryManager;
        _serviceManager = serviceManager;

    }
    public async Task<Result<decimal>> Handle(GetPaymentAmmountQueries request, CancellationToken cancellationToken)
    {
        var student = await _repositoryManager.StudentRepository.GetStudentById(request.studentId);

        if (student == null) return Result<decimal>.Failed("Student Not Found");
        double grant = University.SemesterPayment * student.Grant;
        double payAmount = 0;
        if (student.CurrentSemester > 8 && student.CurrentSemester < 11)
        {
            var activeSubjects = await _serviceManager.SubjectService.GetActiveSubjectsByStudentId(request.studentId);
            if (activeSubjects != null) payAmount = University.SubjectPayment * activeSubjects.Count();
        }
        else
        {
            payAmount = University.SemesterPayment - grant;
        }


        return Result<decimal>.Success(decimal.Parse(payAmount.ToString()));

    }
}
