namespace PersonalFinancialManagement.Application.Contracts.User.Responses;

public sealed record UserLoginResponse(Guid Id, string Email, string Token);