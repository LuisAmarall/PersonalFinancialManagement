using Microsoft.EntityFrameworkCore;
using PersonalFinancialManagement.Core.Entities;
using PersonalFinancialManagement.Core.ValueObjects;
using PersonalFinancialManagement.Infrastructure.Persistence.Context;
using PersonalFinancialManagement.Application.Interfaces.Repositories;

namespace PersonalFinancialManagement.Infrastructure.Repositories;

public class ToReceiveRepository : IToReceiveRepository
{
    private readonly ApplicationContext _context;

    public ToReceiveRepository(ApplicationContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void AddToReceive(ToReceive toReceive)
    {
        _context.ToReceive.Add(toReceive);
    }

    public void UpdateToReceive(ToReceive toReceive)
    {
        var existingToReceive = _context.ToReceive.AsNoTracking().FirstOrDefault(_ => _.Id == toReceive.Id);

        _context.Entry(existingToReceive).CurrentValues.SetValues(toReceive);
        _context.Update(existingToReceive);
    }
    public async Task<IReadOnlyList<ToReceive?>> GetAllToReceives()
    {
        return await _context.ToReceive.AsNoTracking().ToListAsync();
    }

    public async Task<ToReceive?> FindToReceiveByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.ToReceive.AsNoTracking().FirstOrDefaultAsync(_ => _.Id == id, cancellationToken);
    }

    public async Task<ToReceive?> FindToReceiveByOriginalValueAsync(Amount originalValue, CancellationToken cancellationToken = default)
    {
        return await _context.ToReceive.AsNoTracking().FirstOrDefaultAsync(_ => _.OriginalValue == originalValue, cancellationToken);
    }

    public async Task<ToReceive?> FindToReceiveByDateReceiptDateReceiptAsync(DateTime referenceDate, CancellationToken cancellationToken = default)
    {
        return await _context.ToReceive.AsNoTracking().FirstOrDefaultAsync(_ => _.DateReceipt.Equals(referenceDate), cancellationToken);
    }

    public async Task<ToReceive?> FindToReceiveByDueDateAsync(DateTime dueDate, CancellationToken cancellationToken = default)
    {
        return await _context.ToReceive.AsNoTracking().FirstOrDefaultAsync(_ => _.DueDate.Equals(dueDate), cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}