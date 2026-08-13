namespace PersonalFinancialManagement.Application.Contracts.Responses.Category;

public sealed record CreateCategoryResponse(Guid Id, string Description, string Observation, DateTime CreateAt);