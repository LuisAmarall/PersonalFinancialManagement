namespace PersonalFinancialManagement.Core.Entities;

/// <summary>
/// Base class for aggregate roots that support soft delete (Delete/Restore)
/// instead of permanent removal. Centralizes the DeletedAt flag and the
/// guard clauses that protect it, so every entity that opts into this
/// behavior gets the exact same rules and exception messages.
/// </summary>
public abstract class SoftDeletableEntity
{
    public DateTime? DeletedAt { get; private set; }

    public bool IsDeleted() => DeletedAt.HasValue;

    public void Delete()
    {
        if (DeletedAt.HasValue)
            throw new InvalidOperationException($"{GetType().Name} is already deleted!");

        DeletedAt = DateTime.UtcNow;
    }

    public void Restore()
    {
        if (!DeletedAt.HasValue)
            throw new InvalidOperationException($"{GetType().Name} is not deleted!");

        DeletedAt = null;
    }
}
