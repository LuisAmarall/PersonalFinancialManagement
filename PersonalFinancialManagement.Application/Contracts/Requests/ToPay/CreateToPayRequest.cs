namespace PersonalFinancialManagement.Application.Contracts.Requests.ToPay;

public sealed record CreateToPayRequest(string Description, decimal OriginalValue, decimal AmountPaid, DateTime DueDate, DateTime ReferenceDate, DateTime PaymentDate);