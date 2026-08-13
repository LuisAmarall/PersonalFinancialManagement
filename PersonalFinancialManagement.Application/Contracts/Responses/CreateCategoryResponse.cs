namespace PersonalFinancialManagement.Application.Contracts.Responses;

public sealed record CreateCategoryResponse(Guid Id, string Description, string Observation, DateTime CreateAt);