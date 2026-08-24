using PersonalFinancialManagement.Core.Entities;
using PersonalFinancialManagement.Core.ValueObjects;

namespace PersonalFinancialManagement.Application.Interfaces.Repositories;

public interface IToReceiveRepository
{
    void AddToReceive(ToReceive toReceive);
    void UpdateToReceive(ToReceive toReceive);
    Task<IReadOnlyList<ToReceive?>> GetAllToReceives();
    Task<ToReceive?> FindToReceiveByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ToReceive?> FindToReceiveByOriginalValueAsync(Amount originalValue, CancellationToken cancellationToken = default);
    Task<ToReceive?> FindToReceiveByDateReceiptDateReceiptAsync(DateTime referenceDate, CancellationToken cancellationToken = default);
    Task<ToReceive?> FindToReceiveByDueDateAsync(DateTime dueDate, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}