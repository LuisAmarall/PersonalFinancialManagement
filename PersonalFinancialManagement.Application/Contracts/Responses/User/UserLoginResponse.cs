namespace PersonalFinancialManagement.Application.Contracts.Responses.User;

public sealed record UserLoginResponse(Guid Id, string Email, string Token);