using DomainDesign.Exceptions;
using DomainDesign.Shared;

namespace PersonalFinancialManagement.Core.ValueObjects;

public sealed class AdditionalInformation : ValueObject<AdditionalInformation>
{
    public string Information { get; }

    public AdditionalInformation(string information)
    {
        if (information.Length > 200)
            throw new InvalidValueObjectException($"The description must be less than or equal to 200 characters. Please check the field {nameof(information)}.");

        if (string.IsNullOrWhiteSpace(information))
            throw new InvalidValueObjectException($"A description is required for the transaction. Please check the field {nameof(information)}.");

        Information = information.Trim();
    }

    public static AdditionalInformation Create(string information) => new(information);

    public override string ToString() => Information;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Information;
    }
}