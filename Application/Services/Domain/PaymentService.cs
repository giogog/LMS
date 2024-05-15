using AutoMapper;
using Contracts;
using Domain.Constants;
using Domain.Dtos;
using Domain.Models;

namespace Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IRepositoryManager _repositoryManager;


    public PaymentService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
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


}
