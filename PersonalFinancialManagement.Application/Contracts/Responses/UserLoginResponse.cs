namespace PersonalFinancialManagement.Application.Contracts.Responses;

public sealed record UserLoginResponse(Guid Id, string Email, string Token);