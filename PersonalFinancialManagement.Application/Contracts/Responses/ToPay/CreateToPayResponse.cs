namespace PersonalFinancialManagement.Application.Contracts.Responses.ToPay;

public sealed record CreateToPayResponse(string Description, decimal OriginalValue, decimal AmountPaid, DateTime DueDate, DateTime ReferenceDate, DateTime PaymentDate);