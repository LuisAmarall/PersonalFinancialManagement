using DomainDesign.Shared;
using DomainDesign.Exceptions;

namespace PersonalFinancialManagement.Core.Models.ValueObjects;

public enum PrimaryMode
{
    Payment, Receipt
}

public enum SecondaryMode
{
    Pix, Debt, Credit, Deposit, InternationalTransfer
}

public enum CreditCardInstallments
{
    _2x, _3x, _4x, _5x, _6x, _7x, _8x, _9x, _10x, _11x, _12x, _24x, _36x, _48x
}

public sealed class TransactionType : ValueObject<TransactionType>
{
    public PrimaryMode Modality { get; }
    public SecondaryMode? Details { get; }
    public CreditCardInstallments? Installments { get; }

    private TransactionType(PrimaryMode modality,
        SecondaryMode? details, CreditCardInstallments? installments)
    {
        switch (modality)
        {
            case PrimaryMode.Payment:
            case PrimaryMode.Receipt:
                if (details is null)
                    throw new InvalidValueObjectException($"Details are required for {modality} transactions.");
                break;
        }

        var isCreditPayment = modality == PrimaryMode.Payment && details == SecondaryMode.Credit;

        if (isCreditPayment && installments is null)
            throw new InvalidValueObjectException("Installments are required for credit card payments.");

        if (!isCreditPayment && installments is not null)
            throw new InvalidValueObjectException("Installments are only accepted for credit card payments.");

        Modality = modality;
        Details = details;
        Installments = installments;
    }

    public static TransactionType CreateReceipt(SecondaryMode details)
        => new(PrimaryMode.Receipt, details, installments: null);

    public static TransactionType CreatePayment(SecondaryMode details)
    {
        if (details == SecondaryMode.Credit)
            throw new InvalidValueObjectException("Use CreatePayment(details, installments) for credit card payments.");

        return new(PrimaryMode.Payment, details, installments: null);
    }

    public static TransactionType CreateCreditPayment(CreditCardInstallments installments)
        => new(PrimaryMode.Payment, SecondaryMode.Credit, installments);

    public bool IsPayment() => Modality == PrimaryMode.Payment;
    public bool IsReceipt() => Modality == PrimaryMode.Receipt;
    public bool IsCredit() => Details == SecondaryMode.Credit;

    public SecondaryMode GetDetailsOrThrow()
    {
        if (Details is null)
            throw new InvalidOperationException($"Modality {Modality} has no details.");

        return Details.Value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Modality;
        yield return Details;
        yield return Installments;
    }
}