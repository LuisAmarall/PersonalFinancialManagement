using Microsoft.VisualBasic;
using PersonalFinancialManagement.Core.Entities;
using PersonalFinancialManagement.Core.ValueObjects;

namespace PersonalFinancialManagement.Application.Interfaces.Repositories;

public interface IToPayRepository
{
    void AddToPay(ToPay toPay);
    void UpdateToPay(ToPay toPay);
    Task<IReadOnlyList<ToPay?>> GetAllToPays();
    Task<ToPay?> FindToPayByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    Task<ToPay?> GetToPayByOriginalValue(Amount originalValue, CancellationToken cancellationToken = default(CancellationToken));
    Task<ToPay?> FindToPayByPaymentDateAsync(DateTime paymentDate, CancellationToken cancellationToken = default(CancellationToken));
    Task<ToPay?> FindToPayByDueDateAsync(DateTime dueDate, CancellationToken cancellationToken = default(CancellationToken));
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}