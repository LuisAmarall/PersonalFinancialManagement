using PersonalFinancialManagement.Core.Entities;

namespace PersonalFinancialManagement.Application.Interfaces.Security;

public interface IAccessTokenGenerator 
{ 
    AccessTokenResult GenerateAccessToken(User user); 
}