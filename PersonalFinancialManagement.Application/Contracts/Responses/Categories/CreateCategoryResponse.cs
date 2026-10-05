namespace PersonalFinancialManagement.Application.Contracts.Responses.Categories;

public sealed record CreateCategoryResponse(Guid Id, string Description, string Observation, DateTime CreateAt);