using DomainDesign.Exceptions;
using PersonalFinancialManagement.Core.ValueObjects;
using PersonalFinancialManagement.Core.Models.ValueObjects;

namespace PersonalFinancialManagement.Core.Models.Entities;

public class ToPay
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid Transaction { get; private set; }

    public AdditionalInformation Description { get; private set; }
    public Amount OriginalValue { get; private set; }
    public Amount AmountPaid { get; private set; }

    public TransactionDate DueDate { get; private set; }
    public TransactionDate ReferenceDate { get; private set; }
    public TransactionDate PaymentDate { get; private set; }
    public TransactionDate CreatedAt { get; private set; }

    private ToPay() { }

    public static ToPay Create(Guid userId, Guid categoryId, Guid transactionId, AdditionalInformation description,
        Amount originalValue, Amount amountPaid, TransactionDate dueDate, TransactionDate referenceDate,
        TransactionDate paymentDate, TransactionDate createdAt)
    {
        AttributeValidation(userId, categoryId, transactionId, description, originalValue, amountPaid,
            dueDate, referenceDate, paymentDate, createdAt);
        return new ToPay
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CategoryId = categoryId,
            Transaction = transactionId,
            Description = description,
            OriginalValue = originalValue,
            AmountPaid = amountPaid,
            DueDate = dueDate,
            ReferenceDate = referenceDate,
            PaymentDate = paymentDate,
            CreatedAt = createdAt
        };
    }

    private static void AttributeValidation(Guid userId, Guid categoryId, Guid transactionId, AdditionalInformation description,
        Amount originalValue, Amount amountPaid, TransactionDate dueDate, TransactionDate referenceDate,
        TransactionDate paymentDate, TransactionDate createdAt)
    {
        if (userId == Guid.Empty)
            throw new InvalidValueObjectException($"A valid user is required for the ToPay. Please check the field {nameof(userId)}.");

        if (categoryId == Guid.Empty)
            throw new InvalidValueObjectException($"A valid category is required for the ToPay. Please check the field {nameof(categoryId)}.");

        if (transactionId == Guid.Empty)
            throw new InvalidValueObjectException($"A valid transaction is required for the ToPay. Please check the field {nameof(transactionId)}.");

        ArgumentNullException.ThrowIfNull(description, nameof(description));

        ArgumentNullException.ThrowIfNull(originalValue, nameof(originalValue));

        ArgumentNullException.ThrowIfNull(amountPaid, nameof(amountPaid));

        ArgumentNullException.ThrowIfNull(dueDate, nameof(dueDate));

        ArgumentNullException.ThrowIfNull(referenceDate, nameof(referenceDate));

        ArgumentNullException.ThrowIfNull(paymentDate, nameof(paymentDate));

        ArgumentNullException.ThrowIfNull(createdAt, nameof(createdAt));
    }
}