using PersonalFinancialManagement.Core.Entities;
using PersonalFinancialManagement.Core.ValueObjects;

namespace PersonalFinancialManagement.Application.Interfaces.Repositories;

public interface IToPayRepository
{
    void AddToPay(ToPay toPay);
    void UpdateToPay(ToPay toPay);
    Task<IReadOnlyList<ToPay?>> GetAllToPays();
    Task<ToPay?> FindToPayByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ToPay?> FindToPayByOriginalValue(Amount originalValue, CancellationToken cancellationToken = default);
    Task<ToPay?> FindToPayByPaymentDateAsync(DateTime paymentDate, CancellationToken cancellationToken = default);
    Task<ToPay?> FindToPayByDueDateAsync(DateTime dueDate, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}