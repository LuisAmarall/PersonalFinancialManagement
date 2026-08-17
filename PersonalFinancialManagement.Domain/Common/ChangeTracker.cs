namespace PersonalFinancialManagement.Core.Entities;

/// <summary>
/// Centralizes the "did this setter actually receive a different value?"
/// check used by every entity's Change*/Chenge* methods before mutating
/// state. Existed as a private static method copy-pasted into Category,
/// User, ToPay and ToReceive — each copy drifted into its own spelling
/// (HaChenged, HasChenged, HasChanged x2). Consolidated here so there is
/// exactly one implementation and one name to get right.
/// </summary>
public static class ChangeTracker
{
    public static bool HasChanged<T>(T? newValue, T? currentValue)
    {
        ArgumentNullException.ThrowIfNull(newValue);
        return !EqualityComparer<T>.Default.Equals(newValue, currentValue);
    }
}
