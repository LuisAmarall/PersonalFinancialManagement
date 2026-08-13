namespace PersonalFinancialManagement.Application.Contracts.Responses.User;

public sealed record CreateUserResponse(Guid Id, string FullName, string Email, DateTime CreateAt);