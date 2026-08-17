using DomainDesign.ValueObjects;

namespace PersonalFinancialManagement.Core.Entities;

public class User : SoftDeletableEntity
{
    public Guid Id { get; private set; }

    public Name FullName { get; private set; }
    public Email EmailAddress { get; private set; }
    public Password Password { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.Now;

    private User() { }

    private static User Create(Name fullName, Email emailAddress, Password password)
    {
        AttributeValidation(fullName, emailAddress, password);
        return new User
        {
            Id = Guid.NewGuid(),
            FullName = fullName,
            EmailAddress = emailAddress,
            Password = password,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static User CreateUser(Name fullName, Email emailAddress, Password password)
        => Create(fullName, emailAddress, password);

    private static void AttributeValidation(Name fullName, Email emailAddress, Password password)
    {
        ArgumentNullException.ThrowIfNull(fullName, nameof(fullName));
        ArgumentNullException.ThrowIfNull(emailAddress, nameof(emailAddress));
        ArgumentNullException.ThrowIfNull(password, nameof(password));
    }

    public void ChengeFullName(Name fullName)
    {
        if (ChangeTracker.HasChanged(fullName, FullName)) { FullName = fullName; }
    }

    public void ChengeEmailAddress(Email emailAddress)
    {
        if (ChangeTracker.HasChanged(emailAddress, EmailAddress)) { EmailAddress = emailAddress; }
    }

    public void ChengePassword(Password password)
    {
        if (ChangeTracker.HasChanged(password, Password)) { Password = password; }
    }
}