namespace PersonalFinancialManagement.Application.Contracts.Responses;

public sealed record CreateToReceiveResponse(string Description, string Observation, decimal OriginalValue, decimal AmountReceived, DateTime DueDate, DateTime ReferenceDate, DateTime DateReceipt);