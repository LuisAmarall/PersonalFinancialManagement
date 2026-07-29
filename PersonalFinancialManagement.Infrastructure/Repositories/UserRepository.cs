using DomainDesign.ValueObjects;
using Microsoft.EntityFrameworkCore;
using PersonalFinancialManagement.Application.Interfaces.Repositories;
using PersonalFinancialManagement.Core.Entities;
using PersonalFinancialManagement.Infrastructure.Persistence.Context;

namespace PersonalFinancialManagement.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<User?> FindUserByIdAsync(Guid id)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<User?> FindUserByEmailAsync(Email email)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(_ => _.EmailAddress == email);
    }

    public async Task<User?> FindUserByNameAsync(Name name)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(_ => _.FullName == name);
    }

    public async Task<User> AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        var updatedUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(_ => _.Id == user.Id);

        _context.Entry(updatedUser).CurrentValues.SetValues(user);
        _context.Update(updatedUser);

        return user;
    }

    public async Task InactivationUserAsync(User user)
    {
        user.Delete();
        await UpdateUserAsync(user);
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}