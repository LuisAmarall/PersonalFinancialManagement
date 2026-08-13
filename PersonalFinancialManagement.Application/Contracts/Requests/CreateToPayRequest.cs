namespace PersonalFinancialManagement.Application.Contracts.Requests;

public sealed record CreateToPayRequest(string Description, decimal OriginalValue, decimal AmountPaid, DateTime DueDate, DateTime ReferenceDate, DateTime PaymentDate);