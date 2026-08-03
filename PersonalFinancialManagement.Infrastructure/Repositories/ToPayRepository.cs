using Microsoft.EntityFrameworkCore;
using PersonalFinancialManagement.Core.Entities;
using PersonalFinancialManagement.Core.ValueObjects;
using PersonalFinancialManagement.Infrastructure.Persistence.Context;
using PersonalFinancialManagement.Application.Interfaces.Repositories;

namespace PersonalFinancialManagement.Infrastructure.Repositories;

public class ToPayRepository : IToPayRepository
{
    private readonly ApplicationContext _context;

    public ToPayRepository(ApplicationContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void AddToPay(ToPay toPay)
    {
        _context.ToPay.Add(toPay);
    }

    public void UpdateToPay(ToPay toPay)
    {
        var existingToPay = _context.ToPay.AsNoTracking().FirstOrDefault(_ => _.Id == toPay.Id);

        _context.Entry(existingToPay).CurrentValues.SetValues(toPay);
        _context.Update(existingToPay);
    }

    public async Task<IReadOnlyList<ToPay?>> GetAllToPays()
    {
        return await _context.ToPay.AsNoTracking().ToListAsync();
    }

    public async Task<ToPay?> FindToPayByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.ToPay.AsNoTracking().FirstOrDefaultAsync(_ => _.Id == id, cancellationToken);
    }

    public async Task<ToPay?> GetToPayByOriginalValue(Amount originalValue, CancellationToken cancellationToken = default)
    {
        return await _context.ToPay.AsNoTracking().FirstOrDefaultAsync(_ => _.OriginalValue == originalValue, cancellationToken);
    }

    public async Task<ToPay?> FindToPayByPaymentDateAsync(DateTime paymentDate, CancellationToken cancellationToken = default)
    {
        return await _context.ToPay.AsNoTracking().FirstOrDefaultAsync(_ => _.PaymentDate.Equals(paymentDate), cancellationToken);
    }

    public async Task<ToPay?> FindToPayByDueDateAsync(DateTime dueDate, CancellationToken cancellationToken = default)
    {
        return await _context.ToPay.AsNoTracking().FirstOrDefaultAsync(_ => _.DueDate.Equals(dueDate), cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}