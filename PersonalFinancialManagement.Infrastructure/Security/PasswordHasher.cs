using PersonalFinancialManagement.Application.Interfaces.Security;

namespace PersonalFinancialManagement.Infrastructure.Security;

public sealed class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}