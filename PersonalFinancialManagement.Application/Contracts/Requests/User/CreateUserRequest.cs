namespace PersonalFinancialManagement.Application.Contracts.Requests.User;

public sealed record CreateUserRequest(string FullName, string Email, string Password);