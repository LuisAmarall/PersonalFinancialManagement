using DomainDesign.Exceptions;
using PersonalFinancialManagement.Core.ValueObjects;

namespace PersonalFinancialManagement.Core.Entities;

public enum ToPayStatus
{
    Pending,
    PartiallyPaid,
    Paid
}

public class ToPay
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid CategoryId { get; private set; }

    public AdditionalInformation Description { get; private set; }
    public Amount OriginalValue { get; private set; }
    public Amount AmountPaid { get; private set; }

    public TransactionDate DueDate { get; private set; }
    public TransactionDate ReferenceDate { get; private set; }
    public TransactionDate? PaymentDate { get; private set; }
    public TransactionDate CreatedAt { get; private set; }

    public ToPayStatus Status { get; private set; }

    private ToPay() { }

    public static ToPay Create(Guid userId, Guid categoryId, AdditionalInformation description,
        Amount originalValue, TransactionDate dueDate, TransactionDate referenceDate, TransactionDate createdAt)
    {
        AttributeValidation(userId, categoryId, description, originalValue, dueDate, referenceDate, createdAt);
        return new ToPay
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CategoryId = categoryId,
            Description = description,
            OriginalValue = originalValue,
            AmountPaid = Amount.Zero,
            DueDate = dueDate,
            ReferenceDate = referenceDate,
            PaymentDate = null,
            CreatedAt = createdAt,
            Status = ToPayStatus.Pending
        };
    }

    private static void AttributeValidation(Guid userId, Guid categoryId, AdditionalInformation description,
        Amount originalValue, TransactionDate dueDate, TransactionDate referenceDate, TransactionDate createdAt)
    {
        if (userId == Guid.Empty)
            throw new InvalidValueObjectException($"A valid user is required for the ToPay. Please check the field {nameof(userId)}.");
        if (categoryId == Guid.Empty)
            throw new InvalidValueObjectException($"A valid category is required for the ToPay. Please check the field {nameof(categoryId)}.");

        ArgumentNullException.ThrowIfNull(description, nameof(description));
        ArgumentNullException.ThrowIfNull(originalValue, nameof(originalValue));
        ArgumentNullException.ThrowIfNull(dueDate, nameof(dueDate));
        ArgumentNullException.ThrowIfNull(referenceDate, nameof(referenceDate));
        ArgumentNullException.ThrowIfNull(createdAt, nameof(createdAt));
    }

    public void ChangeDescriptionTo(AdditionalInformation description)
    {
        if (HasChanged(description, Description)) { Description = description; }
    }

    public void ChangeOriginalValueTo(Amount originalValue)
    {
        ArgumentNullException.ThrowIfNull(originalValue);

        if (Status != ToPayStatus.Pending)
            throw new DomainException("Cannot change the original value after any payment has been registered.");
        if (originalValue.Equals(OriginalValue)) return;

        OriginalValue = originalValue;
    }

    public void RegisterPayment(Amount payment, TransactionDate paymentDate)
    {
        ArgumentNullException.ThrowIfNull(payment);
        ArgumentNullException.ThrowIfNull(paymentDate);

        if (Status == ToPayStatus.Paid)
            throw new DomainException("This payable has already been fully paid.");
        if (payment.Value <= 0)
            throw new DomainException("Payment amount must be greater than zero.");

        var newTotalPaid = AmountPaid.Value + payment.Value;

        if (newTotalPaid > OriginalValue.Value)
            throw new DomainException($"Payment of { payment.Value } exceeds the outstanding balance of { OriginalValue.Value - AmountPaid.Value}.");

        AmountPaid = new Amount(newTotalPaid);

        if (newTotalPaid == OriginalValue.Value)
        {
            Status = ToPayStatus.Paid;
            PaymentDate = paymentDate;
        }
        else { Status = ToPayStatus.PartiallyPaid; }
    }

    public void RescheduleDueDateTo(TransactionDate dueDate)
    {
        if (Status == ToPayStatus.Paid)
            throw new DomainException("Cannot reschedule the due date of a fully paid payable."); 
        if (HasChanged(dueDate, DueDate)) { DueDate = dueDate; }
    }

    public void ChangeReferenceDateTo(TransactionDate referenceDate)
    {
        if (HasChanged(referenceDate, ReferenceDate)) { ReferenceDate = referenceDate; }
    }

    private static bool HasChanged<T>(T? newValue, T? currentValue)
    {
        ArgumentNullException.ThrowIfNull(newValue);
        return !EqualityComparer<T>.Default.Equals(newValue, currentValue);
    }
}