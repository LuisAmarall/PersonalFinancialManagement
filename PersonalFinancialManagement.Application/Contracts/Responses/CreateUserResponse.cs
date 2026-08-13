namespace PersonalFinancialManagement.Application.Contracts.Responses;

public sealed record CreateUserResponse(Guid Id, string FullName, string Email, DateTime CreateAt);