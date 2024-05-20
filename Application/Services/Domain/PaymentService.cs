using AutoMapper;
using Contracts;
using Domain.Dtos;
using Domain.Models;
using Domain.Models;
using MediatR;

namespace Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IRepositoryManager _repositoryManager;


    public PaymentService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<Result<decimal>> CalculatePaymentAmount(int studentId)
    {
        var student = await _repositoryManager.StudentRepository.GetStudentById(studentId);
        var university = await _repositoryManager.UniversityRepository.GetUniversity();
        if (student == null) return Result<decimal>.Failed("Student Not Found");
        double grant = university.SemesterPayment * student.Grant;
        double payAmount = 0;
        //if (student.CurrentSemester > 8 && student.CurrentSemester < 11)
        //{
        //    if(student.YearlyAvailableCredits>0) payAmount = student.YearlyAvailableCredits/University.


        //}



        return Result<decimal>.Success(decimal.Parse(payAmount.ToString()));
    }

    public async Task<Result<decimal>> PayForSemester(PaymentDto paymentDto)
    {
        var User = await _repositoryManager.UserRepository.GetUser(u => u.UserName == paymentDto.PID);

        var student = await _repositoryManager.StudentRepository.GetStudentById(User.Id);

        if (student == null) return Result<decimal>.Failed("Student wasn't Found");

        student.Balance += paymentDto.Ammount;

        try
        {
            _repositoryManager.StudentRepository.UpdateStudent(student);
            int saveResult = await _repositoryManager.SaveAsync();
            return Result<decimal>.SuccesfullySaved(saveResult,student.Balance);
        }catch (Exception ex)
        {
            return Result<decimal>.Failed(ex.Message); 
        }
    }

    public async Task<Result<decimal>> SetStudentStatus(int studentid, decimal calculatedPayment)
    {
        var student = await _repositoryManager.StudentRepository.GetStudentById(studentid);
        if (student == null) return Result<decimal>.Failed("Student wasn't Found");

        if(student.Balance < calculatedPayment)
        {
            student.IsActive = false;
            return Result<decimal>.Success(student.Balance);
        }

        student.IsActive = true;
        return Result<decimal>.Success(student.Balance);

    }
}
