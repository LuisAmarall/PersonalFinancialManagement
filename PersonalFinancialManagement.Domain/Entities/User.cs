using DomainDesign.ValueObjects;

namespace PersonalFinancialManagement.Core.Entities;

public class User
{
    public Guid Id { get; private set; }

    public Name FullName { get; private set; }
    public Email EmailAddress { get; private set; }
    public Password Password { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime? DeletedAt { get; private set; }
    public bool IsDeleted() => DeletedAt.HasValue;

    private User() { }

    public User(Name fullName, Email emailAddress, Password password)
    {
        ArgumentNullException.ThrowIfNull(fullName);
        ArgumentNullException.ThrowIfNull(emailAddress);
        ArgumentNullException.ThrowIfNull(password);

        Id = Guid.NewGuid();
        FullName = fullName;
        EmailAddress = emailAddress;
        Password = password;
        CreatedAt = DateTime.UtcNow;
    }

    public static User CreateUser(Name fullName, Email emailAddress, Password password)
        => new(fullName, emailAddress, password);

    public void Delete()
    {
        if (DeletedAt.HasValue)
            throw new InvalidOperationException("Transaction is already deleted!");

        DeletedAt = DateTime.UtcNow;
    }

    public void Restore()
    {
        if (!DeletedAt.HasValue)
            throw new InvalidOperationException("Transaction is not deleted!");

        DeletedAt = null;
    }
}