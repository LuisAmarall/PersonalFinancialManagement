namespace PersonalFinancialManagement.Application.Contracts.User.Responses;

public record UserLoginResponse(Guid Id, string Email, string Token);