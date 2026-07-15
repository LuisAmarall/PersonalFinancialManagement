using DomainDesign.Exceptions;
using PersonalFinancialManagement.Core.ValueObjects;

namespace PersonalFinancialManagement.Core.Entities;

public enum ToReceiveStatus
{
    Pending,
    PartiallyReceived,
    Received
}

public class ToReceive
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid CategoryId { get; private set; }

    public AdditionalInformation Description { get; private set; }
    public AdditionalInformation Observation { get; private set; }

    public Amount OriginalValue { get; private set; }
    public Amount AmountReceived { get; private set; }

    public TransactionDate DueDate { get; private set; }
    public TransactionDate ReferenceDate { get; private set; }
    public TransactionDate DateReceipt { get; private set; }
    public TransactionDate CreatedAt { get; private set; }

    public ToReceiveStatus Status { get; private set; }

    private ToReceive() { }

    public static ToReceive Create(Guid userId, Guid categoryId, AdditionalInformation description,
        AdditionalInformation observation, Amount originalValue, Amount amountReceived, TransactionDate dueDate,
        TransactionDate referenceDate, TransactionDate dateReceipt, TransactionDate createdAt)
    {
        AttributeValidation(userId, categoryId, description, observation, originalValue,
            amountReceived, dueDate, referenceDate, dateReceipt, createdAt);
        return new ToReceive
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CategoryId = categoryId,
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

    private static void AttributeValidation(Guid userId, Guid categoryId,
        AdditionalInformation description, AdditionalInformation observation, Amount originalValue, Amount amountReceived,
        TransactionDate dueDate, TransactionDate referenceDate, TransactionDate dateReceipt, TransactionDate createdAt)
    {
        if (userId == Guid.Empty)
            throw new InvalidValueObjectException($"A valid user is required for the ToReceive. Please check the field {nameof(userId)}.");
        
        if (categoryId == Guid.Empty)
            throw new InvalidValueObjectException($"A valid category is required for the ToReceive. Please check the field {nameof(categoryId)}.");
        
        ArgumentNullException.ThrowIfNull(description, nameof(description));
        ArgumentNullException.ThrowIfNull(observation, nameof(observation));
        ArgumentNullException.ThrowIfNull(originalValue, nameof(originalValue));
        ArgumentNullException.ThrowIfNull(amountReceived, nameof(amountReceived));
        ArgumentNullException.ThrowIfNull(dueDate, nameof(dueDate));
        ArgumentNullException.ThrowIfNull(referenceDate, nameof(referenceDate));
        ArgumentNullException.ThrowIfNull(dateReceipt, nameof(dateReceipt));
        ArgumentNullException.ThrowIfNull(createdAt, nameof(createdAt));
    }

    public void ChangeDescription(AdditionalInformation description)
    {
        if (HasChanged(description, Description)) { Description = description; }
    }

    public void ChangeObservation(AdditionalInformation observation)
    {
        if (HasChanged(observation, Observation)) { Observation = observation; }
    }

    public void ChengeOriginalValueTo(Amount originalValue)
    {
        ArgumentNullException.ThrowIfNull(originalValue);

        if (Status != ToReceiveStatus.Pending)
            throw new DomainException($"Cannot change the original value of a ToReceive that has already been received.");
        if (originalValue.Equals(OriginalValue)) return;

        OriginalValue = originalValue;
    }

    public void RegisterReceipt(Amount receipt, TransactionDate receiptDate)
    {
        ArgumentNullException.ThrowIfNull(receipt);
        ArgumentNullException.ThrowIfNull(receiptDate);

        if (Status == ToReceiveStatus.Received)
            throw new DomainException($"This payment has already been fully deposited for you.");
        if (receipt.Value <= 0)
            throw new DomainException($"The receipt amount must be greater than zero.");

        var newTotalReceived = AmountReceived.Value + receipt.Value;

        if (newTotalReceived > OriginalValue.Value)
            throw new DomainException($"Receipt of {receipt.Value} exceeds the outstanding balance of {OriginalValue.Value - AmountReceived.Value}.");

        AmountReceived = new Amount(newTotalReceived);

        if (newTotalReceived == OriginalValue.Value)
        {
            Status = ToReceiveStatus.Received;
            DateReceipt = receiptDate;
        }
        else { Status = ToReceiveStatus.PartiallyReceived; }
    }

    public void RescheduleDueDate(TransactionDate dueDate)
    {
        if (Status == ToReceiveStatus.Received)
            throw new DomainException($"Cannot reschedule the due date of a fully received ToReceive.");
        if (HasChanged(dueDate, DueDate)) { DueDate = dueDate; }
    }

    public void ChangeReferenceDate(TransactionDate referenceDate)
    {
        if (HasChanged(referenceDate, ReferenceDate)) { ReferenceDate = referenceDate; }
    }

    private static bool HasChanged<T>(T? newValue, T? currentValue)
    {
        ArgumentNullException.ThrowIfNull(newValue);
        return !EqualityComparer<T>.Default.Equals(newValue, currentValue);
    }
}
