using DomainDesign.Exceptions;
using PersonalFinancialManagement.Core.ValueObjects;

namespace PersonalFinancialManagement.Core.Entities;

public class ToReceive
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid TransactionId { get; private set; }

    public AdditionalInformation Description { get; private set; }
    public AdditionalInformation Observation { get; private set; }

    public Amount OriginalValue { get; private set; }
    public Amount AmountReceived { get; private set; }

    public TransactionDate DueDate { get; private set; }
    public TransactionDate ReferenceDate { get; private set; }
    public TransactionDate DateReceipt { get; private set; }
    public TransactionDate CreatedAt { get; private set; }

    private ToReceive() { }

    public static ToReceive Create(Guid userId, Guid categoryId, Guid transactionId, AdditionalInformation description,
        AdditionalInformation observation, Amount originalValue, Amount amountReceived, TransactionDate dueDate,
        TransactionDate referenceDate, TransactionDate dateReceipt, TransactionDate createdAt)
    {
        AttributeValidation(userId, categoryId, transactionId, description, observation, originalValue,
            amountReceived, dueDate, referenceDate, dateReceipt, createdAt);
        return new ToReceive
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CategoryId = categoryId,
            TransactionId = transactionId,
            Description = description,
            Observation = observation,
            OriginalValue = originalValue,
            AmountReceived = amountReceived,
            DueDate = dueDate,
            ReferenceDate = referenceDate,
            DateReceipt = dateReceipt,
            CreatedAt = createdAt
        };
    }

    private static void AttributeValidation(Guid userId, Guid categoryId, Guid transactionId,
        AdditionalInformation description, AdditionalInformation observation, Amount originalValue, Amount amountReceived,
        TransactionDate dueDate, TransactionDate referenceDate, TransactionDate dateReceipt, TransactionDate createdAt)
    {
        if (userId == Guid.Empty)
            throw new InvalidValueObjectException($"A valid user is required for the ToReceive. Please check the field {nameof(userId)}.");
        
        if (categoryId == Guid.Empty)
            throw new InvalidValueObjectException($"A valid category is required for the ToReceive. Please check the field {nameof(categoryId)}.");
        
        if (transactionId == Guid.Empty)
            throw new InvalidValueObjectException($"A valid transaction is required for the ToReceive. Please check the field {nameof(transactionId)}.");
        
        ArgumentNullException.ThrowIfNull(description, nameof(description));
        ArgumentNullException.ThrowIfNull(observation, nameof(observation));
        ArgumentNullException.ThrowIfNull(originalValue, nameof(originalValue));
        ArgumentNullException.ThrowIfNull(amountReceived, nameof(amountReceived));
        ArgumentNullException.ThrowIfNull(dueDate, nameof(dueDate));
        ArgumentNullException.ThrowIfNull(referenceDate, nameof(referenceDate));
        ArgumentNullException.ThrowIfNull(dateReceipt, nameof(dateReceipt));
        ArgumentNullException.ThrowIfNull(createdAt, nameof(createdAt));
    }
}