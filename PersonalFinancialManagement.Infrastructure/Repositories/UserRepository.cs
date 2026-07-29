using DomainDesign.ValueObjects;
using Microsoft.EntityFrameworkCore;
using PersonalFinancialManagement.Core.Entities;
using PersonalFinancialManagement.Infrastructure.Persistence.Context;
using PersonalFinancialManagement.Application.Interfaces.Repositories;

namespace PersonalFinancialManagement.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
    }
    public void UpdateUserAsync(User user)
    {
        var updatedUser = _context.Users.AsNoTracking().FirstOrDefaultAsync(_ => _.Id == user.Id);

        _context.Entry(updatedUser).CurrentValues.SetValues(user);
        _context.Update(updatedUser);
    }

    public async Task<User?> FindUserByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(_ => _.Id == id, cancellationToken);
    }

    public async Task<User?> FindUserByEmailAsync(Email email, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(_ => _.EmailAddress == email, cancellationToken);
    }

    public async Task<User?> FindUserByNameAsync(Name name, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(_ => _.FullName == name, cancellationToken);
    }

    Task IUserRepository.SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}