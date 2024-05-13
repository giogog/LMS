namespace Contracts;

public interface IResult<T>
{
    string Message { get; }
    bool IsSuccess { get; }
    T Data { get; }
    IResult<T> SuccesfullySaved();

}
