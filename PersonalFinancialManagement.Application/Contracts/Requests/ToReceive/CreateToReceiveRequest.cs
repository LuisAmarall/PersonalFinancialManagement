namespace PersonalFinancialManagement.Application.Contracts.Requests.ToReceive;

public sealed record CreateToReceiveRequest(string Description, string Observation, decimal OriginalValue, decimal AmountReceived, DateTime DueDate, DateTime ReferenceDate, DateTime DateReceipt);