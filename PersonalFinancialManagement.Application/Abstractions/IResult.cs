namespace PersonalFinancialManagement.Application.Abstractions;

public interface IResult
{
    public bool IsSuccess { get; }
    public IReadOnlyList<Error> Errors { get; }
}