using System.Globalization;
using DomainDesign.Shared;
using DomainDesign.Exceptions;

namespace PersonalFinancialManagement.Core.Models.ValueObjects;

public sealed class Amount : ValueObject<Amount>
{
    public const decimal MaxValue = 999_999_999.99m;

    public decimal Value { get; }

    public Amount(decimal value)
    {
        if (value <= 0)
            throw new InvalidValueObjectException($"Amount must be zero or greater. Invalid value: {value}.");

        if (value > MaxValue)
            throw new InvalidValueObjectException($"Amount must be less than or equal to {MaxValue}. Invalid value: {value}.");

        Value = value;
    }

    public static Amount Create(decimal value) => new(value);
    public static Amount Zero => new(0m);

    public override string ToString() => Value.ToString("0.00", CultureInfo.InvariantCulture);

    public static explicit operator decimal(Amount amount) => amount.Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}