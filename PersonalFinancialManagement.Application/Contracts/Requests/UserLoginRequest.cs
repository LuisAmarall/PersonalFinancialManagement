namespace PersonalFinancialManagement.Application.Contracts.Requests;

public sealed record UserLoginRequest(string Email, string Password);