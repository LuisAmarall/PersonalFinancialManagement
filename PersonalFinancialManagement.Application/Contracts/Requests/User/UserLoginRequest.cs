namespace PersonalFinancialManagement.Application.Contracts.Requests.User;

public sealed record UserLoginRequest(string Email, string Password);