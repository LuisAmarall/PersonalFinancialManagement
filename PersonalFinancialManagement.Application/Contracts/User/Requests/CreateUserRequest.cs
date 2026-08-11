namespace PersonalFinancialManagement.Application.Contracts.User.Requests;

public sealed record CreateUserRequest(string FullName, string Email, string Password);