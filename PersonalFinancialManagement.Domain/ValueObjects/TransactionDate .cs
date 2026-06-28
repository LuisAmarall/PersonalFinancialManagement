using DomainDesign.Exceptions;
using DomainDesign.Shared;

namespace PersonalFinancialManagement.Core.Models.ValueObjects;

public sealed class TransactionDate : ValueObject<TransactionDate>
{
    public DateTime Date { get; }

    public TransactionDate(DateTime date)
    {
        var normalizedDate = date.Kind switch
        {
            DateTimeKind.Utc => date,
            DateTimeKind.Local => date,
            DateTimeKind.Unspecified => DateTime.SpecifyKind(date, DateTimeKind.Utc),
        };

        var lowerBound = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var upperBound = DateTime.UtcNow.Date;
        if (date < lowerBound || date > upperBound)
            throw new InvalidValueObjectException($"The date must be between {lowerBound:yyyy-MM-dd} and today (no future postings). Please check the field {nameof(date)}.");

        Date = date;
    }

    public static TransactionDate Create(DateTime date) => new(date);
    public static TransactionDate Today => new(DateTime.UtcNow.Date);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Date;
    }
}