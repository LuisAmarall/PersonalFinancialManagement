namespace PersonalFinancialManagement.Application.Interfaces.Security;

public sealed record AccessTokenResult(string AccessToken, DateTime ExpiresAtUtc);