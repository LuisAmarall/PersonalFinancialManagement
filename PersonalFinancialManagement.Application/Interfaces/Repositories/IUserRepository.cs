using DomainDesign.ValueObjects;
using PersonalFinancialManagement.Core.Entities;

namespace PersonalFinancialManagement.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> AddUserAsync(User user);
    Task<User?> FindUserByIdAsync(Guid id);
    Task<User?> FindUserByNameAsync(Name name);
    Task<User?> FindUserByEmailAsync(Email email);
    Task<User> UpdateUserAsync(User user);
    Task InactivationUserAsync(User user);
    Task SaveChangesAsync();
}