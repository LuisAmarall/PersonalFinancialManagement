using DomainDesign.Exceptions;
using PersonalFinancialManagement.Core.ValueObjects;

namespace PersonalFinancialManagement.Core.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid ToPayId { get; private set; }
    public Guid ToReceiveId { get; private set; }

    public Amount Amount { get; private set; }
    public TransactionType Modality { get; private set; }
    public AdditionalInformation Description { get; private set; }
    public TransactionDate TransactionDate { get; private set; }

    private Transaction() { }

    public static Transaction LaunchRevenue(Guid userId, Guid toReceiveId, AdditionalInformation description,
        Amount amount, TransactionDate date, TransactionType modality)
        => Create(userId, description, amount, date, modality);

    public static Transaction LaunchExpense(Guid userId, Guid toPayId,AdditionalInformation description, 
        Amount amount, TransactionDate date, TransactionType modality)
        => Create(userId, description, amount, date, modality);

    private static Transaction Create(Guid userId, AdditionalInformation description, Amount amount, TransactionDate date, TransactionType modality)
    {
        AttributeValidation(userId, description, amount, date, modality);
        return new Transaction
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Description = description,
            Amount = amount,
            TransactionDate = date,
            Modality = modality
        };
    }

    private static void AttributeValidation(Guid userId, AdditionalInformation description, Amount amount, TransactionDate date, TransactionType type)
    {
        if (userId == Guid.Empty)
            throw new InvalidValueObjectException($"A valid user is required for the transaction. Please check the field {nameof(userId)}.");

        ArgumentNullException.ThrowIfNull(description, nameof(description));

        ArgumentNullException.ThrowIfNull(amount, nameof(amount));

        ArgumentNullException.ThrowIfNull(type, nameof(type));

        ArgumentNullException.ThrowIfNull(date, nameof(date));
    }
}