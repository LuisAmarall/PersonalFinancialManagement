namespace PersonalFinancialManagement.Application.Contracts.User.Requests;

public record UserLoginRequest(string Email, string Password);