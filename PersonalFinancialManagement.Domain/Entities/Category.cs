using DomainDesign.Exceptions;
using PersonalFinancialManagement.Core.ValueObjects;

namespace PersonalFinancialManagement.Core.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }

    public AdditionalInformation Description { get; private set; }
    public AdditionalInformation Observation { get; private set; }

    public TransactionDate CreatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public bool IsDeleted() => DeletedAt.HasValue;

    private Category() { }

    public static Category CreateCategory(Guid userId, AdditionalInformation description, AdditionalInformation observation, TransactionDate createdAt)
        => Create(userId, description, observation, createdAt);

    private static Category Create(Guid userId, AdditionalInformation description, AdditionalInformation observation, TransactionDate createdAt)
    {
        AttributeValidation(userId, description, observation, createdAt);
        return new Category
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Description = description,
            Observation = observation,
            CreatedAt = createdAt
        };
    }

    private static void AttributeValidation(Guid userId, AdditionalInformation description, AdditionalInformation observation, TransactionDate createdAt)
    {
        if (userId == Guid.Empty)
            throw new InvalidValueObjectException($"A valid user is required for the category. Please check the field {nameof(userId)}.");

        ArgumentNullException.ThrowIfNull(description, nameof(description));

        ArgumentNullException.ThrowIfNull(observation, nameof(observation));

        ArgumentNullException.ThrowIfNull(createdAt, nameof(createdAt));
    }

    public void Delete()
    {
        if (DeletedAt.HasValue)
            throw new InvalidOperationException("User is already deleted!");

        DeletedAt = DateTime.UtcNow;
    }

    public void Restore()
    {
        if (!DeletedAt.HasValue)
            throw new InvalidOperationException("User is not deleted!");

        DeletedAt = null;
    }
}