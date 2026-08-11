namespace PersonalFinancialManagement.Application.Contracts.User.Responses;

public sealed record CreateUserResponse(Guid Id, string FullName, string Email, DateTime CreateAt);