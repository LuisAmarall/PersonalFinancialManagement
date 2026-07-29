using DomainDesign.ValueObjects;
using PersonalFinancialManagement.Core.Entities;

namespace PersonalFinancialManagement.Application.Interfaces.Repositories;

public interface IUserRepository
{
    void AddUser(User user); 
    void UpdateUserAsync(User user);
    Task<User?> FindUserByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    Task<User?> FindUserByNameAsync(Name name, CancellationToken cancellationToken = default(CancellationToken));
    Task<User?> FindUserByEmailAsync(Email email, CancellationToken cancellationToken = default(CancellationToken));
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}