using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using PersonalFinancialManagement.Core.Entities;
using PersonalFinancialManagement.Infrastructure.Security.Jwt;
using PersonalFinancialManagement.Application.Interfaces.Security;


namespace PersonalFinancialManagement.Infrastructure.Security;

public sealed class AccessTokenGenerator : IAccessTokenGenerator
{
    private readonly JwtOptions _jwtOptions;

    public AccessTokenGenerator(JwtOptions options)
    {
        _jwtOptions = options ?? throw new ArgumentNullException(nameof(_jwtOptions));
    }

    public AccessTokenResult GenerateAccessToken(User user)
    {
        var expiresAtUtc = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationInMinutes);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.FullName.IndividualsName),
            new Claim(JwtRegisteredClaimNames.Email, user.EmailAddress.EmailAddress),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var singingKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtOptions.SigningKey));
        
        var signingCredentials = new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expiresAtUtc,
            signingCredentials: signingCredentials);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

        return new AccessTokenResult(accessToken, expiresAtUtc);
    }
}