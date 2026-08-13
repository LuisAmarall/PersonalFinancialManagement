namespace PersonalFinancialManagement.Application.Contracts.Requests;

public sealed record CreateUserRequest(string FullName, string Email, string Password);