namespace PersonalFinancialManagement.Application.Contracts.User.Requests;

public sealed record UserLoginRequest(string Email, string Password);